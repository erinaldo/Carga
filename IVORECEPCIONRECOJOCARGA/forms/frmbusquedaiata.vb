Imports System
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Text.RegularExpressions
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports ADOSERVERLib

Public Class frmbusquedaiata
#Region "Declarando variables generales "
    Dim clasesolcomun As New dtosolicitudcomun
    'Declaracion de Recordset
    Dim rstAgencia As ADODB.Recordset
    'Declaracion de Data Adapters
    Dim dr4 As New OleDb.OleDbDataAdapter
    'Declaracion de DataTables
    Dim dtAgencia As New System.Data.DataTable
    ' Declarando Data View 
    Dim dvAgencia As New DataView
    'Declarando Data row View 
    Dim drvAgencia As DataRowView
#End Region
    Private Sub frmbusquedaiata_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ShadowLabel1.Text = "Selección Código - IATA "
            ' Recuperando las agencias asociadas a un codigo iata 
            ' Recupera el combo de agencias, usando una clase   
            rstAgencia = clasesolcomun.ListaAgencia()
            dr4.Fill(dtAgencia, rstAgencia)
            dvAgencia = dtAgencia.DefaultView
            dvAgencia.AllowNew = False
            ' Procedimiento de la agencia  

            'Recuperando valor del combo, y lo coloca en idagencia  
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Asignando él valor ")
        End Try
    End Sub
End Class