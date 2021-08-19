'Imports Microsoft.Office.Interop.Excel
Imports System.Data
Imports System.Data.OleDb

Public Class frmImportarCodigo

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub frmImportarCodigo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        ' Cadena de conexión con el libro de Excel indicado.
        Dim ruta As String = "c:\datos\prueba.xlsx"
        Dim cadenaConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties='Excel 8.0;HDR=YES';" &
                                       "Data Source=" & ruta
        Dim tabla As String
        Dim campo As String

        Using cnn As New OleDbConnection(cadenaConexion)
            cnn.Open()
            Dim dtXlsSchema As DataTable = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})
            For i As Integer = 0 To dtXlsSchema.Rows.Count - 1
                tabla = dtXlsSchema.Rows(i).Item("Table_Name").ToString
                If Not (tabla.Contains("FilterDatabase")) Then
                    Dim cmd As OleDbCommand = cnn.CreateCommand()
                    cmd.CommandText = String.Format("SELECT sku FROM [" & tabla & "]")
                    Dim da As New OleDbDataAdapter(cmd)
                    Dim dtTemp As New DataTable("TestTable")
                    da.Fill(dtTemp)

                    Dim dt As DataTable = dtTemp.Clone()
                    Dim rows As DataRow() = dtTemp.Select()
                    For index As Integer = 0 To rows.Length - 1
                        Dim row As DataRow = rows(index)
                        If (row.Item(0) Is DBNull.Value) Then
                            Exit For
                        End If
                        dt.ImportRow(row)
                    Next

                    'Debug.WriteLine(dtXlsSchema.Rows(i).Item("Table_Name").ToString)
                    'dtXlsSchema = cnn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, New Object() {Nothing, Nothing, tabla, Nothing})

                    'For j As Integer = 0 To dtXlsSchema.Columns.Count - 1
                    'Debug.WriteLine(dtXlsSchema.Rows(j).Item("Column_Name").ToString)
                    'campo = dtXlsSchema.Rows(j).Item("Column_Name").ToString()
                    'Next
                End If
            Next
        End Using

        'Dim excel As Excel.Application
        'Dim wb As Excel.Workbook
        'Dim ws As Worksheet

        'excel = New Excel.Application
        'excel.Visible = False
        'excel.UserControl = False
        'wb = excel.Workbooks.Open(ruta)
        ''ws = wb.Worksheets(1)
        'For i As Integer = 1 To wb.Worksheets.Count - 1
        '    ws = wb.Worksheets(i)
        'Next
        'wb.Close()
        'wb = Nothing
        'excel.Quit()
        'excel = Nothing
    End Sub
End Class