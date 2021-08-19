Imports System
Imports System.Windows.Forms

Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

'Public Class Form1
'    Inherits Form

'    Private dataGridView1 As New DataGridView()

'    <STAThreadAttribute()> _
'    Public Shared Sub Main()
'        Application.Run(New Form1())
'    End Sub

'    Public Sub New()
'        Me.dataGridView1.Dock = DockStyle.Fill
'        Me.Controls.Add(Me.dataGridView1)
'        Me.Text = "DataGridView calendar column demo"
'    End Sub

'    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
'        Handles Me.Load

'        Dim col As New CalendarColumn()
'        Me.dataGridView1.Columns.Add(col)
'        Me.dataGridView1.RowCount = 5
'        Dim row As DataGridViewRow
'        For Each row In Me.dataGridView1.Rows
'            row.Cells(0).Value = DateTime.Now
'        Next row

'    End Sub

'End Class


