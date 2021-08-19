<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGeArticuloItem
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.rbtLista = New System.Windows.Forms.RadioButton()
        Me.rbtManual = New System.Windows.Forms.RadioButton()
        Me.cboItem = New System.Windows.Forms.ComboBox()
        Me.pnlLista = New System.Windows.Forms.Panel()
        Me.pnlManual = New System.Windows.Forms.Panel()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLista.SuspendLayout()
        Me.pnlManual.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgv
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle26
        Me.dgv.Location = New System.Drawing.Point(12, 68)
        Me.dgv.Name = "dgv"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgv.Size = New System.Drawing.Size(350, 159)
        Me.dgv.TabIndex = 2
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(62, 244)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(245, 244)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 32)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(3, 3)
        Me.txtItem.MaxLength = 10
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(145, 20)
        Me.txtItem.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.Location = New System.Drawing.Point(290, 26)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(72, 28)
        Me.btnAgregar.TabIndex = 1
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = Global.INTEGRACION.My.Resources.Resources._1325
        Me.btnEliminar.Location = New System.Drawing.Point(368, 68)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(28, 24)
        Me.btnEliminar.TabIndex = 53
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'rbtLista
        '
        Me.rbtLista.AutoSize = True
        Me.rbtLista.Checked = True
        Me.rbtLista.Location = New System.Drawing.Point(11, 30)
        Me.rbtLista.Name = "rbtLista"
        Me.rbtLista.Size = New System.Drawing.Size(47, 17)
        Me.rbtLista.TabIndex = 54
        Me.rbtLista.TabStop = True
        Me.rbtLista.Text = "Lista"
        Me.rbtLista.UseVisualStyleBackColor = True
        '
        'rbtManual
        '
        Me.rbtManual.AutoSize = True
        Me.rbtManual.Location = New System.Drawing.Point(66, 30)
        Me.rbtManual.Name = "rbtManual"
        Me.rbtManual.Size = New System.Drawing.Size(58, 17)
        Me.rbtManual.TabIndex = 54
        Me.rbtManual.Text = "Código"
        Me.rbtManual.UseVisualStyleBackColor = True
        '
        'cboItem
        '
        Me.cboItem.FormattingEnabled = True
        Me.cboItem.Location = New System.Drawing.Point(3, 3)
        Me.cboItem.Name = "cboItem"
        Me.cboItem.Size = New System.Drawing.Size(147, 21)
        Me.cboItem.TabIndex = 55
        '
        'pnlLista
        '
        Me.pnlLista.Controls.Add(Me.cboItem)
        Me.pnlLista.Location = New System.Drawing.Point(124, 27)
        Me.pnlLista.Name = "pnlLista"
        Me.pnlLista.Size = New System.Drawing.Size(151, 28)
        Me.pnlLista.TabIndex = 56
        '
        'pnlManual
        '
        Me.pnlManual.Controls.Add(Me.txtItem)
        Me.pnlManual.Location = New System.Drawing.Point(124, 27)
        Me.pnlManual.Name = "pnlManual"
        Me.pnlManual.Size = New System.Drawing.Size(151, 28)
        Me.pnlManual.TabIndex = 57
        '
        'frmGeArticuloItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 292)
        Me.Controls.Add(Me.pnlManual)
        Me.Controls.Add(Me.rbtManual)
        Me.Controls.Add(Me.rbtLista)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.pnlLista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGeArticuloItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar SKU"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLista.ResumeLayout(False)
        Me.pnlManual.ResumeLayout(False)
        Me.pnlManual.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents rbtLista As System.Windows.Forms.RadioButton
    Friend WithEvents rbtManual As System.Windows.Forms.RadioButton
    Friend WithEvents cboItem As System.Windows.Forms.ComboBox
    Friend WithEvents pnlLista As System.Windows.Forms.Panel
    Friend WithEvents pnlManual As System.Windows.Forms.Panel
End Class
