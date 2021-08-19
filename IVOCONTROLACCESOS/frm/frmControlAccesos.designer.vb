<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmControlAccesos
    Inherits INTEGRACION.FrmPlantillaJ

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControlAccesos))
        Me.GroupBoxTOOL = New System.Windows.Forms.GroupBox
        Me.chboxEMAIL = New System.Windows.Forms.CheckBox
        Me.chboxImprimir = New System.Windows.Forms.CheckBox
        Me.chboxExportarPDF = New System.Windows.Forms.CheckBox
        Me.chboxExportarExcel = New System.Windows.Forms.CheckBox
        Me.chboxExportarWork = New System.Windows.Forms.CheckBox
        Me.chboxAyuda = New System.Windows.Forms.CheckBox
        Me.chboxEliminar = New System.Windows.Forms.CheckBox
        Me.chboxCancelar = New System.Windows.Forms.CheckBox
        Me.chboxGrabar = New System.Windows.Forms.CheckBox
        Me.chboxEditar = New System.Windows.Forms.CheckBox
        Me.chboxNuevo = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chboxTodos = New System.Windows.Forms.CheckBox
        Me.GroupBoxTAB = New System.Windows.Forms.GroupBox
        Me.ChboxTab10 = New System.Windows.Forms.CheckBox
        Me.ChboxTab09 = New System.Windows.Forms.CheckBox
        Me.ChboxTab08 = New System.Windows.Forms.CheckBox
        Me.ChboxTab07 = New System.Windows.Forms.CheckBox
        Me.ChboxTab06 = New System.Windows.Forms.CheckBox
        Me.ChboxTab05 = New System.Windows.Forms.CheckBox
        Me.ChboxTab04 = New System.Windows.Forms.CheckBox
        Me.ChboxTab03 = New System.Windows.Forms.CheckBox
        Me.ChboxTab02 = New System.Windows.Forms.CheckBox
        Me.ChboxTab01 = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ChBoxTab = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbFrm = New System.Windows.Forms.Label
        Me.lbRol = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnFrm = New System.Windows.Forms.Button
        Me.btnFiltroRoles = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbFrmRol = New System.Windows.Forms.Label
        Me.DataGridViewRolFrm = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DataGridViewRoles = New System.Windows.Forms.DataGridView
        Me.iIDROL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.iROL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnEditar = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxTOOL.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBoxTAB.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridViewRolFrm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DataGridViewRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 623)
        '
        'ShadowLabel1
        '
        Me.ShadowLabel1.Size = New System.Drawing.Size(778, 33)
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Size = New System.Drawing.Size(778, 557)
        Me.SplitContainer2.SplitterDistance = 213
        '
        'TabLista
        '
        Me.TabLista.Controls.Add(Me.DataGridViewRolFrm)
        Me.TabLista.Controls.Add(Me.lbFrmRol)
        Me.TabLista.Controls.Add(Me.Label3)
        Me.TabLista.Controls.SetChildIndex(Me.Label3, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridLista, 0)
        Me.TabLista.Controls.SetChildIndex(Me.TxtBusca, 0)
        Me.TabLista.Controls.SetChildIndex(Me.lbFrmRol, 0)
        Me.TabLista.Controls.SetChildIndex(Me.DataGridViewRolFrm, 0)
        '
        'TabDatos
        '
        Me.TabDatos.Controls.Add(Me.DataGridViewRoles)
        Me.TabDatos.Controls.Add(Me.btnEliminar)
        Me.TabDatos.Controls.Add(Me.btnGrabar)
        Me.TabDatos.Controls.Add(Me.btnEditar)
        Me.TabDatos.Controls.Add(Me.btnFiltroRoles)
        Me.TabDatos.Controls.Add(Me.btnFrm)
        Me.TabDatos.Controls.Add(Me.lbRol)
        Me.TabDatos.Controls.Add(Me.Label4)
        Me.TabDatos.Controls.Add(Me.lbFrm)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.GroupBox3)
        Me.TabDatos.Controls.Add(Me.GroupBoxTAB)
        Me.TabDatos.Controls.Add(Me.GroupBox2)
        Me.TabDatos.Controls.Add(Me.GroupBoxTOOL)
        '
        'DataGridLista
        '
        Me.DataGridLista.Location = New System.Drawing.Point(6, 451)
        Me.DataGridLista.Size = New System.Drawing.Size(522, 21)
        '
        'TxtBusca
        '
        Me.TxtBusca.Location = New System.Drawing.Point(6, 34)
        Me.TxtBusca.Size = New System.Drawing.Size(174, 20)
        '
        'TreeLista
        '
        Me.TreeLista.LineColor = System.Drawing.Color.Black
        Me.TreeLista.Location = New System.Drawing.Point(3, 3)
        Me.TreeLista.Size = New System.Drawing.Size(205, 518)
        '
        'GroupBoxTOOL
        '
        Me.GroupBoxTOOL.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxTOOL.Controls.Add(Me.chboxEMAIL)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxImprimir)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxExportarPDF)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxExportarExcel)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxExportarWork)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxAyuda)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxEliminar)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxCancelar)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxGrabar)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxEditar)
        Me.GroupBoxTOOL.Controls.Add(Me.chboxNuevo)
        Me.GroupBoxTOOL.Location = New System.Drawing.Point(6, 83)
        Me.GroupBoxTOOL.Name = "GroupBoxTOOL"
        Me.GroupBoxTOOL.Size = New System.Drawing.Size(522, 94)
        Me.GroupBoxTOOL.TabIndex = 0
        Me.GroupBoxTOOL.TabStop = False
        Me.GroupBoxTOOL.Text = "Control TOOL BAR"
        '
        'chboxEMAIL
        '
        Me.chboxEMAIL.AutoSize = True
        Me.chboxEMAIL.Location = New System.Drawing.Point(318, 42)
        Me.chboxEMAIL.Name = "chboxEMAIL"
        Me.chboxEMAIL.Size = New System.Drawing.Size(58, 17)
        Me.chboxEMAIL.TabIndex = 10
        Me.chboxEMAIL.Text = "E  Mail"
        Me.chboxEMAIL.UseVisualStyleBackColor = True
        '
        'chboxImprimir
        '
        Me.chboxImprimir.AutoSize = True
        Me.chboxImprimir.Location = New System.Drawing.Point(318, 19)
        Me.chboxImprimir.Name = "chboxImprimir"
        Me.chboxImprimir.Size = New System.Drawing.Size(61, 17)
        Me.chboxImprimir.TabIndex = 9
        Me.chboxImprimir.Text = "Imprimir"
        Me.chboxImprimir.UseVisualStyleBackColor = True
        '
        'chboxExportarPDF
        '
        Me.chboxExportarPDF.AutoSize = True
        Me.chboxExportarPDF.Location = New System.Drawing.Point(218, 65)
        Me.chboxExportarPDF.Name = "chboxExportarPDF"
        Me.chboxExportarPDF.Size = New System.Drawing.Size(89, 17)
        Me.chboxExportarPDF.TabIndex = 8
        Me.chboxExportarPDF.Text = "Exportar PDF"
        Me.chboxExportarPDF.UseVisualStyleBackColor = True
        '
        'chboxExportarExcel
        '
        Me.chboxExportarExcel.AutoSize = True
        Me.chboxExportarExcel.Location = New System.Drawing.Point(218, 42)
        Me.chboxExportarExcel.Name = "chboxExportarExcel"
        Me.chboxExportarExcel.Size = New System.Drawing.Size(94, 17)
        Me.chboxExportarExcel.TabIndex = 7
        Me.chboxExportarExcel.Text = "Exportar Excel"
        Me.chboxExportarExcel.UseVisualStyleBackColor = True
        '
        'chboxExportarWork
        '
        Me.chboxExportarWork.AutoSize = True
        Me.chboxExportarWork.Location = New System.Drawing.Point(218, 19)
        Me.chboxExportarWork.Name = "chboxExportarWork"
        Me.chboxExportarWork.Size = New System.Drawing.Size(94, 17)
        Me.chboxExportarWork.TabIndex = 6
        Me.chboxExportarWork.Text = "Exportar Work"
        Me.chboxExportarWork.UseVisualStyleBackColor = True
        '
        'chboxAyuda
        '
        Me.chboxAyuda.AutoSize = True
        Me.chboxAyuda.Location = New System.Drawing.Point(114, 65)
        Me.chboxAyuda.Name = "chboxAyuda"
        Me.chboxAyuda.Size = New System.Drawing.Size(56, 17)
        Me.chboxAyuda.TabIndex = 5
        Me.chboxAyuda.Text = "Ayuda"
        Me.chboxAyuda.UseVisualStyleBackColor = True
        '
        'chboxEliminar
        '
        Me.chboxEliminar.AutoSize = True
        Me.chboxEliminar.Location = New System.Drawing.Point(114, 42)
        Me.chboxEliminar.Name = "chboxEliminar"
        Me.chboxEliminar.Size = New System.Drawing.Size(62, 17)
        Me.chboxEliminar.TabIndex = 4
        Me.chboxEliminar.Text = "Eliminar"
        Me.chboxEliminar.UseVisualStyleBackColor = True
        '
        'chboxCancelar
        '
        Me.chboxCancelar.AutoSize = True
        Me.chboxCancelar.Location = New System.Drawing.Point(114, 19)
        Me.chboxCancelar.Name = "chboxCancelar"
        Me.chboxCancelar.Size = New System.Drawing.Size(68, 17)
        Me.chboxCancelar.TabIndex = 3
        Me.chboxCancelar.Text = "Cancelar"
        Me.chboxCancelar.UseVisualStyleBackColor = True
        '
        'chboxGrabar
        '
        Me.chboxGrabar.AutoSize = True
        Me.chboxGrabar.Location = New System.Drawing.Point(17, 65)
        Me.chboxGrabar.Name = "chboxGrabar"
        Me.chboxGrabar.Size = New System.Drawing.Size(58, 17)
        Me.chboxGrabar.TabIndex = 2
        Me.chboxGrabar.Text = "Grabar"
        Me.chboxGrabar.UseVisualStyleBackColor = True
        '
        'chboxEditar
        '
        Me.chboxEditar.AutoSize = True
        Me.chboxEditar.Location = New System.Drawing.Point(17, 42)
        Me.chboxEditar.Name = "chboxEditar"
        Me.chboxEditar.Size = New System.Drawing.Size(53, 17)
        Me.chboxEditar.TabIndex = 1
        Me.chboxEditar.Text = "Editar"
        Me.chboxEditar.UseVisualStyleBackColor = True
        '
        'chboxNuevo
        '
        Me.chboxNuevo.AutoSize = True
        Me.chboxNuevo.Location = New System.Drawing.Point(17, 19)
        Me.chboxNuevo.Name = "chboxNuevo"
        Me.chboxNuevo.Size = New System.Drawing.Size(58, 17)
        Me.chboxNuevo.TabIndex = 0
        Me.chboxNuevo.Text = "Nuevo"
        Me.chboxNuevo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.chboxTodos)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Location = New System.Drawing.Point(6, 39)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 38)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'chboxTodos
        '
        Me.chboxTodos.AutoSize = True
        Me.chboxTodos.ForeColor = System.Drawing.Color.Maroon
        Me.chboxTodos.Location = New System.Drawing.Point(6, 13)
        Me.chboxTodos.Name = "chboxTodos"
        Me.chboxTodos.Size = New System.Drawing.Size(115, 17)
        Me.chboxTodos.TabIndex = 10
        Me.chboxTodos.Text = "Seleccionar Todos"
        Me.chboxTodos.UseVisualStyleBackColor = True
        '
        'GroupBoxTAB
        '
        Me.GroupBoxTAB.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab10)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab09)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab08)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab07)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab06)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab05)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab04)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab03)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab02)
        Me.GroupBoxTAB.Controls.Add(Me.ChboxTab01)
        Me.GroupBoxTAB.Location = New System.Drawing.Point(6, 219)
        Me.GroupBoxTAB.Name = "GroupBoxTAB"
        Me.GroupBoxTAB.Size = New System.Drawing.Size(522, 94)
        Me.GroupBoxTAB.TabIndex = 2
        Me.GroupBoxTAB.TabStop = False
        Me.GroupBoxTAB.Text = "Control TAB"
        '
        'ChboxTab10
        '
        Me.ChboxTab10.AutoSize = True
        Me.ChboxTab10.Location = New System.Drawing.Point(294, 21)
        Me.ChboxTab10.Name = "ChboxTab10"
        Me.ChboxTab10.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab10.TabIndex = 9
        Me.ChboxTab10.Text = "TAB 10"
        Me.ChboxTab10.UseVisualStyleBackColor = True
        '
        'ChboxTab09
        '
        Me.ChboxTab09.AutoSize = True
        Me.ChboxTab09.Location = New System.Drawing.Point(218, 65)
        Me.ChboxTab09.Name = "ChboxTab09"
        Me.ChboxTab09.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab09.TabIndex = 8
        Me.ChboxTab09.Text = "TAB 09"
        Me.ChboxTab09.UseVisualStyleBackColor = True
        '
        'ChboxTab08
        '
        Me.ChboxTab08.AutoSize = True
        Me.ChboxTab08.Location = New System.Drawing.Point(218, 42)
        Me.ChboxTab08.Name = "ChboxTab08"
        Me.ChboxTab08.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab08.TabIndex = 7
        Me.ChboxTab08.Text = "TAB 08"
        Me.ChboxTab08.UseVisualStyleBackColor = True
        '
        'ChboxTab07
        '
        Me.ChboxTab07.AutoSize = True
        Me.ChboxTab07.Location = New System.Drawing.Point(218, 19)
        Me.ChboxTab07.Name = "ChboxTab07"
        Me.ChboxTab07.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab07.TabIndex = 6
        Me.ChboxTab07.Text = "TAB 07"
        Me.ChboxTab07.UseVisualStyleBackColor = True
        '
        'ChboxTab06
        '
        Me.ChboxTab06.AutoSize = True
        Me.ChboxTab06.Location = New System.Drawing.Point(114, 65)
        Me.ChboxTab06.Name = "ChboxTab06"
        Me.ChboxTab06.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab06.TabIndex = 5
        Me.ChboxTab06.Text = "TAB 06"
        Me.ChboxTab06.UseVisualStyleBackColor = True
        '
        'ChboxTab05
        '
        Me.ChboxTab05.AutoSize = True
        Me.ChboxTab05.Location = New System.Drawing.Point(124, 49)
        Me.ChboxTab05.Name = "ChboxTab05"
        Me.ChboxTab05.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab05.TabIndex = 4
        Me.ChboxTab05.Text = "TAB 05"
        Me.ChboxTab05.UseVisualStyleBackColor = True
        '
        'ChboxTab04
        '
        Me.ChboxTab04.AutoSize = True
        Me.ChboxTab04.Location = New System.Drawing.Point(114, 19)
        Me.ChboxTab04.Name = "ChboxTab04"
        Me.ChboxTab04.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab04.TabIndex = 3
        Me.ChboxTab04.Text = "TAB 04"
        Me.ChboxTab04.UseVisualStyleBackColor = True
        '
        'ChboxTab03
        '
        Me.ChboxTab03.AutoSize = True
        Me.ChboxTab03.Location = New System.Drawing.Point(17, 65)
        Me.ChboxTab03.Name = "ChboxTab03"
        Me.ChboxTab03.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab03.TabIndex = 2
        Me.ChboxTab03.Text = "TAB 03"
        Me.ChboxTab03.UseVisualStyleBackColor = True
        '
        'ChboxTab02
        '
        Me.ChboxTab02.AutoSize = True
        Me.ChboxTab02.Location = New System.Drawing.Point(17, 42)
        Me.ChboxTab02.Name = "ChboxTab02"
        Me.ChboxTab02.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab02.TabIndex = 1
        Me.ChboxTab02.Text = "TAB 02"
        Me.ChboxTab02.UseVisualStyleBackColor = True
        '
        'ChboxTab01
        '
        Me.ChboxTab01.AutoSize = True
        Me.ChboxTab01.Location = New System.Drawing.Point(17, 19)
        Me.ChboxTab01.Name = "ChboxTab01"
        Me.ChboxTab01.Size = New System.Drawing.Size(62, 17)
        Me.ChboxTab01.TabIndex = 0
        Me.ChboxTab01.Text = "TAB 01"
        Me.ChboxTab01.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.ChBoxTab)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Location = New System.Drawing.Point(6, 178)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(522, 38)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'ChBoxTab
        '
        Me.ChBoxTab.AutoSize = True
        Me.ChBoxTab.ForeColor = System.Drawing.Color.Maroon
        Me.ChBoxTab.Location = New System.Drawing.Point(6, 13)
        Me.ChBoxTab.Name = "ChBoxTab"
        Me.ChBoxTab.Size = New System.Drawing.Size(115, 17)
        Me.ChBoxTab.TabIndex = 10
        Me.ChBoxTab.Text = "Seleccionar Todos"
        Me.ChBoxTab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(9, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "FRM:"
        '
        'lbFrm
        '
        Me.lbFrm.AutoSize = True
        Me.lbFrm.BackColor = System.Drawing.Color.Transparent
        Me.lbFrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFrm.ForeColor = System.Drawing.Color.Maroon
        Me.lbFrm.Location = New System.Drawing.Point(48, 20)
        Me.lbFrm.Name = "lbFrm"
        Me.lbFrm.Size = New System.Drawing.Size(19, 13)
        Me.lbFrm.TabIndex = 5
        Me.lbFrm.Text = "..."
        '
        'lbRol
        '
        Me.lbRol.AutoSize = True
        Me.lbRol.BackColor = System.Drawing.Color.Transparent
        Me.lbRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRol.ForeColor = System.Drawing.Color.Maroon
        Me.lbRol.Location = New System.Drawing.Point(47, 325)
        Me.lbRol.Name = "lbRol"
        Me.lbRol.Size = New System.Drawing.Size(19, 13)
        Me.lbRol.TabIndex = 9
        Me.lbRol.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(9, 325)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "ROL:"
        '
        'btnFrm
        '
        Me.btnFrm.BackColor = System.Drawing.Color.Transparent
        Me.btnFrm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFrm.ForeColor = System.Drawing.Color.Maroon
        Me.btnFrm.Location = New System.Drawing.Point(390, 16)
        Me.btnFrm.Name = "btnFrm"
        Me.btnFrm.Size = New System.Drawing.Size(40, 21)
        Me.btnFrm.TabIndex = 11
        Me.btnFrm.Text = "..."
        Me.btnFrm.UseVisualStyleBackColor = False
        '
        'btnFiltroRoles
        '
        Me.btnFiltroRoles.BackColor = System.Drawing.Color.Transparent
        Me.btnFiltroRoles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltroRoles.ForeColor = System.Drawing.Color.Maroon
        Me.btnFiltroRoles.Location = New System.Drawing.Point(300, 325)
        Me.btnFiltroRoles.Name = "btnFiltroRoles"
        Me.btnFiltroRoles.Size = New System.Drawing.Size(40, 21)
        Me.btnFiltroRoles.TabIndex = 12
        Me.btnFiltroRoles.Text = "..."
        Me.btnFiltroRoles.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(208, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "FRM : "
        '
        'lbFrmRol
        '
        Me.lbFrmRol.AutoSize = True
        Me.lbFrmRol.BackColor = System.Drawing.Color.Transparent
        Me.lbFrmRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFrmRol.ForeColor = System.Drawing.Color.Maroon
        Me.lbFrmRol.Location = New System.Drawing.Point(253, 37)
        Me.lbFrmRol.Name = "lbFrmRol"
        Me.lbFrmRol.Size = New System.Drawing.Size(45, 13)
        Me.lbFrmRol.TabIndex = 10
        Me.lbFrmRol.Text = "FRM : "
        '
        'DataGridViewRolFrm
        '
        Me.DataGridViewRolFrm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRolFrm.Location = New System.Drawing.Point(6, 69)
        Me.DataGridViewRolFrm.MultiSelect = False
        Me.DataGridViewRolFrm.Name = "DataGridViewRolFrm"
        Me.DataGridViewRolFrm.ReadOnly = True
        Me.DataGridViewRolFrm.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridViewRolFrm.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewRolFrm.Size = New System.Drawing.Size(522, 394)
        Me.DataGridViewRolFrm.TabIndex = 11
        Me.DataGridViewRolFrm.VirtualMode = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem, Me.EditarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 48)
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'DataGridViewRoles
        '
        Me.DataGridViewRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRoles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iIDROL, Me.iROL})
        Me.DataGridViewRoles.Location = New System.Drawing.Point(12, 347)
        Me.DataGridViewRoles.Name = "DataGridViewRoles"
        Me.DataGridViewRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewRoles.Size = New System.Drawing.Size(516, 126)
        Me.DataGridViewRoles.TabIndex = 13
        '
        'iIDROL
        '
        Me.iIDROL.HeaderText = "IDROL"
        Me.iIDROL.Name = "iIDROL"
        '
        'iROL
        '
        Me.iROL.HeaderText = "ROL"
        Me.iROL.Name = "iROL"
        '
        'btnEditar
        '
        Me.btnEditar.BackColor = System.Drawing.Color.Transparent
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.ForeColor = System.Drawing.Color.Maroon
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEditar.Location = New System.Drawing.Point(380, 325)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(50, 21)
        Me.btnEditar.TabIndex = 12
        Me.btnEditar.Text = "&ED"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditar.UseVisualStyleBackColor = False
        Me.btnEditar.Visible = False
        '
        'btnGrabar
        '
        Me.btnGrabar.BackColor = System.Drawing.Color.Transparent
        Me.btnGrabar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.ForeColor = System.Drawing.Color.Maroon
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGrabar.Location = New System.Drawing.Point(431, 325)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(49, 21)
        Me.btnGrabar.TabIndex = 12
        Me.btnGrabar.Text = "&G"
        Me.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.UseVisualStyleBackColor = False
        Me.btnGrabar.Visible = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.Color.Maroon
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.Location = New System.Drawing.Point(480, 325)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(48, 21)
        Me.btnEliminar.TabIndex = 12
        Me.btnEliminar.Text = "&E"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.UseVisualStyleBackColor = False
        Me.btnEliminar.Visible = False
        '
        'frmControlAccesos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(778, 600)
        Me.Name = "frmControlAccesos"
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
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
        CType(Me.DataGridLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxTOOL.ResumeLayout(False)
        Me.GroupBoxTOOL.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBoxTAB.ResumeLayout(False)
        Me.GroupBoxTAB.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DataGridViewRolFrm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DataGridViewRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxTOOL As System.Windows.Forms.GroupBox
    Friend WithEvents chboxExportarPDF As System.Windows.Forms.CheckBox
    Friend WithEvents chboxExportarExcel As System.Windows.Forms.CheckBox
    Friend WithEvents chboxExportarWork As System.Windows.Forms.CheckBox
    Friend WithEvents chboxAyuda As System.Windows.Forms.CheckBox
    Friend WithEvents chboxEliminar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxCancelar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxGrabar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxEditar As System.Windows.Forms.CheckBox
    Friend WithEvents chboxNuevo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chboxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxTAB As System.Windows.Forms.GroupBox
    Friend WithEvents ChboxTab10 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab09 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab08 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab07 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab06 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab05 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab04 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab03 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab02 As System.Windows.Forms.CheckBox
    Friend WithEvents ChboxTab01 As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ChBoxTab As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbFrm As System.Windows.Forms.Label
    Friend WithEvents lbRol As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnFrm As System.Windows.Forms.Button
    Friend WithEvents btnFiltroRoles As System.Windows.Forms.Button
    Friend WithEvents lbFrmRol As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewRolFrm As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewRoles As System.Windows.Forms.DataGridView
    Friend WithEvents iIDROL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents iROL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chboxImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents chboxEMAIL As System.Windows.Forms.CheckBox
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button

End Class
