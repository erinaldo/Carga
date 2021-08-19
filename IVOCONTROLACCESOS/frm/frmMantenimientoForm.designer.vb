<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimientoForm
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
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChboxEstado = New System.Windows.Forms.CheckBox
        Me.txtEtiqueta = New System.Windows.Forms.TextBox
        Me.txtNombreForm = New System.Windows.Forms.TextBox
        Me.cmbProcesos = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbCODIFGO = New System.Windows.Forms.Label
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 200)
        Me.Panel1.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(262, 164)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(99, 26)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Transparent
        Me.btnAceptar.Location = New System.Drawing.Point(147, 164)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(99, 26)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&ACEPTAR"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lbCODIFGO)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ChboxEstado)
        Me.GroupBox1.Controls.Add(Me.txtEtiqueta)
        Me.GroupBox1.Controls.Add(Me.txtNombreForm)
        Me.GroupBox1.Controls.Add(Me.cmbProcesos)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(485, 152)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FORM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "ESTADO"
        '
        'ChboxEstado
        '
        Me.ChboxEstado.AutoSize = True
        Me.ChboxEstado.Location = New System.Drawing.Point(142, 118)
        Me.ChboxEstado.Name = "ChboxEstado"
        Me.ChboxEstado.Size = New System.Drawing.Size(15, 14)
        Me.ChboxEstado.TabIndex = 6
        Me.ChboxEstado.UseVisualStyleBackColor = True
        '
        'txtEtiqueta
        '
        Me.txtEtiqueta.Location = New System.Drawing.Point(141, 88)
        Me.txtEtiqueta.Name = "txtEtiqueta"
        Me.txtEtiqueta.Size = New System.Drawing.Size(241, 20)
        Me.txtEtiqueta.TabIndex = 5
        '
        'txtNombreForm
        '
        Me.txtNombreForm.Location = New System.Drawing.Point(141, 58)
        Me.txtNombreForm.Name = "txtNombreForm"
        Me.txtNombreForm.Size = New System.Drawing.Size(241, 20)
        Me.txtNombreForm.TabIndex = 4
        '
        'cmbProcesos
        '
        Me.cmbProcesos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProcesos.FormattingEnabled = True
        Me.cmbProcesos.Location = New System.Drawing.Point(141, 26)
        Me.cmbProcesos.Name = "cmbProcesos"
        Me.cmbProcesos.Size = New System.Drawing.Size(241, 21)
        Me.cmbProcesos.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ETIQUETA FORM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NOMBRE FORM"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "PROCESO:"
        '
        'lbCODIFGO
        '
        Me.lbCODIFGO.AutoSize = True
        Me.lbCODIFGO.Location = New System.Drawing.Point(395, 30)
        Me.lbCODIFGO.Name = "lbCODIFGO"
        Me.lbCODIFGO.Size = New System.Drawing.Size(38, 13)
        Me.lbCODIFGO.TabIndex = 8
        Me.lbCODIFGO.Text = "T0000"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmMantenimientoForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 198)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMantenimientoForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento de Form"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChboxEstado As System.Windows.Forms.CheckBox
    Friend WithEvents txtEtiqueta As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreForm As System.Windows.Forms.TextBox
    Friend WithEvents cmbProcesos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbCODIFGO As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
