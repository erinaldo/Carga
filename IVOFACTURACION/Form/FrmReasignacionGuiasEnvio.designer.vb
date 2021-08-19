Imports System
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReasignacionGuiasEnvio
    Inherits INTEGRACION.FrmPlantillaFacturacion

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReasignacionGuiasEnvio))
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.ListBox2 = New System.Windows.Forms.ListBox
        Me.btnTodoIzquierda = New System.Windows.Forms.Button
        Me.btnTodoDerecha = New System.Windows.Forms.Button
        Me.btnIzquierda = New System.Windows.Forms.Button
        Me.btnDerecha = New System.Windows.Forms.Button
        Me.btnRestableder = New System.Windows.Forms.Button
        Me.btnPreFacturaInicial = New System.Windows.Forms.Button
        Me.cmbPreFacturaInicial = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbPreFacturaFinal = New System.Windows.Forms.ComboBox
        Me.btnPreFacturaFinal = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.Panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        '
        'SplitContainer2
        '
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.TextBox3)
        Me.TabLista.Controls.Add(Me.TextBox4)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.Add(Me.Label4)
        Me.TabLista.Controls.Add(Me.TextBox2)
        Me.TabLista.Controls.Add(Me.TextBox1)
        Me.TabLista.Controls.Add(Me.btnRestableder)
        Me.TabLista.Controls.Add(Me.btnPreFacturaFinal)
        Me.TabLista.Controls.Add(Me.btnPreFacturaInicial)
        Me.TabLista.Controls.Add(Me.cmbPreFacturaFinal)
        Me.TabLista.Controls.Add(Me.Label1)
        Me.TabLista.Controls.Add(Me.cmbPreFacturaInicial)
        Me.TabLista.Controls.Add(Me.Label2)
        Me.TabLista.Controls.Add(Me.Label12)
        Me.TabLista.Controls.Add(Me.Label15)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label15, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label12, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbPreFacturaInicial, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.cmbPreFacturaFinal, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnPreFacturaInicial, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnPreFacturaFinal, 0)
        Me.TabLista.Controls.SetChildIndex(Me.btnRestableder, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TextBox1, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TextBox2, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TextBox4, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TextBox3, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage1
        '
        Me.TabPage1.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage2
        '
        Me.TabPage2.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage3
        '
        Me.TabPage3.Size = New System.Drawing.Size(734, 464)
        '
        'TabPage4
        '
        Me.TabPage4.Size = New System.Drawing.Size(734, 464)
        '
        'MyTreeView
        '
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        '
        'Panel
        '
        Me.Panel.BackColor = System.Drawing.Color.Transparent
        Me.Panel.Controls.Add(Me.btnTodoIzquierda)
        Me.Panel.Controls.Add(Me.btnTodoDerecha)
        Me.Panel.Controls.Add(Me.btnIzquierda)
        Me.Panel.Controls.Add(Me.btnDerecha)
        Me.Panel.Controls.Add(Me.ListBox2)
        Me.Panel.Controls.Add(Me.ListBox1)
        Me.Panel.Location = New System.Drawing.Point(15, 104)
        Me.Panel.Size = New System.Drawing.Size(705, 343)
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(300, 342)
        Me.ListBox1.TabIndex = 0
        '
        'ListBox2
        '
        Me.ListBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(405, 0)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(300, 342)
        Me.ListBox2.TabIndex = 1
        '
        'btnTodoIzquierda
        '
        Me.btnTodoIzquierda.BackColor = System.Drawing.Color.Transparent
        Me.btnTodoIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTodoIzquierda.Image = CType(resources.GetObject("btnTodoIzquierda.Image"), System.Drawing.Image)
        Me.btnTodoIzquierda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodoIzquierda.Location = New System.Drawing.Point(334, 221)
        Me.btnTodoIzquierda.Name = "btnTodoIzquierda"
        Me.btnTodoIzquierda.Size = New System.Drawing.Size(35, 30)
        Me.btnTodoIzquierda.TabIndex = 132
        Me.btnTodoIzquierda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodoIzquierda.UseVisualStyleBackColor = False
        '
        'btnTodoDerecha
        '
        Me.btnTodoDerecha.BackColor = System.Drawing.Color.Transparent
        Me.btnTodoDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTodoDerecha.Image = CType(resources.GetObject("btnTodoDerecha.Image"), System.Drawing.Image)
        Me.btnTodoDerecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTodoDerecha.Location = New System.Drawing.Point(334, 175)
        Me.btnTodoDerecha.Name = "btnTodoDerecha"
        Me.btnTodoDerecha.Size = New System.Drawing.Size(35, 30)
        Me.btnTodoDerecha.TabIndex = 133
        Me.btnTodoDerecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTodoDerecha.UseVisualStyleBackColor = False
        '
        'btnIzquierda
        '
        Me.btnIzquierda.BackColor = System.Drawing.Color.Transparent
        Me.btnIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIzquierda.Image = CType(resources.GetObject("btnIzquierda.Image"), System.Drawing.Image)
        Me.btnIzquierda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIzquierda.Location = New System.Drawing.Point(334, 129)
        Me.btnIzquierda.Name = "btnIzquierda"
        Me.btnIzquierda.Size = New System.Drawing.Size(35, 30)
        Me.btnIzquierda.TabIndex = 130
        Me.btnIzquierda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIzquierda.UseVisualStyleBackColor = False
        '
        'btnDerecha
        '
        Me.btnDerecha.BackColor = System.Drawing.Color.Transparent
        Me.btnDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDerecha.Image = CType(resources.GetObject("btnDerecha.Image"), System.Drawing.Image)
        Me.btnDerecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDerecha.Location = New System.Drawing.Point(334, 83)
        Me.btnDerecha.Name = "btnDerecha"
        Me.btnDerecha.Size = New System.Drawing.Size(35, 30)
        Me.btnDerecha.TabIndex = 131
        Me.btnDerecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDerecha.UseVisualStyleBackColor = False
        '
        'btnRestableder
        '
        Me.btnRestableder.BackColor = System.Drawing.Color.Transparent
        Me.btnRestableder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestableder.Image = CType(resources.GetObject("btnRestableder.Image"), System.Drawing.Image)
        Me.btnRestableder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRestableder.Location = New System.Drawing.Point(621, 3)
        Me.btnRestableder.Name = "btnRestableder"
        Me.btnRestableder.Size = New System.Drawing.Size(99, 30)
        Me.btnRestableder.TabIndex = 145
        Me.btnRestableder.Text = "&Restablecer"
        Me.btnRestableder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRestableder.UseVisualStyleBackColor = False
        '
        'btnPreFacturaInicial
        '
        Me.btnPreFacturaInicial.BackColor = System.Drawing.Color.Transparent
        Me.btnPreFacturaInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreFacturaInicial.Image = CType(resources.GetObject("btnPreFacturaInicial.Image"), System.Drawing.Image)
        Me.btnPreFacturaInicial.Location = New System.Drawing.Point(292, 74)
        Me.btnPreFacturaInicial.Name = "btnPreFacturaInicial"
        Me.btnPreFacturaInicial.Size = New System.Drawing.Size(23, 24)
        Me.btnPreFacturaInicial.TabIndex = 144
        Me.btnPreFacturaInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreFacturaInicial.UseVisualStyleBackColor = False
        '
        'cmbPreFacturaInicial
        '
        Me.cmbPreFacturaInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPreFacturaInicial.FormattingEnabled = True
        Me.cmbPreFacturaInicial.Location = New System.Drawing.Point(15, 74)
        Me.cmbPreFacturaInicial.Name = "cmbPreFacturaInicial"
        Me.cmbPreFacturaInicial.Size = New System.Drawing.Size(271, 21)
        Me.cmbPreFacturaInicial.TabIndex = 138
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(15, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 137
        Me.Label12.Text = "Pre Factura Inicial :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Location = New System.Drawing.Point(15, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 136
        Me.Label15.Text = "Código :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(420, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Pre Factura Final :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPreFacturaFinal
        '
        Me.cmbPreFacturaFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPreFacturaFinal.FormattingEnabled = True
        Me.cmbPreFacturaFinal.Location = New System.Drawing.Point(420, 74)
        Me.cmbPreFacturaFinal.Name = "cmbPreFacturaFinal"
        Me.cmbPreFacturaFinal.Size = New System.Drawing.Size(271, 21)
        Me.cmbPreFacturaFinal.TabIndex = 138
        '
        'btnPreFacturaFinal
        '
        Me.btnPreFacturaFinal.BackColor = System.Drawing.Color.Transparent
        Me.btnPreFacturaFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreFacturaFinal.Image = CType(resources.GetObject("btnPreFacturaFinal.Image"), System.Drawing.Image)
        Me.btnPreFacturaFinal.Location = New System.Drawing.Point(697, 74)
        Me.btnPreFacturaFinal.Name = "btnPreFacturaFinal"
        Me.btnPreFacturaFinal.Size = New System.Drawing.Size(23, 24)
        Me.btnPreFacturaFinal.TabIndex = 144
        Me.btnPreFacturaFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreFacturaFinal.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(61, 37)
        Me.TextBox1.MaxLength = 11
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(92, 20)
        Me.TextBox1.TabIndex = 146
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(158, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Cliente :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(205, 37)
        Me.TextBox2.MaxLength = 200
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(156, 20)
        Me.TextBox2.TabIndex = 146
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Location = New System.Drawing.Point(564, 36)
        Me.TextBox3.MaxLength = 200
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(156, 20)
        Me.TextBox3.TabIndex = 149
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Location = New System.Drawing.Point(420, 36)
        Me.TextBox4.MaxLength = 11
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(92, 20)
        Me.TextBox4.TabIndex = 150
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(517, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Cliente :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(374, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Código :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmReasignacionGuiasEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmReasignacionGuiasEnvio"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TabMante.ResumeLayout(False)
        Me.TabLista.ResumeLayout(False)
        Me.TabLista.PerformLayout()
        Me.Panel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents btnTodoIzquierda As System.Windows.Forms.Button
    Friend WithEvents btnTodoDerecha As System.Windows.Forms.Button
    Friend WithEvents btnIzquierda As System.Windows.Forms.Button
    Friend WithEvents btnDerecha As System.Windows.Forms.Button
    Friend WithEvents btnRestableder As System.Windows.Forms.Button
    Friend WithEvents btnPreFacturaFinal As System.Windows.Forms.Button
    Friend WithEvents btnPreFacturaInicial As System.Windows.Forms.Button
    Friend WithEvents cmbPreFacturaFinal As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPreFacturaInicial As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
