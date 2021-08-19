<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmguiatransportistaadicional
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dgvdctosadicional = New System.Windows.Forms.DataGridView
        Me.Btnanadir = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        CType(Me.dgvdctosadicional, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Info
        Me.Panel1.Controls.Add(Me.btnEliminar)
        Me.Panel1.Controls.Add(Me.Btnanadir)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.dgvdctosadicional)
        Me.Panel1.Location = New System.Drawing.Point(5, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 297)
        Me.Panel1.TabIndex = 0
        '
        'dgvdctosadicional
        '
        Me.dgvdctosadicional.BackgroundColor = System.Drawing.SystemColors.Info
        Me.dgvdctosadicional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvdctosadicional.GridColor = System.Drawing.SystemColors.Info
        Me.dgvdctosadicional.Location = New System.Drawing.Point(0, 0)
        Me.dgvdctosadicional.Name = "dgvdctosadicional"
        Me.dgvdctosadicional.Size = New System.Drawing.Size(549, 249)
        Me.dgvdctosadicional.TabIndex = 0
        '
        'Btnanadir
        '
        Me.Btnanadir.BackColor = System.Drawing.Color.Moccasin
        Me.Btnanadir.Location = New System.Drawing.Point(555, 9)
        Me.Btnanadir.Name = "Btnanadir"
        Me.Btnanadir.Size = New System.Drawing.Size(75, 23)
        Me.Btnanadir.TabIndex = 1
        Me.Btnanadir.Text = "Aña&dir"
        Me.Btnanadir.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Moccasin
        Me.btnEliminar.Location = New System.Drawing.Point(555, 50)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.Moccasin
        Me.btnAceptar.Location = New System.Drawing.Point(372, 266)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Moccasin
        Me.btnCancelar.Location = New System.Drawing.Point(474, 266)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'frmguiatransportistaadicional
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 302)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmguiatransportistaadicional"
        Me.Text = "Añadir Documentos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvdctosadicional, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btnanadir As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents dgvdctosadicional As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
