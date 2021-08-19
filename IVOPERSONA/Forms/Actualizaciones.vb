Public Class Actualizaciones


    Private Const EC_LEFTMARGIN = &H1
    Private Const EC_RIGHTMARGIN = &H2
    Private Const EC_USEFONTINFO = &HFFFF&
    Private Const EM_SETMARGINS = &HD3&
    Private Const EM_GETMARGINS = &HD4&
    Private Declare Function FindWindowEx Lib "user32" _
    Alias "FindWindowExA" _
    (ByVal hwndParent As Long, ByVal hwndChildAfter As Long, _
    ByVal lpszClass As String, _
    ByVal lpszWindow As String) As Long
    Private Declare Function SendMessageLong Lib "user32" _
    Alias "SendMessageA" _
    (ByVal hwnd As Long, ByVal wMsg As Long, _
    ByVal wParam As Long, ByVal lParam As Long) As Long

    'Private Sub AddCheckToCombo( _
    'ByRef chkThis As CheckBox, _
    'ByRef cboThis As ComboBox _
    ')
    '    Dim lhWnd As Long
    '    Dim lMargin As Long
    '    lhWnd = FindWindowEx(cboThis.hwnd, 0, "EDIT", vbNullString)
    '    If (lhWnd <> 0) Then
    '        lMargin = chkThis.Width \ Screen.TwipsPerPixelX + 2
    '        SendMessageLong(lhWnd, EM_SETMARGINS, EC_LEFTMARGIN, lMargin)
    '        chkThis.BackColor = cboThis.BackColor
    '        chkThis.Move( _
    '        cboThis.Left + 3 * Screen.TwipsPerPixelX, _
    '        cboThis.Top + 2 * Screen.TwipsPerPixelY, _
    '        chkThis.Width, _
    '        cboThis.Height - 4 * Screen.TwipsPerPixelY)
    '        chkThis.ZOrder()
    '    End If

    'End Sub


    Private Sub Actualizaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As New CheckBox
        With a
            .Name = "a"
            .Text = "RVCSOFT"
            .Checked = True
        End With
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")
        Me.ComboBox1.Items.Add("q")

        Me.ComboBox1.Controls.Add(a)

    End Sub
End Class
