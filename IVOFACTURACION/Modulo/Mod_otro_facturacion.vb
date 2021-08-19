Module Mod_otro_facturacion
#Region "Variables"
    Public busquedapor As Integer
    Public idcliente As Integer
    Public sidpersona As String
    Public sruc As String
    Public scliente As String
    Public scontacto As String
    Public idireccion As Integer
    Public iidrubro As Integer
    'Llamando a direcciones y contacto del consignado 
    Public idagencia As Integer
    Public frmfilapadre As Integer
    Public bcancelar As Boolean
    'Pasando para el mantenimiento de cliente 
    Public siddireccion_consignado As String
    '
    Public tipodireccion As Integer
    Public idubigeo As Integer
    Public idpais As Integer
    Public iddpto As Integer
    Public idprov As Integer
    Public iddistrito As Integer
    Public sdireccion As String
    Public smensaje As String
    '    
#End Region
#Region "Eventos y Funciones"
    Public Sub fnCargar_iWin_for4(ByVal iTextBox As TextBox, ByVal rst_i As ADODB.Recordset, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer, ByVal auto_i2 As AutoCompleteStringCollection, ByVal auto_i3 As AutoCompleteStringCollection, ByVal auto_i4 As AutoCompleteStringCollection)
        Try
            Dim str As String = ""
            auto_i.Clear()
            auto_i2.Clear()
            auto_i3.Clear()
            auto_i4.clear()
            coll_i.Clear()
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim i As Integer = 0
            While rst_i.BOF = False And rst_i.EOF = False
                auto_i.Add(rst_i.Fields.Item(1).Value.ToString())
                auto_i2.Add(rst_i.Fields.Item(2).Value.ToString())
                auto_i3.Add(rst_i.Fields.Item(3).Value.ToString())
                auto_i4.Add(rst_i.Fields.Item(4).Value.ToString())
                ' --- 
                coll_i.Add(rst_i.Fields(0).Value, i.ToString())
                'auto_i.Insert(Int(rst_i.Fields(0).Value), rst_i.Fields.Item(1).Value.ToString)
                If Int(rst_i.Fields(0).Value.ToString) = iID Then
                    str = rst_i.Fields.Item(1).Value.ToString
                End If
                rst_i.MoveNext()
                i = i + 1
            End While
            iTextBox.AutoCompleteCustomSource = auto_i
            iTextBox.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub

    Public Sub fnCargar_iWin_for4(ByVal iTextBox As TextBox, ByVal rst_i As DataTable, ByVal coll_i As Collection, ByVal auto_i As AutoCompleteStringCollection, ByVal iID As Integer, ByVal auto_i2 As AutoCompleteStringCollection, ByVal auto_i3 As AutoCompleteStringCollection, ByVal auto_i4 As AutoCompleteStringCollection)
        Try
            Dim str As String = ""
            auto_i.Clear()
            auto_i2.Clear()
            auto_i3.Clear()
            auto_i4.Clear()
            coll_i.Clear()
            iTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            iTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource

            Dim i As Integer = 0
            For Each obj As DataRow In rst_i.Rows
                auto_i.Add(obj.Item(1).ToString())
                auto_i2.Add(obj.Item(2).ToString())
                auto_i3.Add(obj.Item(3).ToString())
                auto_i4.Add(obj.Item(4).ToString())
                ' --- 
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

#End Region
End Module