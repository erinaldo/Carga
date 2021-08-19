Imports INTEGRACION_LN
Imports AccesoDatos
Public Class dtoUtilitario
    Shared Function ObtieneNumeroSolicitud(usuario As Integer, Optional opcion As Integer = 0) As Integer
        Dim db As New BaseDatos
        Dim strCadena As String
        Try
            db.Conectar()
            strCadena = "select PKG_IVOGESTION_CLIENTE.sf_get_Numero_Solicitud (" & usuario & "," & opcion & ") from dual"
            db.EjecutarComando(strCadena, CommandType.Text)
            Return db.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Shared Function ExisteValorGrid(dgv As DataGridView, valor As String, columna As Integer) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If valor = row.Cells(columna).Value.ToString Then
                Return True
            End If
        Next
        Return False
    End Function

    Shared Function FilasGridVisible(dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If row.Visible Then
                Return True
            Else
                If row.Cells("estado").Value <> 2 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Shared Function FilasGridInvisible(dgv As DataGridView) As Integer
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If row.Visible = False Then
                i += 1
            End If
        Next
        Return i
    End Function

    Shared Function FilaGridVisiblePrimera(dgv As DataGridView) As Integer
        Dim i As Integer = -1
        For Each row As DataGridViewRow In dgv.Rows
            i += 1
            If row.Visible = True Then
                Exit For
            End If
        Next
        Return i
    End Function
End Class
