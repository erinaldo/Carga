<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsignadoNuevo
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
        Me.GrbConsignado = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.LblApePat = New System.Windows.Forms.Label()
        Me.txtapePConsig = New System.Windows.Forms.TextBox()
        Me.txtapeMConsig = New System.Windows.Forms.TextBox()
        Me.lblApeMat = New System.Windows.Forms.Label()
        Me.CboTipoDocumento = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.labnroidentidad = New System.Windows.Forms.Label()
        Me.TxtNumero = New System.Windows.Forms.TextBox()
        Me.LblConsignado = New System.Windows.Forms.Label()
        Me.TxtConsignado = New System.Windows.Forms.TextBox()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.GrbConsignado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrbConsignado
        '
        Me.GrbConsignado.Controls.Add(Me.Label2)
        Me.GrbConsignado.Controls.Add(Me.txtTelefono)
        Me.GrbConsignado.Controls.Add(Me.LblApePat)
        Me.GrbConsignado.Controls.Add(Me.txtapePConsig)
        Me.GrbConsignado.Controls.Add(Me.txtapeMConsig)
        Me.GrbConsignado.Controls.Add(Me.lblApeMat)
        Me.GrbConsignado.Controls.Add(Me.CboTipoDocumento)
        Me.GrbConsignado.Controls.Add(Me.Label18)
        Me.GrbConsignado.Controls.Add(Me.labnroidentidad)
        Me.GrbConsignado.Controls.Add(Me.TxtNumero)
        Me.GrbConsignado.Controls.Add(Me.LblConsignado)
        Me.GrbConsignado.Controls.Add(Me.TxtConsignado)
        Me.GrbConsignado.Location = New System.Drawing.Point(4, 3)
        Me.GrbConsignado.Name = "GrbConsignado"
        Me.GrbConsignado.Size = New System.Drawing.Size(559, 91)
        Me.GrbConsignado.TabIndex = 0
        Me.GrbConsignado.TabStop = False
        Me.GrbConsignado.Text = "Consignado"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(388, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Telefono"
        '
        'txtTelefono
        '
        Me.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTelefono.Location = New System.Drawing.Point(437, 14)
        Me.txtTelefono.MaxLength = 30
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(114, 20)
        Me.txtTelefono.TabIndex = 5
        '
        'LblApePat
        '
        Me.LblApePat.AutoSize = True
        Me.LblApePat.Location = New System.Drawing.Point(6, 68)
        Me.LblApePat.Name = "LblApePat"
        Me.LblApePat.Size = New System.Drawing.Size(55, 13)
        Me.LblApePat.TabIndex = 8
        Me.LblApePat.Text = "Apell. Pat."
        '
        'txtapePConsig
        '
        Me.txtapePConsig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapePConsig.Location = New System.Drawing.Point(66, 65)
        Me.txtapePConsig.MaxLength = 40
        Me.txtapePConsig.Name = "txtapePConsig"
        Me.txtapePConsig.Size = New System.Drawing.Size(180, 20)
        Me.txtapePConsig.TabIndex = 9
        '
        'txtapeMConsig
        '
        Me.txtapeMConsig.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtapeMConsig.Location = New System.Drawing.Point(371, 65)
        Me.txtapeMConsig.MaxLength = 40
        Me.txtapeMConsig.Name = "txtapeMConsig"
        Me.txtapeMConsig.Size = New System.Drawing.Size(180, 20)
        Me.txtapeMConsig.TabIndex = 11
        '
        'lblApeMat
        '
        Me.lblApeMat.AutoSize = True
        Me.lblApeMat.BackColor = System.Drawing.Color.Transparent
        Me.lblApeMat.Location = New System.Drawing.Point(310, 68)
        Me.lblApeMat.Name = "lblApeMat"
        Me.lblApeMat.Size = New System.Drawing.Size(57, 13)
        Me.lblApeMat.TabIndex = 10
        Me.lblApeMat.Text = "Apell. Mat."
        Me.lblApeMat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CboTipoDocumento
        '
        Me.CboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTipoDocumento.FormattingEnabled = True
        Me.CboTipoDocumento.Location = New System.Drawing.Point(66, 14)
        Me.CboTipoDocumento.Name = "CboTipoDocumento"
        Me.CboTipoDocumento.Size = New System.Drawing.Size(127, 21)
        Me.CboTipoDocumento.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 17)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Tipo Doc."
        '
        'labnroidentidad
        '
        Me.labnroidentidad.AutoSize = True
        Me.labnroidentidad.Location = New System.Drawing.Point(211, 17)
        Me.labnroidentidad.Name = "labnroidentidad"
        Me.labnroidentidad.Size = New System.Drawing.Size(45, 13)
        Me.labnroidentidad.TabIndex = 2
        Me.labnroidentidad.Text = "Nº Doc."
        '
        'TxtNumero
        '
        Me.TxtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNumero.Location = New System.Drawing.Point(268, 14)
        Me.TxtNumero.MaxLength = 8
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(117, 20)
        Me.TxtNumero.TabIndex = 3
        '
        'LblConsignado
        '
        Me.LblConsignado.AutoSize = True
        Me.LblConsignado.Location = New System.Drawing.Point(6, 42)
        Me.LblConsignado.Name = "LblConsignado"
        Me.LblConsignado.Size = New System.Drawing.Size(49, 13)
        Me.LblConsignado.TabIndex = 6
        Me.LblConsignado.Text = "Nombres"
        '
        'TxtConsignado
        '
        Me.TxtConsignado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConsignado.Location = New System.Drawing.Point(66, 40)
        Me.TxtConsignado.MaxLength = 80
        Me.TxtConsignado.Name = "TxtConsignado"
        Me.TxtConsignado.Size = New System.Drawing.Size(485, 20)
        Me.TxtConsignado.TabIndex = 7
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancelar.Location = New System.Drawing.Point(487, 101)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(76, 28)
        Me.BtnCancelar.TabIndex = 2
        Me.BtnCancelar.Text = "&Cancelar"
        Me.BtnCancelar.UseVisualStyleBackColor = True
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAceptar.Location = New System.Drawing.Point(404, 101)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(77, 28)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'FrmConsignadoNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 136)
        Me.Controls.Add(Me.BtnCancelar)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Controls.Add(Me.GrbConsignado)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConsignadoNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consignado"
        Me.GrbConsignado.ResumeLayout(False)
        Me.GrbConsignado.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrbConsignado As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents LblApePat As System.Windows.Forms.Label
    Friend WithEvents txtapePConsig As System.Windows.Forms.TextBox
    Friend WithEvents txtapeMConsig As System.Windows.Forms.TextBox
    Friend WithEvents lblApeMat As System.Windows.Forms.Label
    Friend WithEvents CboTipoDocumento As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents labnroidentidad As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents LblConsignado As System.Windows.Forms.Label
    Friend WithEvents TxtConsignado As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
End Class
