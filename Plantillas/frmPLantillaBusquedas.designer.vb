<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPLantillaBusquedas
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
        Me.ShadowLabel1 = New Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtBusca = New System.Windows.Forms.TextBox
        Me.DataGridLista = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.DataGridViewFiltro = New System.Windows.Forms.DataGridView
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAcepatar = New System.Windows.Forms.Button
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridViewFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.BackColor = System.Drawing.SystemColors.Window
        Me.ShadowLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ShadowLabel1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShadowLabel1.ForeColor = System.Drawing.SystemColors.Highlight
        Me.ShadowLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ShadowLabel1.Name = "ShadowLabel1"
        Me.ShadowLabel1.ShadowColor = System.Drawing.Color.Silver
        Me.ShadowLabel1.Size = New System.Drawing.Size(598, 33)
        Me.ShadowLabel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(18, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Buscar"
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(21, 34)
        Me.TxtBusca.Name = "TxtBusca"
        Me.TxtBusca.Size = New System.Drawing.Size(138, 20)
        Me.TxtBusca.TabIndex = 1
        '
        'DataGridLista
        '
        Me.DataGridLista.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGridLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataGridLista.DataMember = ""
        Me.DataGridLista.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridLista.Location = New System.Drawing.Point(21, 83)
        Me.DataGridLista.Name = "DataGridLista"
        Me.DataGridLista.Size = New System.Drawing.Size(494, 380)
        Me.DataGridLista.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Buscar"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(21, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(138, 20)
        Me.TextBox1.TabIndex = 1
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.SystemColors.Info
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(21, 83)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(494, 380)
        Me.DataGrid1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DataGridViewFiltro)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAcepatar)
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(598, 539)
        Me.Panel1.TabIndex = 7
        '
        'DataGridViewFiltro
        '
        Me.DataGridViewFiltro.AllowUserToOrderColumns = True
        Me.DataGridViewFiltro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewFiltro.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewFiltro.Name = "DataGridViewFiltro"
        Me.DataGridViewFiltro.Size = New System.Drawing.Size(592, 481)
        Me.DataGridViewFiltro.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.Location = New System.Drawing.Point(290, 490)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(103, 30)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnAcepatar
        '
        Me.btnAcepatar.BackColor = System.Drawing.Color.Transparent
        Me.btnAcepatar.Location = New System.Drawing.Point(181, 490)
        Me.btnAcepatar.Name = "btnAcepatar"
        Me.btnAcepatar.Size = New System.Drawing.Size(103, 30)
        Me.btnAcepatar.TabIndex = 2
        Me.btnAcepatar.Text = "&Aceptar"
        Me.btnAcepatar.UseVisualStyleBackColor = False
        '
        'frmPLantillaBusquedas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 577)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ShadowLabel1)
        Me.Name = "frmPLantillaBusquedas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPLantillaBusquedas"
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGridViewFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents ShadowLabel1 As Microsoft.MSDN.Samples.UserControls.ShadowLabelControl.ShadowLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents TxtBusca As System.Windows.Forms.TextBox
    Protected WithEvents DataGridLista As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TextBox1 As System.Windows.Forms.TextBox
    Protected WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAcepatar As System.Windows.Forms.Button
    Friend WithEvents DataGridViewFiltro As System.Windows.Forms.DataGridView
End Class
