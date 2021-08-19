Imports System
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDosCampos
    Inherits INTEGRACION.FrmPlantilla

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDosCampos))
        Me.DataGridLista = New System.Windows.Forms.DataGridView
        Me.txtBuscar = New System.Windows.Forms.TextBox
        Me.txtCampoDos = New System.Windows.Forms.TextBox
        Me.txtCampoUno = New System.Windows.Forms.TextBox
        Me.lblBuscar = New System.Windows.Forms.Label
        Me.lblCampo1 = New System.Windows.Forms.Label
        Me.lblCampo2 = New System.Windows.Forms.Label
        Me.MyImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDepartamento = New System.Windows.Forms.TextBox
        Me.txtIDDepartamento = New System.Windows.Forms.TextBox
        Me.lblPais = New System.Windows.Forms.Label
        Me.cmbPaisDepartamento = New System.Windows.Forms.ComboBox
        Me.cmbPaisProvincia = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtProvincia = New System.Windows.Forms.TextBox
        Me.txtIDProvincia = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbDepartamentoProvincia = New System.Windows.Forms.ComboBox
        Me.cmbDepartamentoDistrito = New System.Windows.Forms.ComboBox
        Me.cmbPaisDistrito = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtDistrito = New System.Windows.Forms.TextBox
        Me.txtIDDistrito = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.cmbProvincia = New System.Windows.Forms.ComboBox
        Me.TimerDegradado = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabMante.SuspendLayout()
        Me.TabLista.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel.SuspendLayout()
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabLista.Controls.Add(Me.lblBuscar)
        Me.TabLista.Controls.Add(Me.txtBuscar)
        Me.TabLista.Controls.SetChildIndex(Me.txtBuscar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lblBuscar, 0)
        Me.TabLista.Controls.SetChildIndex(Me.Panel, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.lblCampo2)
        Me.TabDatos.Controls.Add(Me.lblCampo1)
        Me.TabDatos.Controls.Add(Me.txtCampoDos)
        Me.TabDatos.Controls.Add(Me.txtCampoUno)
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmbPaisDepartamento)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lblPais)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtDepartamento)
        Me.TabPage1.Controls.Add(Me.txtIDDepartamento)
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmbDepartamentoProvincia)
        Me.TabPage2.Controls.Add(Me.cmbPaisProvincia)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtProvincia)
        Me.TabPage2.Controls.Add(Me.txtIDProvincia)
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cmbProvincia)
        Me.TabPage3.Controls.Add(Me.cmbDepartamentoDistrito)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Controls.Add(Me.cmbPaisDistrito)
        Me.TabPage3.Controls.Add(Me.Label7)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.txtDistrito)
        Me.TabPage3.Controls.Add(Me.txtIDDistrito)
        '
        'MyTreeView
        '
        Me.MyTreeView.ImageIndex = 1
        Me.MyTreeView.ImageList = Me.MyImageList
        Me.MyTreeView.LineColor = System.Drawing.Color.Black
        Me.MyTreeView.SelectedImageIndex = 0
        '
        'Panel
        '
        Me.Panel.Controls.Add(Me.DataGridLista)
        '
        'DataGridLista
        '
        Me.DataGridLista.BackgroundColor = System.Drawing.Color.White
        Me.DataGridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridLista.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridLista.Location = New System.Drawing.Point(0, 0)
        Me.DataGridLista.Name = "DataGridLista"
        Me.DataGridLista.Size = New System.Drawing.Size(520, 369)
        Me.DataGridLista.TabIndex = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscar.Location = New System.Drawing.Point(64, 46)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(454, 20)
        Me.txtBuscar.TabIndex = 1
        '
        'txtCampoDos
        '
        Me.txtCampoDos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCampoDos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCampoDos.ForeColor = System.Drawing.Color.Black
        Me.txtCampoDos.Location = New System.Drawing.Point(177, 125)
        Me.txtCampoDos.Name = "txtCampoDos"
        Me.txtCampoDos.Size = New System.Drawing.Size(314, 20)
        Me.txtCampoDos.TabIndex = 2
        '
        'txtCampoUno
        '
        Me.txtCampoUno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCampoUno.Enabled = False
        Me.txtCampoUno.Location = New System.Drawing.Point(177, 99)
        Me.txtCampoUno.Name = "txtCampoUno"
        Me.txtCampoUno.ReadOnly = True
        Me.txtCampoUno.Size = New System.Drawing.Size(119, 20)
        Me.txtCampoUno.TabIndex = 0
        Me.txtCampoUno.TabStop = False
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.BackColor = System.Drawing.Color.Transparent
        Me.lblBuscar.Location = New System.Drawing.Point(12, 48)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(46, 13)
        Me.lblBuscar.TabIndex = 2
        Me.lblBuscar.Text = "Buscar :"
        '
        'lblCampo1
        '
        Me.lblCampo1.BackColor = System.Drawing.Color.Transparent
        Me.lblCampo1.Location = New System.Drawing.Point(15, 100)
        Me.lblCampo1.Name = "lblCampo1"
        Me.lblCampo1.Size = New System.Drawing.Size(143, 18)
        Me.lblCampo1.TabIndex = 10
        Me.lblCampo1.Text = "Codigo Pais :"
        Me.lblCampo1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCampo2
        '
        Me.lblCampo2.BackColor = System.Drawing.Color.Transparent
        Me.lblCampo2.Location = New System.Drawing.Point(15, 126)
        Me.lblCampo2.Name = "lblCampo2"
        Me.lblCampo2.Size = New System.Drawing.Size(143, 18)
        Me.lblCampo2.TabIndex = 10
        Me.lblCampo2.Text = "Nombre Pais :"
        Me.lblCampo2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MyImageList
        '
        Me.MyImageList.ImageStream = CType(resources.GetObject("MyImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.MyImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.MyImageList.Images.SetKeyName(0, "arrow-forward_16.ico")
        Me.MyImageList.Images.SetKeyName(1, "arrow-up_16.ico")
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(28, 153)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 18)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Nombre Departamento :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(28, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(143, 18)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Cod. Departamento :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDepartamento
        '
        Me.txtDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartamento.ForeColor = System.Drawing.Color.Black
        Me.txtDepartamento.Location = New System.Drawing.Point(177, 152)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(314, 20)
        Me.txtDepartamento.TabIndex = 3
        '
        'txtIDDepartamento
        '
        Me.txtIDDepartamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDDepartamento.Enabled = False
        Me.txtIDDepartamento.Location = New System.Drawing.Point(177, 126)
        Me.txtIDDepartamento.Name = "txtIDDepartamento"
        Me.txtIDDepartamento.ReadOnly = True
        Me.txtIDDepartamento.Size = New System.Drawing.Size(119, 20)
        Me.txtIDDepartamento.TabIndex = 0
        Me.txtIDDepartamento.TabStop = False
        '
        'lblPais
        '
        Me.lblPais.BackColor = System.Drawing.Color.Transparent
        Me.lblPais.Location = New System.Drawing.Point(28, 100)
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Size = New System.Drawing.Size(143, 18)
        Me.lblPais.TabIndex = 14
        Me.lblPais.Text = "Pais:"
        Me.lblPais.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPaisDepartamento
        '
        Me.cmbPaisDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaisDepartamento.FormattingEnabled = True
        Me.cmbPaisDepartamento.Location = New System.Drawing.Point(177, 99)
        Me.cmbPaisDepartamento.Name = "cmbPaisDepartamento"
        Me.cmbPaisDepartamento.Size = New System.Drawing.Size(181, 21)
        Me.cmbPaisDepartamento.TabIndex = 1
        '
        'cmbPaisProvincia
        '
        Me.cmbPaisProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaisProvincia.DropDownWidth = 181
        Me.cmbPaisProvincia.FormattingEnabled = True
        Me.cmbPaisProvincia.Location = New System.Drawing.Point(177, 99)
        Me.cmbPaisProvincia.Name = "cmbPaisProvincia"
        Me.cmbPaisProvincia.Size = New System.Drawing.Size(181, 21)
        Me.cmbPaisProvincia.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(28, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(143, 18)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Nombre Provincia :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(28, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 18)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Pais :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(28, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(143, 18)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Cod. Provincia :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProvincia
        '
        Me.txtProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProvincia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvincia.ForeColor = System.Drawing.Color.Black
        Me.txtProvincia.Location = New System.Drawing.Point(177, 179)
        Me.txtProvincia.Name = "txtProvincia"
        Me.txtProvincia.Size = New System.Drawing.Size(314, 20)
        Me.txtProvincia.TabIndex = 4
        '
        'txtIDProvincia
        '
        Me.txtIDProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDProvincia.Enabled = False
        Me.txtIDProvincia.Location = New System.Drawing.Point(177, 153)
        Me.txtIDProvincia.Name = "txtIDProvincia"
        Me.txtIDProvincia.ReadOnly = True
        Me.txtIDProvincia.Size = New System.Drawing.Size(119, 20)
        Me.txtIDProvincia.TabIndex = 0
        Me.txtIDProvincia.TabStop = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(28, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 18)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Departamento :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbDepartamentoProvincia
        '
        Me.cmbDepartamentoProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamentoProvincia.DropDownWidth = 181
        Me.cmbDepartamentoProvincia.FormattingEnabled = True
        Me.cmbDepartamentoProvincia.Location = New System.Drawing.Point(177, 126)
        Me.cmbDepartamentoProvincia.Name = "cmbDepartamentoProvincia"
        Me.cmbDepartamentoProvincia.Size = New System.Drawing.Size(181, 21)
        Me.cmbDepartamentoProvincia.TabIndex = 2
        '
        'cmbDepartamentoDistrito
        '
        Me.cmbDepartamentoDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamentoDistrito.FormattingEnabled = True
        Me.cmbDepartamentoDistrito.Location = New System.Drawing.Point(177, 126)
        Me.cmbDepartamentoDistrito.Name = "cmbDepartamentoDistrito"
        Me.cmbDepartamentoDistrito.Size = New System.Drawing.Size(181, 21)
        Me.cmbDepartamentoDistrito.TabIndex = 2
        '
        'cmbPaisDistrito
        '
        Me.cmbPaisDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaisDistrito.FormattingEnabled = True
        Me.cmbPaisDistrito.Location = New System.Drawing.Point(177, 99)
        Me.cmbPaisDistrito.Name = "cmbPaisDistrito"
        Me.cmbPaisDistrito.Size = New System.Drawing.Size(181, 21)
        Me.cmbPaisDistrito.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(28, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 18)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Departamento :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(28, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(143, 18)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Nombre Distrito :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(28, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 18)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Pais :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(28, 184)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(143, 18)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Cod. Distrito :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDistrito
        '
        Me.txtDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrito.ForeColor = System.Drawing.Color.Black
        Me.txtDistrito.Location = New System.Drawing.Point(177, 209)
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Size = New System.Drawing.Size(314, 20)
        Me.txtDistrito.TabIndex = 5
        '
        'txtIDDistrito
        '
        Me.txtIDDistrito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIDDistrito.Enabled = False
        Me.txtIDDistrito.Location = New System.Drawing.Point(177, 183)
        Me.txtIDDistrito.Name = "txtIDDistrito"
        Me.txtIDDistrito.ReadOnly = True
        Me.txtIDDistrito.Size = New System.Drawing.Size(119, 20)
        Me.txtIDDistrito.TabIndex = 0
        Me.txtIDDistrito.TabStop = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(28, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(143, 18)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Provincia :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbProvincia
        '
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(177, 153)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(181, 21)
        Me.cmbProvincia.TabIndex = 3
        '
        'FrmDosCampos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(782, 623)
        Me.Name = "FrmDosCampos"
        Me.ShowInTaskbar = False
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
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel.ResumeLayout(False)
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridLista As System.Windows.Forms.DataGridView
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Private WithEvents txtCampoDos As System.Windows.Forms.TextBox
    Private WithEvents txtCampoUno As System.Windows.Forms.TextBox
    Friend WithEvents lblBuscar As System.Windows.Forms.Label
    Friend WithEvents lblCampo1 As System.Windows.Forms.Label
    Friend WithEvents lblCampo2 As System.Windows.Forms.Label
    Friend WithEvents MyImageList As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPais As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Private WithEvents txtIDDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents cmbPaisDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDepartamentoProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPaisProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents txtProvincia As System.Windows.Forms.TextBox
    Private WithEvents txtIDProvincia As System.Windows.Forms.TextBox
    Friend WithEvents cmbProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDepartamentoDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbPaisDistrito As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Private WithEvents txtDistrito As System.Windows.Forms.TextBox
    Private WithEvents txtIDDistrito As System.Windows.Forms.TextBox
    Friend WithEvents TimerDegradado As System.Windows.Forms.Timer

End Class
