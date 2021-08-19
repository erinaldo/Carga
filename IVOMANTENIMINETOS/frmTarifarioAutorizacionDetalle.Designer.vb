<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTarifarioAutorizacionDetalle
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
        Me.txtVolumenMinimo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtFleteMinimoVolumen = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPesoMinimo = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFleteMinimoPeso = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSobre = New System.Windows.Forms.TextBox()
        Me.txtVolumen = New System.Windows.Forms.TextBox()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtBase = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.cboTipoTarifa = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboTipoVisibilidad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtVolumenMinimo
        '
        Me.txtVolumenMinimo.Location = New System.Drawing.Point(640, 107)
        Me.txtVolumenMinimo.Name = "txtVolumenMinimo"
        Me.txtVolumenMinimo.Size = New System.Drawing.Size(100, 20)
        Me.txtVolumenMinimo.TabIndex = 11
        Me.txtVolumenMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(547, 110)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 13)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "Volumen mínimo"
        '
        'txtFleteMinimoVolumen
        '
        Me.txtFleteMinimoVolumen.Location = New System.Drawing.Point(640, 147)
        Me.txtFleteMinimoVolumen.Name = "txtFleteMinimoVolumen"
        Me.txtFleteMinimoVolumen.Size = New System.Drawing.Size(100, 20)
        Me.txtFleteMinimoVolumen.TabIndex = 12
        Me.txtFleteMinimoVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(525, 149)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(110, 13)
        Me.Label20.TabIndex = 82
        Me.Label20.Text = "Flete mínimo volumen"
        '
        'txtPesoMinimo
        '
        Me.txtPesoMinimo.Location = New System.Drawing.Point(640, 31)
        Me.txtPesoMinimo.Name = "txtPesoMinimo"
        Me.txtPesoMinimo.Size = New System.Drawing.Size(100, 20)
        Me.txtPesoMinimo.TabIndex = 9
        Me.txtPesoMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(564, 34)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(68, 13)
        Me.Label17.TabIndex = 80
        Me.Label17.Text = "Peso mínimo"
        '
        'txtFleteMinimoPeso
        '
        Me.txtFleteMinimoPeso.Location = New System.Drawing.Point(640, 68)
        Me.txtFleteMinimoPeso.Name = "txtFleteMinimoPeso"
        Me.txtFleteMinimoPeso.Size = New System.Drawing.Size(100, 20)
        Me.txtFleteMinimoPeso.TabIndex = 10
        Me.txtFleteMinimoPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(542, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 13)
        Me.Label14.TabIndex = 78
        Me.Label14.Text = "Flete mínimo peso"
        '
        'txtSobre
        '
        Me.txtSobre.Location = New System.Drawing.Point(392, 107)
        Me.txtSobre.Name = "txtSobre"
        Me.txtSobre.Size = New System.Drawing.Size(100, 20)
        Me.txtSobre.TabIndex = 7
        Me.txtSobre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVolumen
        '
        Me.txtVolumen.Location = New System.Drawing.Point(392, 68)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(100, 20)
        Me.txtVolumen.TabIndex = 6
        Me.txtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeso
        '
        Me.txtPeso.Location = New System.Drawing.Point(392, 31)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(100, 20)
        Me.txtPeso.TabIndex = 5
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBase
        '
        Me.txtBase.Location = New System.Drawing.Point(392, 147)
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(100, 20)
        Me.txtBase.TabIndex = 8
        Me.txtBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(349, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 73
        Me.Label9.Text = "Sobre"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(336, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Volumen"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(353, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Peso"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(353, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 70
        Me.Label6.Text = "Base"
        '
        'cboOrigen
        '
        Me.cboOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOrigen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.Enabled = False
        Me.cboOrigen.FormattingEnabled = True
        Me.cboOrigen.Location = New System.Drawing.Point(136, 31)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(176, 21)
        Me.cboOrigen.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(59, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 63
        Me.Label10.Text = "Origen"
        '
        'cboDestino
        '
        Me.cboDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDestino.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.FormattingEnabled = True
        Me.cboDestino.Location = New System.Drawing.Point(136, 68)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(176, 21)
        Me.cboDestino.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(59, 71)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 64
        Me.Label11.Text = "Destino"
        '
        'cboProducto
        '
        Me.cboProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(136, 146)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(176, 21)
        Me.cboProducto.TabIndex = 3
        '
        'cboTipoTarifa
        '
        Me.cboTipoTarifa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTipoTarifa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoTarifa.FormattingEnabled = True
        Me.cboTipoTarifa.Location = New System.Drawing.Point(136, 107)
        Me.cboTipoTarifa.Name = "cboTipoTarifa"
        Me.cboTipoTarifa.Size = New System.Drawing.Size(176, 21)
        Me.cboTipoTarifa.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(59, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Producto"
        '
        'cboTipoVisibilidad
        '
        Me.cboTipoVisibilidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTipoVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVisibilidad.FormattingEnabled = True
        Me.cboTipoVisibilidad.Location = New System.Drawing.Point(137, 183)
        Me.cboTipoVisibilidad.Name = "cboTipoVisibilidad"
        Me.cboTipoVisibilidad.Size = New System.Drawing.Size(175, 21)
        Me.cboTipoVisibilidad.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Tipo Tarifa"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(59, 187)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Visibilidad"
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(271, 248)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 38)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(487, 248)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 38)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmTarifarioAutorizacionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(798, 310)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtVolumenMinimo)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtFleteMinimoVolumen)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtPesoMinimo)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtFleteMinimoPeso)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtSobre)
        Me.Controls.Add(Me.txtVolumen)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.txtBase)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboOrigen)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboDestino)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboProducto)
        Me.Controls.Add(Me.cboTipoTarifa)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboTipoVisibilidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label15)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarifarioAutorizacionDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tarifa"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtVolumenMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtFleteMinimoVolumen As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtPesoMinimo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtFleteMinimoPeso As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtSobre As System.Windows.Forms.TextBox
    Friend WithEvents txtVolumen As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtBase As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoTarifa As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboTipoVisibilidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
