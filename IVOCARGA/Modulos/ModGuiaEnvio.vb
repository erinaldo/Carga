Module ModGuiaEnvio
#Region "POPUP IWIN"

    'Public iWinOrinen As New AutoCompleteStringCollection
    'Public iWinDestino As New AutoCompleteStringCollection
    'Public iWinPerosa As New AutoCompleteStringCollection

    'Public coll_iOrigen As New Collection
    'Public coll_iDestino As New Collection

#End Region
#Region "METODOS"
    Public NroDigitos_Guias As Integer = 13
    '
    'Public Sub fnCargar_iWin(ByVal iTextBox As TextBox, ByVal rst_i As ADODB.Recordset, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer)
    '    Try
    '        Dim str As String = ""
    '        auto_i.Clear()
    '        coll_i.Clear()
    '        iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource

    '        Dim i As Integer = 0
    '        While rst_i.BOF = False And rst_i.EOF = False
    '            auto_i.Add(rst_i.Fields.Item(1).Value.ToString())
    '            coll_i.Add(rst_i.Fields(0).Value, i.ToString())
    '            'auto_i.Insert(Int(rst_i.Fields(0).Value), rst_i.Fields.Item(1).Value.ToString)
    '            If Int(rst_i.Fields(0).Value.ToString) = iID Then
    '                str = rst_i.Fields.Item(1).Value.ToString
    '            End If
    '            rst_i.MoveNext()
    '            i = i + 1
    '        End While
    '        iTextBox.AutoCompleteCustomSource = auto_i
    '        iTextBox.Text = str
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    '28/08/2009 - Cambiado por el Data Helper, se pasa con un data table
    Public Sub fnCargar_iWin_dt(ByVal iTextBox As TextBox, ByVal dt_rst_i As DataTable, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer)
        Try
            Dim str As String = ""
            auto_i.Clear()
            coll_i.Clear()
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            '
            Dim i As Integer = 0
            '
            For Each row As DataRow In dt_rst_i.Rows
                auto_i.Add(row.Item(1).ToString())
                coll_i.Add(row.Item(0).ToString, i.ToString())
                '
                If Int(row.Item(0).ToString) = iID Then
                    str = row.Item(1).ToString
                End If
                i = i + 1
            Next
            '
            iTextBox.AutoCompleteCustomSource = auto_i
            iTextBox.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'Public Sub fnCargar_iWin2(ByVal iTextBox As TextBox, ByVal rst_i As ADODB.Recordset, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer, ByVal auto_i2 As AutoCompleteStringCollection)
    '    Try
    '        Dim str As String = ""
    '        auto_i.Clear()
    '        auto_i2.Clear()
    '        coll_i.Clear()
    '        iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource

    '        Dim i As Integer = 0
    '        While rst_i.BOF = False And rst_i.EOF = False
    '            auto_i.Add(rst_i.Fields.Item(1).Value.ToString())
    '            auto_i2.Add(rst_i.Fields.Item(2).Value.ToString())

    '            coll_i.Add(rst_i.Fields(0).Value, i.ToString())
    '            'auto_i.Insert(Int(rst_i.Fields(0).Value), rst_i.Fields.Item(1).Value.ToString)
    '            If Int(rst_i.Fields(0).Value.ToString) = iID Then
    '                str = rst_i.Fields.Item(1).Value.ToString
    '            End If
    '            rst_i.MoveNext()
    '            i = i + 1
    '        End While
    '        iTextBox.AutoCompleteCustomSource = auto_i
    '        iTextBox.Text = str
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    '03/09/2009 - Modificado por datahelper
    Public Sub fnCargar_iWin2(ByVal iTextBox As TextBox, ByVal dt_i As DataTable, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer, ByVal auto_i2 As AutoCompleteStringCollection)
        Try
            Dim str As String = ""
            auto_i.Clear()
            auto_i2.Clear()
            coll_i.Clear()
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            '
            Dim i As Integer = 0
            For Each row As DataRow In dt_i.Rows
                auto_i.Add(row.Item(1).ToString())
                auto_i2.Add(row.Item(2).ToString())
                coll_i.Add(row.Item(0), i.ToString())
                'auto_i.Insert(Int(rst_i.Fields(0).Value), rst_i.Fields.Item(1).Value.ToString)
                If Int(row.Item(0).ToString) = iID Then
                    str = row.Item(1).ToString
                End If
                i = i + 1
            Next
            iTextBox.AutoCompleteCustomSource = auto_i
            iTextBox.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    'Public Sub fnCargar_iWin2(ByVal iTextBox As TextBox, ByVal rst_i As ADODB.Recordset, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer, ByVal auto_i2 As AutoCompleteStringCollection, ByVal auto_i3 As AutoCompleteStringCollection)
    '    Try
    '        Dim str As String = ""
    '        auto_i.Clear()
    '        auto_i2.Clear()
    '        auto_i3.Clear() ' 18/07/2009 
    '        '
    '        coll_i.Clear()
    '        iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource

    '        Dim i As Integer = 0
    '        While rst_i.BOF = False And rst_i.EOF = False
    '            '
    '            auto_i.Add(rst_i.Fields.Item(1).Value.ToString())
    '            auto_i2.Add(rst_i.Fields.Item(2).Value.ToString())
    '            auto_i3.Add(rst_i.Fields.Item(3).Value.ToString())  '18/07/2009 - Recupera el nro de dígitos del cliente
    '            '
    '            coll_i.Add(rst_i.Fields(0).Value, i.ToString())
    '            'auto_i.Insert(Int(rst_i.Fields(0).Value), rst_i.Fields.Item(1).Value.ToString)
    '            If Int(rst_i.Fields(0).Value.ToString) = iID Then
    '                str = rst_i.Fields.Item(1).Value.ToString
    '            End If
    '            rst_i.MoveNext()
    '            i = i + 1
    '        End While
    '        iTextBox.AutoCompleteCustomSource = auto_i
    '        iTextBox.Text = str
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    '28/08/2009 - Cambiado por el Data Helper, se pasa con un data table
    Public Sub fnCargar_iWin2(ByVal iTextBox As TextBox, ByVal rst_i As DataTable, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer, ByVal auto_i2 As AutoCompleteStringCollection, ByVal auto_i3 As AutoCompleteStringCollection)

        Try
            Dim str As String = ""
            auto_i.Clear()
            auto_i2.Clear()
            auto_i3.Clear() ' 18/07/2009 
            '
            coll_i.Clear()
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            '
            Dim i As Integer = 0
            '
            For Each row As DataRow In rst_i.Rows
                '
                auto_i.Add(row.Item(1).ToString())
                auto_i2.Add(row.Item(2).ToString())
                auto_i3.Add(row.Item(3).ToString())  '18/07/2009 - Recupera el nro de dígitos del cliente
                '
                coll_i.Add(row.Item(0), i.ToString)
                '
                If Int(row.Item(0).ToString) = iID Then
                    str = row.Item(1).ToString
                End If
                '
                i = i + 1
            Next
            iTextBox.AutoCompleteCustomSource = auto_i
            iTextBox.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    'Public Sub fnCargar_iWin2(ByVal iTextBox1 As TextBox, ByVal iTextBox2 As TextBox, ByVal rst_i As ADODB.Recordset, ByVal coll_i As Collection, ByVal auto_i1 As AutoCompleteStringCollection, ByVal iID1 As Integer, ByVal auto_i2 As AutoCompleteStringCollection, ByVal iID2 As Integer)
    '    Try
    '        Dim str1 As String = ""
    '        Dim str2 As String = ""
    '        iTextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        iTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource

    '        iTextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        iTextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource

    '        Dim i As Integer = 0
    '        While rst_i.BOF = False And rst_i.EOF = False

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
    '        End While
    '        iTextBox1.AutoCompleteCustomSource = auto_i1
    '        iTextBox1.Text = str1

    '        iTextBox2.AutoCompleteCustomSource = auto_i2
    '        iTextBox2.Text = str2

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub
    Public Sub fnCargar_iWin2_dt2(ByVal iTextBox As TextBox, ByVal rst_i As DataTable, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer, ByVal auto_i2 As AutoCompleteStringCollection)
        Try
            Dim str As String = ""
            auto_i.Clear()
            auto_i2.Clear()
            coll_i.Clear()
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim i As Integer = 0
            For Each obj As DataRow In rst_i.Rows
                auto_i.Add(obj.Item(1).ToString())
                auto_i2.Add(obj.Item(2).ToString())

                coll_i.Add(obj.Item(0), i.ToString())
                If Int(obj.Item(0).ToString) = iID Then
                    str = obj.Item(1).ToString
                End If
                i = i + 1
            Next
            iTextBox.AutoCompleteCustomSource = auto_i
            iTextBox.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Public Sub fnCargar_iWin_dt_3(ByVal iTextBox As TextBox, ByVal dt_rst_i As DataTable, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer)
        Try
            Dim str As String = ""
            auto_i.Clear()
            coll_i.Clear()
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource
            '
            Dim i As Integer = 0
            '
            For Each row As DataRow In dt_rst_i.Rows
                auto_i.Add(row.Item(1).ToString())
                coll_i.Add(row.Item(0).ToString, i.ToString())
                '
                'If Int(row.Item(0).ToString) = iID Then
                str = row.Item(1).ToString
                'End If
                i = i + 1
            Next
            '
            iTextBox.AutoCompleteCustomSource = auto_i
            iTextBox.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

#End Region
End Module
