<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTeleventasVer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTeleventasVer))
        Me.tabLlamada = New System.Windows.Forms.TabControl()
        Me.tabLista = New System.Windows.Forms.TabPage()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.tabMantenimiento = New System.Windows.Forms.TabPage()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDato = New System.Windows.Forms.TextBox()
        Me.lblDato = New System.Windows.Forms.Label()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.tabLlamada.SuspendLayout()
        Me.tabLista.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMantenimiento.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabLlamada
        '
        Me.tabLlamada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabLlamada.Controls.Add(Me.tabLista)
        Me.tabLlamada.Controls.Add(Me.tabMantenimiento)
        Me.tabLlamada.Location = New System.Drawing.Point(10, 19)
        Me.tabLlamada.Name = "tabLlamada"
        Me.tabLlamada.SelectedIndex = 0
        Me.tabLlamada.Size = New System.Drawing.Size(931, 586)
        Me.tabLlamada.TabIndex = 1
        '
        'tabLista
        '
        Me.tabLista.Controls.Add(Me.dgv)
        Me.tabLista.Location = New System.Drawing.Point(4, 22)
        Me.tabLista.Name = "tabLista"
        Me.tabLista.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLista.Size = New System.Drawing.Size(923, 560)
        Me.tabLista.TabIndex = 0
        Me.tabLista.Text = "Lista"
        Me.tabLista.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(10, 13)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(904, 537)
        Me.dgv.TabIndex = 1
        '
        'tabMantenimiento
        '
        Me.tabMantenimiento.Controls.Add(Me.btnCancelar)
        Me.tabMantenimiento.Controls.Add(Me.btnGrabar)
        Me.tabMantenimiento.Controls.Add(Me.Label4)
        Me.tabMantenimiento.Controls.Add(Me.Label3)
        Me.tabMantenimiento.Controls.Add(Me.txtDato)
        Me.tabMantenimiento.Controls.Add(Me.lblDato)
        Me.tabMantenimiento.Controls.Add(Me.lblCliente)
        Me.tabMantenimiento.Controls.Add(Me.Label1)
        Me.tabMantenimiento.Location = New System.Drawing.Point(4, 22)
        Me.tabMantenimiento.Name = "tabMantenimiento"
        Me.tabMantenimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMantenimiento.Size = New System.Drawing.Size(923, 560)
        Me.tabMantenimiento.TabIndex = 1
        Me.tabMantenimiento.Text = "Mantenimiento"
        Me.tabMantenimiento.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(413, 275)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 35)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Location = New System.Drawing.Point(294, 275)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(75, 35)
        Me.btnGrabar.TabIndex = 1
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(305, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Nuevo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(305, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Actual"
        '
        'txtDato
        '
        Me.txtDato.Location = New System.Drawing.Point(363, 209)
        Me.txtDato.MaxLength = 11
        Me.txtDato.Name = "txtDato"
        Me.txtDato.Size = New System.Drawing.Size(111, 20)
        Me.txtDato.TabIndex = 0
        '
        'lblDato
        '
        Me.lblDato.AutoSize = True
        Me.lblDato.Location = New System.Drawing.Point(360, 177)
        Me.lblDato.Name = "lblDato"
        Me.lblDato.Size = New System.Drawing.Size(73, 13)
        Me.lblDato.TabIndex = 0
        Me.lblDato.Text = "12345678901"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(360, 132)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "Cliente"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(305, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'Panel11
        '
        Me.Panel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel11.Controls.Add(Me.btnSalir)
        Me.Panel11.Location = New System.Drawing.Point(862, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(78, 31)
        Me.Panel11.TabIndex = 6
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ForeColor = System.Drawing.Color.Black
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(5, 0)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(69, 31)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'frmTeleventasVer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 611)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.tabLlamada)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmTeleventasVer"
        Me.Text = "Llamadas Erróneas"
        Me.tabLlamada.ResumeLayout(False)
        Me.tabLista.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMantenimiento.ResumeLayout(False)
        Me.tabMantenimiento.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabLlamada As System.Windows.Forms.TabControl
    Friend WithEvents tabLista As System.Windows.Forms.TabPage
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents tabMantenimiento As System.Windows.Forms.TabPage
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDato As System.Windows.Forms.TextBox
    Friend WithEvents lblDato As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents lblCliente As System.Windows.Forms.Label
End Class
