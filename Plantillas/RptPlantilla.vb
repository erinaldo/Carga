Public Class RptPlantilla
    Inherits Printing.PrintDocument
    Private StDGV As DataGridView
    Private oStringFormat As StringFormat
    Private oStringFormatComboBox As StringFormat
    Private oButton As Button
    Private oCheckbox As CheckBox
    Private oComboBox As ComboBox
    Private nTotalWidth As Int16
    Private nRowPos As Int16
    Private NewPage As Boolean
    Private nPageNo As Int16
    Private Header As String = " "
    Private sUserName As String = "..."
    Private StOrienta As Integer = 0
    Private StLista As New ArrayList
    Private StTopDeta As Integer = 100
    Private nTotalLista As Int16

    Public Property DGV() As DataGridView
        Get
            Return StDGV
        End Get
        Set(ByVal value As DataGridView)
            StDGV = value
        End Set
    End Property
    Public Property Titulo() As String
        Get
            Return Header
        End Get
        Set(ByVal value As String)
            Header = value
        End Set
    End Property
    Public Property Usuario() As String
        Get
            Return sUserName
        End Get
        Set(ByVal value As String)
            sUserName = value
        End Set
    End Property
    Public Property Orientacion() As Integer
        Get
            Return StOrienta
        End Get
        Set(ByVal value As Integer)
            StOrienta = value
        End Set
    End Property
    Public Property Lista() As ArrayList
        Get
            Return StLista
        End Get
        Set(ByVal value As ArrayList)
            StLista = value
        End Set
    End Property
    Public Property TopDetalle() As Integer
        Get
            Return StTopDeta
        End Get
        Set(ByVal value As Integer)
            StTopDeta = value
        End Set
    End Property

    Private Sub PrintDocument1_QueryPageSettings(ByVal sender As Object, ByVal e As System.Drawing.Printing.QueryPageSettingsEventArgs) Handles Me.QueryPageSettings
        If StOrienta = 0 Then
            e.PageSettings.Landscape = False
        Else
            e.PageSettings.Landscape = True
        End If
        e.PageSettings.Margins.Top = StTopDeta
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeginPrint
        oStringFormat = New StringFormat
        oStringFormat.Alignment = StringAlignment.Near
        oStringFormat.LineAlignment = StringAlignment.Center
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter
        oStringFormatComboBox = New StringFormat
        oStringFormatComboBox.LineAlignment = StringAlignment.Center
        oStringFormatComboBox.FormatFlags = StringFormatFlags.NoWrap
        oStringFormatComboBox.Trimming = StringTrimming.EllipsisCharacter
        oButton = New Button
        oCheckbox = New CheckBox
        oComboBox = New ComboBox
        nTotalWidth = 0
        'StLista.Add("Prueba")
        nTotalLista = StLista.Count
        Try
            For Each oColumn As DataGridViewColumn In StDGV.Columns
                nTotalWidth += oColumn.Width
            Next
        Catch ex As Exception
            nTotalWidth = 0
        End Try
        nPageNo = 1
        NewPage = True
        nRowPos = 0
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Me.PrintPage
        Static oColumnLefts As New ArrayList
        Static oColumnWidths As New ArrayList
        Static oColumnTypes As New ArrayList
        Static nHeight As Int16
        Dim nWidth, i, nRowsPerPage, ci, tci As Int16
        Dim nTop As Int16 = e.MarginBounds.Top
        Dim nLeft As Int16 = e.MarginBounds.Left
        Dim TotalSize As Integer

        If nTotalLista > 0 Then
            tci = 0
            For ci = 0 To nTotalLista - 1
                If tci = 2 Then
                    e.Graphics.DrawString(Convert.ToString(StLista(ci - 2)), New Font("Courier New", 9, FontStyle.Regular), Brushes.Black, Convert.ToInt16(StLista(ci - 1)), Convert.ToInt16(StLista(ci)))
                    tci = 0
                Else
                    tci = tci + 1
                End If
            Next
        End If
        oColumnLefts.Clear()
        oColumnWidths.Clear()
        oColumnTypes.Clear()
        'If nPageNo = 1 Then
        If nTotalWidth > 0 Then
            For Each oColumn As DataGridViewColumn In StDGV.Columns
                nWidth = CType(Math.Floor(oColumn.Width / nTotalWidth * nTotalWidth * (e.MarginBounds.Width / nTotalWidth)), Int16)
                nHeight = e.Graphics.MeasureString(oColumn.HeaderText, oColumn.InheritedStyle.Font, nWidth).Height + 11
                'MessageBox.Show(nLeft.ToString)
                oColumnLefts.Add(nLeft)
                oColumnWidths.Add(nWidth)
                oColumnTypes.Add(oColumn.GetType)
                nLeft += nWidth
            Next
            'End If
            'Do While nRowPos < StDGV.Rows.Count - 1
            Do While nRowPos < StDGV.Rows.Count
                Dim oRow As DataGridViewRow = StDGV.Rows(nRowPos)
                If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top Then
                    DrawFooter(e, nRowsPerPage)
                    NewPage = True
                    nPageNo += 1
                    e.HasMorePages = True
                    Exit Sub
                Else
                    If NewPage Then
                        TotalSize = e.MarginBounds.Left + e.MarginBounds.Size.Width + e.MarginBounds.Left
                        TotalSize = (TotalSize / 2) - ((Len(Header) * 6.6) / 2)
                        ' Draw Header
                        'e.Graphics.DrawString(Header, New Font(StDGV.Font, FontStyle.Bold), Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(StDGV.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13)
                        'e.Graphics.DrawString(Header.ToUpper, New Font(StDGV.Font, FontStyle.Bold), Brushes.Black, TotalSize, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(StDGV.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 30)                    
                        e.Graphics.DrawString(Header.ToUpper, New Font("Courier New", 9, FontStyle.Regular), Brushes.Black, TotalSize, e.MarginBounds.Top - e.Graphics.MeasureString(Header, New Font(StDGV.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 30)

                        ' Draw Columns
                        nTop = e.MarginBounds.Top
                        i = 0
                        For Each oColumn As DataGridViewColumn In StDGV.Columns
                            'e.Graphics.FillRectangle(New SolidBrush(Drawing.Color.LightGray), New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            'e.Graphics.DrawRectangle(Pens.Black, New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight))
                            'e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                            'MessageBox.Show(oColumnLefts(i).ToString)
                            e.Graphics.DrawString(oColumn.HeaderText, oColumn.InheritedStyle.Font, New SolidBrush(oColumn.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), 0), oStringFormat)
                            i += 1
                        Next
                        NewPage = False
                    End If
                    nTop += nHeight
                    i = 0
                    For Each oCell As DataGridViewCell In oRow.Cells
                        If IsNothing(oCell.Value) = False Then
                            If oRow.Visible = True And Len(oCell.Value.ToString()) > 0 Then
                                Dim vartype As Object = oCell.ValueType
                                If oColumnTypes(i) Is GetType(DataGridViewImageColumn) Then
                                    Dim oCellSize As Rectangle = New Rectangle(oColumnLefts(i), nTop, oColumnWidths(i), nHeight)
                                    Dim oImageSize As Size = CType(oCell.Value, Image).Size
                                    e.Graphics.DrawImage(oCell.Value, New Rectangle(oColumnLefts(i) + CType(((oCellSize.Width - oImageSize.Width) / 2), Int32), nTop + CType(((oCellSize.Height - oImageSize.Height) / 2), Int32), CType(oCell.Value, Image).Width, CType(oCell.Value, Image).Height))
                                ElseIf oColumnTypes(i) Is GetType(DataGridViewButtonColumn) Then
                                    oButton.Text = oCell.Value.ToString
                                    oButton.Size = New Size(oColumnWidths(i), nHeight)
                                    Dim oBitmap As New Bitmap(oButton.Width, oButton.Height)
                                    oButton.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                                    e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                                ElseIf oColumnTypes(i) Is GetType(DataGridViewCheckBoxColumn) Then
                                    oCheckbox.Size = New Size(14, 14)
                                    oCheckbox.Checked = CType(oCell.Value, Boolean)
                                    Dim oBitmap As New Bitmap(oColumnWidths(i), nHeight)
                                    Dim oTempGraphics As Graphics = Graphics.FromImage(oBitmap)
                                    oTempGraphics.FillRectangle(Brushes.White, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                                    oCheckbox.DrawToBitmap(oBitmap, New Rectangle(CType((oBitmap.Width - oCheckbox.Width) / 2, Int32), CType((oBitmap.Height - oCheckbox.Height) / 2, Int32), oCheckbox.Width, oCheckbox.Height))
                                    e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                                ElseIf oColumnTypes(i) Is GetType(DataGridViewComboBoxColumn) Then
                                    oComboBox.Size = New Size(oColumnWidths(i), nHeight)
                                    Dim oBitmap As New Bitmap(oComboBox.Width, oComboBox.Height)
                                    oComboBox.DrawToBitmap(oBitmap, New Rectangle(0, 0, oBitmap.Width, oBitmap.Height))
                                    e.Graphics.DrawImage(oBitmap, New Point(oColumnLefts(i), nTop))
                                    e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i) + 1, nTop, oColumnWidths(i) - 16, nHeight), oStringFormatComboBox)
                                ElseIf oColumnTypes(i) Is GetType(DataGridViewTextBoxColumn) OrElse oColumnTypes(i) Is GetType(DataGridViewLinkColumn) Then
                                    e.Graphics.DrawString(oCell.Value.ToString, oCell.InheritedStyle.Font, New SolidBrush(oCell.InheritedStyle.ForeColor), New RectangleF(oColumnLefts(i), nTop, oColumnWidths(i), nHeight), oStringFormat)
                                End If
                            End If
                        End If
                        i += 1
                    Next
                End If
                nRowPos += 1
                nRowsPerPage += 1
            Loop
            DrawFooter(e, nRowsPerPage)
        End If
        e.HasMorePages = False
    End Sub
    Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal RowsPerPage As Int32)
        Dim sPageNo As String = nPageNo.ToString + " of " + Math.Ceiling(StDGV.Rows.Count / RowsPerPage).ToString
        ' Right Align - User Name
        e.Graphics.DrawString(sUserName, StDGV.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, StDGV.Font, e.MarginBounds.Width).Width), e.MarginBounds.Top + e.MarginBounds.Height + 7)
        ' Left Align - Date/Time
        e.Graphics.DrawString(Now.ToLongDateString + " " + Now.ToShortTimeString, StDGV.Font, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top + e.MarginBounds.Height + 7)
        ' Center  - Page No. Info
        e.Graphics.DrawString(sPageNo, StDGV.Font, Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(sPageNo, StDGV.Font, e.MarginBounds.Width).Width) / 2, e.MarginBounds.Top + e.MarginBounds.Height + 31)
    End Sub

End Class
