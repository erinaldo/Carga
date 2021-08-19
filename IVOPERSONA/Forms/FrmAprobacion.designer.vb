<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAprobacionLineaCredito
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAprobacionLineaCredito))
        Me.Label13 = New System.Windows.Forms.Label()
        Me.RbtRechazadas = New System.Windows.Forms.RadioButton()
        Me.RbtAprobadas = New System.Windows.Forms.RadioButton()
        Me.RbtAprobar = New System.Windows.Forms.RadioButton()
        Me.RbtPreaprobar = New System.Windows.Forms.RadioButton()
        Me.Tab = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.Flow1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.LblDato = New System.Windows.Forms.Label()
        Me.CboDato = New System.Windows.Forms.ComboBox()
        Me.Flow2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtpInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpFin = New System.Windows.Forms.DateTimePicker()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.BtnAceptar2 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblLineaFinalAprobada = New System.Windows.Forms.Label()
        Me.LblSobregiroAprobado = New System.Windows.Forms.Label()
        Me.LblMontoAprobado = New System.Windows.Forms.Label()
        Me.LblUsuario2 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LblFin = New System.Windows.Forms.Label()
        Me.LblInicio = New System.Windows.Forms.Label()
        Me.LblPeriodo = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LblCondicion = New System.Windows.Forms.Label()
        Me.LblDia = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TxtMontoPreAprobado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblMontoSolicitado2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GrbSituacionFinal = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChkSobregiro = New System.Windows.Forms.CheckBox()
        Me.TxtMontoOtorgado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtSobregiro = New System.Windows.Forms.Label()
        Me.LblMontoPreaprobado = New System.Windows.Forms.Label()
        Me.LblMontoSolicitado = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TxtObservacion = New System.Windows.Forms.TextBox()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.RbtNo = New System.Windows.Forms.RadioButton()
        Me.RbtSi = New System.Windows.Forms.RadioButton()
        Me.LblAprobar = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.tool = New System.Windows.Forms.MenuStrip()
        Me.TsbHistorial = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsbDesactivar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TsbSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tab.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.Flow1.SuspendLayout()
        Me.Flow2.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GrbSituacionFinal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tool.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(69, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Solicitudes"
        '
        'RbtRechazadas
        '
        Me.RbtRechazadas.AutoSize = True
        Me.RbtRechazadas.Location = New System.Drawing.Point(405, 31)
        Me.RbtRechazadas.Name = "RbtRechazadas"
        Me.RbtRechazadas.Size = New System.Drawing.Size(85, 17)
        Me.RbtRechazadas.TabIndex = 14
        Me.RbtRechazadas.Tag = "4"
        Me.RbtRechazadas.Text = "Rechazadas"
        Me.RbtRechazadas.UseVisualStyleBackColor = True
        '
        'RbtAprobadas
        '
        Me.RbtAprobadas.AutoSize = True
        Me.RbtAprobadas.Location = New System.Drawing.Point(309, 31)
        Me.RbtAprobadas.Name = "RbtAprobadas"
        Me.RbtAprobadas.Size = New System.Drawing.Size(76, 17)
        Me.RbtAprobadas.TabIndex = 15
        Me.RbtAprobadas.Tag = "3"
        Me.RbtAprobadas.Text = "Aprobadas"
        Me.RbtAprobadas.UseVisualStyleBackColor = True
        '
        'RbtAprobar
        '
        Me.RbtAprobar.AutoSize = True
        Me.RbtAprobar.Location = New System.Drawing.Point(208, 31)
        Me.RbtAprobar.Name = "RbtAprobar"
        Me.RbtAprobar.Size = New System.Drawing.Size(81, 17)
        Me.RbtAprobar.TabIndex = 12
        Me.RbtAprobar.Tag = "2"
        Me.RbtAprobar.Text = "Por Aprobar"
        Me.RbtAprobar.UseVisualStyleBackColor = True
        '
        'RbtPreaprobar
        '
        Me.RbtPreaprobar.AutoSize = True
        Me.RbtPreaprobar.Location = New System.Drawing.Point(93, 31)
        Me.RbtPreaprobar.Name = "RbtPreaprobar"
        Me.RbtPreaprobar.Size = New System.Drawing.Size(100, 17)
        Me.RbtPreaprobar.TabIndex = 13
        Me.RbtPreaprobar.Tag = "1"
        Me.RbtPreaprobar.Text = "Por Pre Aprobar"
        Me.RbtPreaprobar.UseVisualStyleBackColor = True
        '
        'Tab
        '
        Me.Tab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tab.Controls.Add(Me.Tab1)
        Me.Tab.Controls.Add(Me.Tab2)
        Me.Tab.Location = New System.Drawing.Point(8, 53)
        Me.Tab.Name = "Tab"
        Me.Tab.SelectedIndex = 0
        Me.Tab.Size = New System.Drawing.Size(822, 432)
        Me.Tab.TabIndex = 11
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.Flow1)
        Me.Tab1.Controls.Add(Me.Flow2)
        Me.Tab1.Controls.Add(Me.dgv)
        Me.Tab1.Location = New System.Drawing.Point(4, 22)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(814, 406)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "Lista"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'Flow1
        '
        Me.Flow1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Flow1.AutoSize = True
        Me.Flow1.Controls.Add(Me.LblDato)
        Me.Flow1.Controls.Add(Me.CboDato)
        Me.Flow1.Location = New System.Drawing.Point(514, 5)
        Me.Flow1.Name = "Flow1"
        Me.Flow1.Size = New System.Drawing.Size(304, 27)
        Me.Flow1.TabIndex = 13
        Me.Flow1.Visible = False
        '
        'LblDato
        '
        Me.LblDato.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LblDato.AutoSize = True
        Me.LblDato.Location = New System.Drawing.Point(3, 7)
        Me.LblDato.Name = "LblDato"
        Me.LblDato.Size = New System.Drawing.Size(23, 13)
        Me.LblDato.TabIndex = 11
        Me.LblDato.Text = "Por"
        '
        'CboDato
        '
        Me.CboDato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboDato.FormattingEnabled = True
        Me.CboDato.Location = New System.Drawing.Point(32, 3)
        Me.CboDato.Name = "CboDato"
        Me.CboDato.Size = New System.Drawing.Size(269, 21)
        Me.CboDato.TabIndex = 12
        '
        'Flow2
        '
        Me.Flow2.AutoSize = True
        Me.Flow2.Controls.Add(Me.Label2)
        Me.Flow2.Controls.Add(Me.DtpInicio)
        Me.Flow2.Controls.Add(Me.Label3)
        Me.Flow2.Controls.Add(Me.DtpFin)
        Me.Flow2.Location = New System.Drawing.Point(6, 5)
        Me.Flow2.Name = "Flow2"
        Me.Flow2.Size = New System.Drawing.Size(232, 27)
        Me.Flow2.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Del"
        '
        'DtpInicio
        '
        Me.DtpInicio.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DtpInicio.CustomFormat = ""
        Me.DtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpInicio.Location = New System.Drawing.Point(32, 3)
        Me.DtpInicio.Name = "DtpInicio"
        Me.DtpInicio.Size = New System.Drawing.Size(84, 20)
        Me.DtpInicio.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(122, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Al"
        '
        'DtpFin
        '
        Me.DtpFin.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DtpFin.CustomFormat = ""
        Me.DtpFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFin.Location = New System.Drawing.Point(144, 3)
        Me.DtpFin.Name = "DtpFin"
        Me.DtpFin.Size = New System.Drawing.Size(84, 20)
        Me.DtpFin.TabIndex = 11
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.BackgroundColor = System.Drawing.Color.MidnightBlue
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(6, 36)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(802, 364)
        Me.dgv.TabIndex = 1
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.BtnAceptar2)
        Me.Tab2.Controls.Add(Me.GroupBox1)
        Me.Tab2.Controls.Add(Me.LblUsuario2)
        Me.Tab2.Controls.Add(Me.LblUsuario)
        Me.Tab2.Controls.Add(Me.GroupBox3)
        Me.Tab2.Controls.Add(Me.Panel4)
        Me.Tab2.Controls.Add(Me.Panel3)
        Me.Tab2.Controls.Add(Me.Panel2)
        Me.Tab2.Controls.Add(Me.Panel1)
        Me.Tab2.Location = New System.Drawing.Point(4, 22)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(814, 406)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "Aprobación"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'BtnAceptar2
        '
        Me.BtnAceptar2.Location = New System.Drawing.Point(700, 369)
        Me.BtnAceptar2.Name = "BtnAceptar2"
        Me.BtnAceptar2.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar2.TabIndex = 17
        Me.BtnAceptar2.Text = "&Aceptar"
        Me.BtnAceptar2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblLineaFinalAprobada)
        Me.GroupBox1.Controls.Add(Me.LblSobregiroAprobado)
        Me.GroupBox1.Controls.Add(Me.LblMontoAprobado)
        Me.GroupBox1.Location = New System.Drawing.Point(436, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 69)
        Me.GroupBox1.TabIndex = 193
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Situación Final"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(249, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Línea Final Aprobada"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(118, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Sobregiro Aprobado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Monto Aprobado"
        '
        'LblLineaFinalAprobada
        '
        Me.LblLineaFinalAprobada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLineaFinalAprobada.ForeColor = System.Drawing.Color.Red
        Me.LblLineaFinalAprobada.Location = New System.Drawing.Point(242, 43)
        Me.LblLineaFinalAprobada.Name = "LblLineaFinalAprobada"
        Me.LblLineaFinalAprobada.Size = New System.Drawing.Size(116, 13)
        Me.LblLineaFinalAprobada.TabIndex = 0
        Me.LblLineaFinalAprobada.Text = "0.00"
        Me.LblLineaFinalAprobada.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblSobregiroAprobado
        '
        Me.LblSobregiroAprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSobregiroAprobado.Location = New System.Drawing.Point(129, 43)
        Me.LblSobregiroAprobado.Name = "LblSobregiroAprobado"
        Me.LblSobregiroAprobado.Size = New System.Drawing.Size(90, 13)
        Me.LblSobregiroAprobado.TabIndex = 0
        Me.LblSobregiroAprobado.Text = "0.00"
        Me.LblSobregiroAprobado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMontoAprobado
        '
        Me.LblMontoAprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoAprobado.Location = New System.Drawing.Point(6, 43)
        Me.LblMontoAprobado.Name = "LblMontoAprobado"
        Me.LblMontoAprobado.Size = New System.Drawing.Size(93, 13)
        Me.LblMontoAprobado.TabIndex = 0
        Me.LblMontoAprobado.Text = "0.00"
        Me.LblMontoAprobado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUsuario2
        '
        Me.LblUsuario2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario2.Location = New System.Drawing.Point(436, 167)
        Me.LblUsuario2.Name = "LblUsuario2"
        Me.LblUsuario2.Size = New System.Drawing.Size(366, 14)
        Me.LblUsuario2.TabIndex = 210
        Me.LblUsuario2.Text = "Label17"
        Me.LblUsuario2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblUsuario
        '
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.ForeColor = System.Drawing.Color.Red
        Me.LblUsuario.Location = New System.Drawing.Point(6, 150)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(796, 14)
        Me.LblUsuario.TabIndex = 209
        Me.LblUsuario.Text = "Label17"
        Me.LblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LblFin)
        Me.GroupBox3.Controls.Add(Me.LblInicio)
        Me.GroupBox3.Controls.Add(Me.LblPeriodo)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.LblCondicion)
        Me.GroupBox3.Controls.Add(Me.LblDia)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(799, 63)
        Me.GroupBox3.TabIndex = 208
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Consideración de Cobranzas"
        '
        'LblFin
        '
        Me.LblFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFin.Location = New System.Drawing.Point(721, 39)
        Me.LblFin.Name = "LblFin"
        Me.LblFin.Size = New System.Drawing.Size(73, 13)
        Me.LblFin.TabIndex = 211
        Me.LblFin.Text = "Label16"
        '
        'LblInicio
        '
        Me.LblInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInicio.Location = New System.Drawing.Point(625, 39)
        Me.LblInicio.Name = "LblInicio"
        Me.LblInicio.Size = New System.Drawing.Size(72, 13)
        Me.LblInicio.TabIndex = 214
        Me.LblInicio.Text = "Label16"
        '
        'LblPeriodo
        '
        Me.LblPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPeriodo.Location = New System.Drawing.Point(109, 39)
        Me.LblPeriodo.Name = "LblPeriodo"
        Me.LblPeriodo.Size = New System.Drawing.Size(104, 13)
        Me.LblPeriodo.TabIndex = 213
        Me.LblPeriodo.Text = "Label16"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(2, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 212
        Me.Label14.Text = "Condición"
        '
        'LblCondicion
        '
        Me.LblCondicion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCondicion.Location = New System.Drawing.Point(110, 19)
        Me.LblCondicion.Name = "LblCondicion"
        Me.LblCondicion.Size = New System.Drawing.Size(677, 13)
        Me.LblCondicion.TabIndex = 208
        Me.LblCondicion.Text = "Label14"
        '
        'LblDia
        '
        Me.LblDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDia.ForeColor = System.Drawing.Color.Red
        Me.LblDia.Location = New System.Drawing.Point(209, 39)
        Me.LblDia.Name = "LblDia"
        Me.LblDia.Size = New System.Drawing.Size(304, 13)
        Me.LblDia.TabIndex = 216
        Me.LblDia.Text = "LblDia"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(512, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(109, 13)
        Me.Label16.TabIndex = 215
        Me.Label16.Text = "Horario Cobranza  De"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(702, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(14, 13)
        Me.Label18.TabIndex = 210
        Me.Label18.Text = "A"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(2, 39)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(108, 13)
        Me.Label15.TabIndex = 209
        Me.Label15.Text = "Período de Cobranza"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox2)
        Me.Panel4.Location = New System.Drawing.Point(3, 157)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(435, 75)
        Me.Panel4.TabIndex = 198
        Me.Panel4.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TxtMontoPreAprobado)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.LblMontoSolicitado2)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(421, 68)
        Me.GroupBox2.TabIndex = 191
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Línea de Crédito"
        '
        'TxtMontoPreAprobado
        '
        Me.TxtMontoPreAprobado.Location = New System.Drawing.Point(103, 36)
        Me.TxtMontoPreAprobado.MaxLength = 13
        Me.TxtMontoPreAprobado.Name = "TxtMontoPreAprobado"
        Me.TxtMontoPreAprobado.Size = New System.Drawing.Size(103, 20)
        Me.TxtMontoPreAprobado.TabIndex = 4
        Me.TxtMontoPreAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(100, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Monto por Pre Aprobar"
        '
        'LblMontoSolicitado2
        '
        Me.LblMontoSolicitado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoSolicitado2.ForeColor = System.Drawing.Color.Black
        Me.LblMontoSolicitado2.Location = New System.Drawing.Point(9, 41)
        Me.LblMontoSolicitado2.Name = "LblMontoSolicitado2"
        Me.LblMontoSolicitado2.Size = New System.Drawing.Size(85, 13)
        Me.LblMontoSolicitado2.TabIndex = 0
        Me.LblMontoSolicitado2.Text = "0.00"
        Me.LblMontoSolicitado2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Monto Solicitado"
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(433, 76)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(378, 75)
        Me.Panel3.TabIndex = 197
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GrbSituacionFinal)
        Me.Panel2.Location = New System.Drawing.Point(3, 76)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(427, 75)
        Me.Panel2.TabIndex = 196
        '
        'GrbSituacionFinal
        '
        Me.GrbSituacionFinal.Controls.Add(Me.Label9)
        Me.GrbSituacionFinal.Controls.Add(Me.ChkSobregiro)
        Me.GrbSituacionFinal.Controls.Add(Me.TxtMontoOtorgado)
        Me.GrbSituacionFinal.Controls.Add(Me.Label5)
        Me.GrbSituacionFinal.Controls.Add(Me.Label4)
        Me.GrbSituacionFinal.Controls.Add(Me.TxtSobregiro)
        Me.GrbSituacionFinal.Controls.Add(Me.LblMontoPreaprobado)
        Me.GrbSituacionFinal.Controls.Add(Me.LblMontoSolicitado)
        Me.GrbSituacionFinal.Controls.Add(Me.Label11)
        Me.GrbSituacionFinal.Controls.Add(Me.Label1)
        Me.GrbSituacionFinal.Location = New System.Drawing.Point(3, 3)
        Me.GrbSituacionFinal.Name = "GrbSituacionFinal"
        Me.GrbSituacionFinal.Size = New System.Drawing.Size(421, 68)
        Me.GrbSituacionFinal.TabIndex = 191
        Me.GrbSituacionFinal.TabStop = False
        Me.GrbSituacionFinal.Text = "Línea de Crédito"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(394, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(16, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "%"
        '
        'ChkSobregiro
        '
        Me.ChkSobregiro.AutoSize = True
        Me.ChkSobregiro.Checked = True
        Me.ChkSobregiro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSobregiro.Enabled = False
        Me.ChkSobregiro.Location = New System.Drawing.Point(362, 42)
        Me.ChkSobregiro.Name = "ChkSobregiro"
        Me.ChkSobregiro.Size = New System.Drawing.Size(15, 14)
        Me.ChkSobregiro.TabIndex = 5
        Me.ChkSobregiro.UseVisualStyleBackColor = True
        '
        'TxtMontoOtorgado
        '
        Me.TxtMontoOtorgado.Location = New System.Drawing.Point(231, 38)
        Me.TxtMontoOtorgado.MaxLength = 13
        Me.TxtMontoOtorgado.Name = "TxtMontoOtorgado"
        Me.TxtMontoOtorgado.Size = New System.Drawing.Size(108, 20)
        Me.TxtMontoOtorgado.TabIndex = 4
        Me.TxtMontoOtorgado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(358, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Sobregiro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(228, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Monto Otorgado"
        '
        'TxtSobregiro
        '
        Me.TxtSobregiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSobregiro.ForeColor = System.Drawing.Color.Black
        Me.TxtSobregiro.Location = New System.Drawing.Point(366, 42)
        Me.TxtSobregiro.Name = "TxtSobregiro"
        Me.TxtSobregiro.Size = New System.Drawing.Size(32, 13)
        Me.TxtSobregiro.TabIndex = 0
        Me.TxtSobregiro.Text = "10"
        Me.TxtSobregiro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMontoPreaprobado
        '
        Me.LblMontoPreaprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoPreaprobado.ForeColor = System.Drawing.Color.Black
        Me.LblMontoPreaprobado.Location = New System.Drawing.Point(122, 43)
        Me.LblMontoPreaprobado.Name = "LblMontoPreaprobado"
        Me.LblMontoPreaprobado.Size = New System.Drawing.Size(79, 13)
        Me.LblMontoPreaprobado.TabIndex = 0
        Me.LblMontoPreaprobado.Text = "0.00"
        Me.LblMontoPreaprobado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblMontoSolicitado
        '
        Me.LblMontoSolicitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMontoSolicitado.ForeColor = System.Drawing.Color.Black
        Me.LblMontoSolicitado.Location = New System.Drawing.Point(9, 43)
        Me.LblMontoSolicitado.Name = "LblMontoSolicitado"
        Me.LblMontoSolicitado.Size = New System.Drawing.Size(79, 13)
        Me.LblMontoSolicitado.TabIndex = 0
        Me.LblMontoSolicitado.Text = "0.00"
        Me.LblMontoSolicitado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(99, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Monto Pre Aprobado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Monto Solicitado"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TxtObservacion)
        Me.Panel1.Controls.Add(Me.BtnAceptar)
        Me.Panel1.Controls.Add(Me.RbtNo)
        Me.Panel1.Controls.Add(Me.RbtSi)
        Me.Panel1.Controls.Add(Me.LblAprobar)
        Me.Panel1.Location = New System.Drawing.Point(227, 308)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(390, 91)
        Me.Panel1.TabIndex = 195
        '
        'TxtObservacion
        '
        Me.TxtObservacion.Enabled = False
        Me.TxtObservacion.Location = New System.Drawing.Point(110, 35)
        Me.TxtObservacion.MaxLength = 100
        Me.TxtObservacion.Name = "TxtObservacion"
        Me.TxtObservacion.Size = New System.Drawing.Size(272, 20)
        Me.TxtObservacion.TabIndex = 15
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(112, 61)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.BtnAceptar.TabIndex = 16
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'RbtNo
        '
        Me.RbtNo.AutoSize = True
        Me.RbtNo.Location = New System.Drawing.Point(65, 35)
        Me.RbtNo.Name = "RbtNo"
        Me.RbtNo.Size = New System.Drawing.Size(39, 17)
        Me.RbtNo.TabIndex = 14
        Me.RbtNo.Text = "No"
        Me.RbtNo.UseVisualStyleBackColor = True
        '
        'RbtSi
        '
        Me.RbtSi.AutoSize = True
        Me.RbtSi.Checked = True
        Me.RbtSi.Location = New System.Drawing.Point(16, 35)
        Me.RbtSi.Name = "RbtSi"
        Me.RbtSi.Size = New System.Drawing.Size(34, 17)
        Me.RbtSi.TabIndex = 13
        Me.RbtSi.TabStop = True
        Me.RbtSi.Text = "Si"
        Me.RbtSi.UseVisualStyleBackColor = True
        '
        'LblAprobar
        '
        Me.LblAprobar.AutoSize = True
        Me.LblAprobar.Location = New System.Drawing.Point(13, 9)
        Me.LblAprobar.Name = "LblAprobar"
        Me.LblAprobar.Size = New System.Drawing.Size(44, 13)
        Me.LblAprobar.TabIndex = 12
        Me.LblAprobar.Text = "Aprobar"
        '
        'LblCliente
        '
        Me.LblCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCliente.Location = New System.Drawing.Point(489, 31)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(336, 15)
        Me.LblCliente.TabIndex = 211
        Me.LblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tool
        '
        Me.tool.BackColor = System.Drawing.Color.Transparent
        Me.tool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TsbHistorial, Me.TsbDesactivar, Me.TsbSalir})
        Me.tool.Location = New System.Drawing.Point(0, 0)
        Me.tool.Name = "tool"
        Me.tool.Size = New System.Drawing.Size(837, 32)
        Me.tool.TabIndex = 212
        Me.tool.Text = "MenuStrip1"
        '
        'TsbHistorial
        '
        Me.TsbHistorial.Image = Global.INTEGRACION.My.Resources.Resources._079
        Me.TsbHistorial.Name = "TsbHistorial"
        Me.TsbHistorial.Size = New System.Drawing.Size(168, 28)
        Me.TsbHistorial.Text = "Historial Línea de Crédito"
        '
        'TsbDesactivar
        '
        Me.TsbDesactivar.Image = Global.INTEGRACION.My.Resources.Resources.delete_161
        Me.TsbDesactivar.Name = "TsbDesactivar"
        Me.TsbDesactivar.Size = New System.Drawing.Size(178, 28)
        Me.TsbDesactivar.Text = "Desactivar Línea de Crédito"
        '
        'TsbSalir
        '
        Me.TsbSalir.Image = CType(resources.GetObject("TsbSalir.Image"), System.Drawing.Image)
        Me.TsbSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.TsbSalir.Name = "TsbSalir"
        Me.TsbSalir.Size = New System.Drawing.Size(65, 28)
        Me.TsbSalir.Text = "&Salir"
        '
        'FrmAprobacionLineaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 497)
        Me.Controls.Add(Me.LblCliente)
        Me.Controls.Add(Me.tool)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.RbtRechazadas)
        Me.Controls.Add(Me.RbtAprobadas)
        Me.Controls.Add(Me.RbtAprobar)
        Me.Controls.Add(Me.RbtPreaprobar)
        Me.Controls.Add(Me.Tab)
        Me.MainMenuStrip = Me.tool
        Me.Name = "FrmAprobacionLineaCredito"
        Me.Text = "Aprobación de Línea de Crédito"
        Me.Tab.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Flow1.ResumeLayout(False)
        Me.Flow1.PerformLayout()
        Me.Flow2.ResumeLayout(False)
        Me.Flow2.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GrbSituacionFinal.ResumeLayout(False)
        Me.GrbSituacionFinal.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tool.ResumeLayout(False)
        Me.tool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents RbtRechazadas As System.Windows.Forms.RadioButton
    Friend WithEvents RbtAprobadas As System.Windows.Forms.RadioButton
    Friend WithEvents RbtAprobar As System.Windows.Forms.RadioButton
    Friend WithEvents RbtPreaprobar As System.Windows.Forms.RadioButton
    Friend WithEvents Tab As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Flow1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents LblDato As System.Windows.Forms.Label
    Friend WithEvents CboDato As System.Windows.Forms.ComboBox
    Friend WithEvents Flow2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtpInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtMontoPreAprobado As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents LblMontoSolicitado2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LblLineaFinalAprobada As System.Windows.Forms.Label
    Friend WithEvents LblSobregiroAprobado As System.Windows.Forms.Label
    Friend WithEvents LblMontoAprobado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GrbSituacionFinal As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChkSobregiro As System.Windows.Forms.CheckBox
    Friend WithEvents TxtMontoOtorgado As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSobregiro As System.Windows.Forms.Label
    Friend WithEvents LblMontoPreaprobado As System.Windows.Forms.Label
    Friend WithEvents LblMontoSolicitado As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents RbtNo As System.Windows.Forms.RadioButton
    Friend WithEvents RbtSi As System.Windows.Forms.RadioButton
    Friend WithEvents LblAprobar As System.Windows.Forms.Label
    Friend WithEvents LblFin As System.Windows.Forms.Label
    Friend WithEvents LblInicio As System.Windows.Forms.Label
    Friend WithEvents LblPeriodo As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LblCondicion As System.Windows.Forms.Label
    Friend WithEvents LblDia As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents LblUsuario2 As System.Windows.Forms.Label
    Friend WithEvents BtnAceptar2 As System.Windows.Forms.Button
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents tool As System.Windows.Forms.MenuStrip
    Friend WithEvents TsbDesactivar As System.Windows.Forms.ToolStripMenuItem
    Protected WithEvents TsbSalir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TsbHistorial As System.Windows.Forms.ToolStripMenuItem

End Class
