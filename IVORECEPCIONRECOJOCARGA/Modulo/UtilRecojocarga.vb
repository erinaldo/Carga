Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Module FuncionesOm
    'Public Function CargarComboa(ByVal StoredProcedure As String, ByVal Combo As ComboBox) As DataTable
    '    Dim da As New OleDbDataAdapter
    '    Dim dt As New DataTable
    '    Dim dv As New DataView
    '    Try
    '        Dim objdtoA As Object() = {StoredProcedure, 0}
    '        da.Fill(dt, VOCONTROLUSUARIO.fnSQLQuery(objdtoA))
    '        For i As Integer = 0 To dt.Rows.Count - 1
    '            Combo.Items.Add(dt.Rows(i)(1))
    '        Next
    '    Catch Qex As Exception
    '        MessageBox.Show(Qex.Message, "Control del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    '    End Try
    '    Return dt
    'End Function

    Public Sub CargarComboa(ByVal Mydt As DataTable, ByVal Combo As ComboBox, Optional ByVal ItemSeleccion As Integer = -1)
        Dim da As New OleDbDataAdapter
        Dim dt As New DataTable
        Dim dv As New DataView
        dt = Mydt
        Try
            For i As Integer = 0 To dt.Rows.Count - 1
                Combo.Items.Add(dt.Rows(i)(1))
            Next
            If ItemSeleccion <> -1 Then
                Combo.SelectedIndex = ItemSeleccion
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Control del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Public Sub LlenarTreeView(ByVal rst As ADODB.Recordset, ByRef cTree As TreeView, ByRef Cabecera As String)
        Try
            cTree.Nodes.Clear()
            'cTree.CheckBoxes = True
            cTree.Nodes.Add(Cabecera)
            Dim i As Integer

            Dim imageListSmall As New ImageList()
            Dim imageListLarge As New ImageList()

            ' Initialize the ImageList objects with bitmaps.
            'imageListSmall.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
            'imageListSmall.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
            'imageListLarge.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
            'imageListLarge.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
            imageListSmall.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
            imageListSmall.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
            imageListLarge.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
            imageListLarge.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))

            'Assign the ImageList objects to the ListView.
            cTree.ImageList = imageListLarge
            'cTree.SmallImageList = imageListSmall

            ''Garga de los Nodos
            'Dim tmpA As String
            'tmpA = ""
            'If rst.BOF = False Then
            '    rst.MoveFirst()
            '    While rst.BOF = False And rst.EOF = False
            '        If tmpA <> rst.Fields(1).Value Then
            '            cTree.Nodes(0).Nodes.Add(rst.Fields(1).Value)
            '            cTree.Nodes(0).SelectedImageIndex = 0
            '            cTree.Nodes(0).Nodes(i).Tag = rst.Fields(0).Value
            '            cTree.Nodes(0).Nodes(i).SelectedImageIndex = 0
            '            tmpA = rst.Fields(1).Value
            '        End If
            '        rst.MoveNext()
            '        i = i + 1
            '    End While
            'End If
            '

            i = 0
            Dim tmp As String
            tmp = ""
            If rst.BOF = False Then
                rst.MoveFirst()
                While rst.BOF = False And rst.EOF = False
                    If tmp <> rst.Fields(1).Value Then
                        cTree.Nodes(0).Nodes.Add(rst.Fields(1).Value)
                        cTree.Nodes(0).SelectedImageIndex = 0
                        cTree.Nodes(0).Nodes(i).Tag = rst.Fields(0).Value
                        cTree.Nodes(0).Nodes(i).SelectedImageIndex = 0
                        tmp = rst.Fields(1).Value
                    End If
                    rst.MoveNext()
                    i = i + 1
                End While
                'rst.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    'Public Function LlenarTreeView(ByVal cTree As TreeView, ByVal Cabecera As String, ByVal rstPadre As ADODB.Recordset, Optional ByVal rstHijoA As ADODB.Recordset = Nothing, Optional ByVal rstHijoB As ADODB.Recordset = Nothing) As Integer
    Public Sub LlenarTreeViewa(ByVal cTree As TreeView)
        Try
            cTree.Nodes.Add("PAIS")
            cTree.Nodes.Add("DEPARTAMENTO")
            cTree.Nodes.Add("DISTRITO")

            cTree.Nodes(0).Nodes.Add("PERU")
            cTree.Nodes(0).Nodes.Add("CHILE")
            cTree.Nodes(0).Nodes.Add("ECUADOR")

            cTree.Nodes(1).Nodes.Add("LIMA")
            cTree.Nodes(1).Nodes.Add("TRUJILLO")
            cTree.Nodes(1).Nodes.Add("TACNA")

            cTree.Nodes(2).Nodes.Add("SAN BORJA")
            cTree.Nodes(2).Nodes.Add("SAN LIUS")
            cTree.Nodes(2).Nodes.Add("SAN EDUARDO")

            cTree.Nodes(0).Nodes(0).Nodes.Add("LIMA")
            cTree.Nodes(0).Nodes(0).Nodes.Add("TRUJILLO")
            cTree.Nodes(0).Nodes(0).Nodes.Add("TACNA")
            cTree.Nodes(0).Nodes(0).Nodes.Add("JUNIN")

            cTree.Nodes(0).Nodes(1).Nodes.Add("SANTIAGO")

            cTree.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        Catch ex As Exception
        End Try
    End Sub
End Module