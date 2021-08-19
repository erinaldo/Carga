Imports System.Windows.Forms
Public Class dtoProcesos
    'Public Sub fnCargar_iWin2_r(ByVal iTextBox1 As TextBox, ByVal iTextBox2 As TextBox, ByVal dv_i As DataView, ByVal coll_i As Collection, ByVal auto_i1 As AutoCompleteStringCollection, ByVal iID1 As Integer, ByVal auto_i2 As AutoCompleteStringCollection, ByVal iID2 As Integer)
    '    Try
    '        Dim str1 As String = ""
    '        Dim str2 As String = ""
    '        iTextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        iTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource

    '        iTextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        iTextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource

    '        For i As Integer = 0 To dv_i.Count - 1

    '            auto_i1.Add(rst_i.Fields.Item(1).Value.ToString())
    '            auto_i2.Add(rst_i.Fields.Item(1).Value.ToString())

    '            coll_i.Add(rst_i.Fields(0).Value, i.ToString())
    '            If Int(rst_i.Fields(0).Value.ToString) = iID1 Then
    '                str1 = rst_i.Fields.Item(1).Value.ToString
    '            End If

    '            If Int(rst_i.Fields(0).Value.ToString) = iID2 Then
    '                str2 = rst_i.Fields.Item(1).Value.ToString
    '            End If
    '            rst_i.MoveNext()
    '            i = i + 1
    '        Next
    '        iTextBox1.AutoCompleteCustomSource = auto_i1
    '        iTextBox1.Text = str1

    '        iTextBox2.AutoCompleteCustomSource = auto_i2
    '        iTextBox2.Text = str2

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub

    Public Sub fnCargar_iWin_r(ByVal iTextBox As TextBox, ByVal dv_i As DataView, ByRef coll_i As Collection, ByRef auto_i As AutoCompleteStringCollection, ByVal iID As Integer)

        Try
            Dim str As String = ""
            auto_i = New AutoCompleteStringCollection
            coll_i = New Collection
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource

            For i As Integer = 0 To dv_i.Count - 1

                auto_i.Add(dv_i.Table.Rows(i)(1).ToString)
                coll_i.Add(dv_i.Table.Rows(i)(0).ToString, i.ToString)
                If Int(dv_i.Table.Rows(i)(0).ToString) = iID Then
                    str = dv_i.Table.Rows(i)(1).ToString
                End If

            Next
            iTextBox.AutoCompleteCustomSource = auto_i
            iTextBox.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

End Class
