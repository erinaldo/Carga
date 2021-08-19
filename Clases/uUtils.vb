Imports System.Windows.Forms
Imports System.Drawing
Public Class uUtils
    Dim ControlError As Integer
    Public Sub LlenarCombo(ByVal rst As ADODB.Recordset, ByRef cLista As ComboBox)
        Try
            Dim index As Integer
            index = 0

            For index = 0 To cLista.Items.Count() - 1
                cLista.Items.RemoveAt(0)
            Next index

            For index = 0 To rst.Fields.Count - 1
                cLista.Items.Insert(index, rst.Fields(1).Value)
                cLista.ValueMember = "1"
                rst.MoveNext()
            Next index
            '
            cLista.Items.GetEnumerator()
            '
            ControlError = 1
        Catch ex As Exception
            ControlError = 0
        End Try
    End Sub
    Public bmActivo As Bitmap
    Public bmPendiente As Bitmap
    Public bm2 As Bitmap
    Public bmEliminado As Bitmap
    Public Sub IniciarImagenes()
        Try
            'bmPendiente = New Bitmap("C:\icon\Pendiente.bmp")    Modificado 12/10/2006
            'bmActivo = New Bitmap("C:\icon\Activo.bmp")
            'bm2 = New Bitmap("C:\icon\Activo.bmp")
            'bmEliminado = New Bitmap("C:\icon\Eliminado.bmp")
            bmPendiente = New Bitmap("..\icon\Pendiente.bmp")
            bmActivo = New Bitmap("..\icon\Activo.bmp")
            bm2 = New Bitmap("..\icon\Activo.bmp")
            bmEliminado = New Bitmap("..\icon\Eliminado.bmp")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
End Class
