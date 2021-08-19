Imports System.Windows.Forms
'ref: valida el campo numerico y de texto especificamente
'
Public Class ValidacionTextBox
    Inherits NativeWindow
    Private tb As TextBox
    Private Sub New()
    End Sub
    Public Sub New(ByVal tb As TextBox)
        Me.tb = tb
        Me.AssignHandle(tb.Handle)
    End Sub
    Private Const WM_PASTE As Integer = &H302

    Protected Overrides Sub WndProc(ByRef m As Message)
        Select Case m.Msg
            Case WM_PASTE
                If Clipboard.GetDataObject.GetDataPresent(DataFormats.Text) Then
                    Dim str As String = Clipboard.GetDataObject.GetData(DataFormats.Text)
                    str = Replace(str, ",", "")
                    'Dim NewVal As String
                    tb.SelectedText = str
                    'NewVal = Mid(tb.Text, 1, tb.SelectionStart) & str & Mid(tb.Text, tb.SelectionStart + tb.SelectionLength + 1, Len(tb.Text))
                    If IsNumeric(str) Then
                        tb.SelectedText = ""
                    Else
                        tb.SelectedText = str
                    End If
                    Exit Sub
                End If
        End Select
        MyBase.WndProc(m)
    End Sub
End Class
