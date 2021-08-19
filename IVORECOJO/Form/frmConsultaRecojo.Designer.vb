<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaRecojo
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaRecojo))
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.BtnConsultar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cboSituacion = New System.Windows.Forms.ComboBox()
        Me.CboRuta = New System.Windows.Forms.ComboBox()
        Me.CboEstado = New System.Windows.Forms.ComboBox()
        Me.CboTipoRecojo = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.grb = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lbl2 = New System.Windows.Forms.Label()
        Me.lbl3 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grb.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(12, 78)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(969, 353)
        Me.dgv.TabIndex = 0
        '
        'BtnConsultar
        '
        Me.BtnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnConsultar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsultar.Image = CType(resources.GetObject("BtnConsultar.Image"), System.Drawing.Image)
        Me.BtnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConsultar.Location = New System.Drawing.Point(905, 19)
        Me.BtnConsultar.Name = "BtnConsultar"
        Me.BtnConsultar.Size = New System.Drawing.Size(76, 38)
        Me.BtnConsultar.TabIndex = 52
        Me.BtnConsultar.Text = "&Consultar"
        Me.BtnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnConsultar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Situación"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(494, 48)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(30, 13)
        Me.Label28.TabIndex = 47
        Me.Label28.Text = "Ruta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(494, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Estado"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(240, 15)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(65, 13)
        Me.Label33.TabIndex = 44
        Me.Label33.Text = "Tipo Recojo"
        '
        'cboSituacion
        '
        Me.cboSituacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSituacion.DropDownWidth = 170
        Me.cboSituacion.FormattingEnabled = True
        Me.cboSituacion.Location = New System.Drawing.Point(321, 44)
        Me.cboSituacion.Name = "cboSituacion"
        Me.cboSituacion.Size = New System.Drawing.Size(129, 21)
        Me.cboSituacion.TabIndex = 50
        '
        'CboRuta
        '
        Me.CboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboRuta.DropDownWidth = 170
        Me.CboRuta.FormattingEnabled = True
        Me.CboRuta.Location = New System.Drawing.Point(549, 44)
        Me.CboRuta.Name = "CboRuta"
        Me.CboRuta.Size = New System.Drawing.Size(192, 21)
        Me.CboRuta.TabIndex = 51
        '
        'CboEstado
        '
        Me.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstado.DropDownWidth = 120
        Me.CboEstado.FormattingEnabled = True
        Me.CboEstado.Location = New System.Drawing.Point(549, 11)
        Me.CboEstado.Name = "CboEstado"
        Me.CboEstado.Size = New System.Drawing.Size(129, 21)
        Me.CboEstado.TabIndex = 49
        '
        'CboTipoRecojo
        '
        Me.CboTipoRecojo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoRecojo.DropDownWidth = 118
        Me.CboTipoRecojo.FormattingEnabled = True
        Me.CboTipoRecojo.Location = New System.Drawing.Point(321, 11)
        Me.CboTipoRecojo.Name = "CboTipoRecojo"
        Me.CboTipoRecojo.Size = New System.Drawing.Size(129, 21)
        Me.CboTipoRecojo.TabIndex = 48
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Fecha"
        '
        'DtpFecha
        '
        Me.DtpFecha.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DtpFecha.CustomFormat = ""
        Me.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFecha.Location = New System.Drawing.Point(72, 12)
        Me.DtpFecha.Name = "DtpFecha"
        Me.DtpFecha.Size = New System.Drawing.Size(87, 20)
        Me.DtpFecha.TabIndex = 43
        '
        'grb
        '
        Me.grb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grb.Controls.Add(Me.Label6)
        Me.grb.Controls.Add(Me.Label5)
        Me.grb.Controls.Add(Me.Label4)
        Me.grb.Controls.Add(Me.lblTotal)
        Me.grb.Controls.Add(Me.lbl3)
        Me.grb.Controls.Add(Me.lbl2)
        Me.grb.Controls.Add(Me.lbl1)
        Me.grb.Controls.Add(Me.Label3)
        Me.grb.Location = New System.Drawing.Point(12, 437)
        Me.grb.Name = "grb"
        Me.grb.Size = New System.Drawing.Size(969, 40)
        Me.grb.TabIndex = 53
        Me.grb.TabStop = False
        Me.grb.Text = "Recojos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(66, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Atendidos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(290, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "No Atendidos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(524, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Por Atender"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(832, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total"
        '
        'lbl1
        '
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(123, 17)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(73, 13)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "0"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl2
        '
        Me.lbl2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.Location = New System.Drawing.Point(365, 17)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(73, 13)
        Me.lbl2.TabIndex = 0
        Me.lbl2.Text = "0"
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl3
        '
        Me.lbl3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3.Location = New System.Drawing.Point(592, 17)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(73, 13)
        Me.lbl3.TabIndex = 0
        Me.lbl3.Text = "0"
        Me.lbl3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Red
        Me.lblTotal.Location = New System.Drawing.Point(880, 17)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(83, 13)
        Me.lblTotal.TabIndex = 0
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmConsultaRecojo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 481)
        Me.Controls.Add(Me.grb)
        Me.Controls.Add(Me.BtnConsultar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.cboSituacion)
        Me.Controls.Add(Me.CboRuta)
        Me.Controls.Add(Me.CboEstado)
        Me.Controls.Add(Me.CboTipoRecojo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.DtpFecha)
        Me.Controls.Add(Me.dgv)
        Me.Name = "frmConsultaRecojo"
        Me.Text = "Seguimiento de Recojos"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grb.ResumeLayout(False)
        Me.grb.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents BtnConsultar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cboSituacion As System.Windows.Forms.ComboBox
    Friend WithEvents CboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents CboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents CboTipoRecojo As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents grb As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
