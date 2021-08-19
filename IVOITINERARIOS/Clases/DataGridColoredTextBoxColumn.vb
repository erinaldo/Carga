Option Strict Off
Option Explicit On

Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Public Class DataGridColoredTextBoxColumn
    Inherits DataGridTextBoxColumn
    'Fields
    'Constructors
    'Events
    'Methods
    Public Sub New()
        'Warning: Implementation not found
    End Sub
    Protected Overloads Overrides Sub Paint(ByVal g As Graphics, ByVal bounds As Rectangle, ByVal source As CurrencyManager, ByVal rowNum As Integer, ByVal backBrush As Brush, ByVal foreBrush As Brush, ByVal alignToRight As Boolean)

        ' the idea is to conditionally set the foreBrush and/or backbrush
        ' depending upon some crireria on the cell value
        ' Here, we color anything that begins with a letter higher than 'F'
        Try
            Dim _DataRow As System.Data.DataRow
            Dim _MappingName As String
            Dim dv As System.Data.DataView = CType(source.List, System.Data.DataView)
            If (rowNum < dv.Table.Rows.Count) Then
                _DataRow = dv.Table.Rows(rowNum)
            Else
                _DataRow = Nothing
            End If
            _MappingName = MappingName

            'Dim u As String = CType(_DataRow("status"), String)
            Dim o As Object
            o = Me.GetColumnValueAtRow(source, rowNum)
            If (Not (o) Is Nothing) Then
                If _MappingName = "status" Then
                    Dim c As Char
                    c = CType(o, String).Substring(0, 1)
                    If (c = "V") Then
                        ' could be as simple as
                        ' backBrush = new SolidBrush(Color.Pink);
                        ' or something fnacier...
                        'backBrush = New LinearGradientBrush(bounds, Color.FromArgb(255, 200, 200), Color.FromArgb(128, 20, 20), LinearGradientMode.BackwardDiagonal)
                        backBrush = New SolidBrush(Color.Brown)
                        foreBrush = New SolidBrush(Color.White)
                    End If
                    If (c = "G") Then
                        foreBrush = New SolidBrush(Color.Red)
                    End If
                End If
                If _MappingName = "flg_cheque" Then
                    Dim c As Char
                    c = CType(o, String).Substring(0, 1)
                    If (c = "G") Then
                        foreBrush = New SolidBrush(Color.Red)
                    End If
                End If
                If _MappingName = "saldo" Or _MappingName = "saldoPMC" Then
                    Dim c As Char
                    c = CType(o, String)
                    If (c < "0") Then
                        ' could be as simple as
                        ' backBrush = new SolidBrush(Color.Pink);
                        ' or something fnacier...
                        'backBrush = New LinearGradientBrush(bounds, Color.FromArgb(255, 200, 200), Color.FromArgb(128, 20, 20), LinearGradientMode.BackwardDiagonal)
                        'backBrush = New SolidBrush(Color.Brown)
                        foreBrush = New SolidBrush(Color.Red)
                        'Else
                        '   foreBrush = New SolidBrush(Color.Black)
                    End If
                    'backBrush = New SolidBrush(Color.AliceBlue)
                End If
                If _MappingName = "saldoayu" Or _MappingName = "saldoPMCayu" Then
                    Dim c As Char
                    c = CType(o, String)
                    If (c < "0") Then
                        ' could be as simple as
                        ' backBrush = new SolidBrush(Color.Pink);
                        ' or something fnacier...
                        'backBrush = New LinearGradientBrush(bounds, Color.FromArgb(255, 200, 200), Color.FromArgb(128, 20, 20), LinearGradientMode.BackwardDiagonal)
                        'backBrush = New SolidBrush(Color.Brown)
                        foreBrush = New SolidBrush(Color.Red)
                    Else
                        foreBrush = New SolidBrush(Color.Black)
                    End If
                    backBrush = New SolidBrush(Color.AliceBlue)
                End If
                If _MappingName <> "nombre_agencia" Then
                    Dim c As Char
                    c = CType(o, String).Substring(0, 1)
                    If (c <> "A") Then
                        backBrush = New SolidBrush(SystemColors.Info)
                        'foreBrush = New SolidBrush(Color.Red)
                    End If
                End If
            Else
                backBrush = New SolidBrush(Color.AliceBlue)
                foreBrush = New SolidBrush(Color.Black)
            End If
        Catch ex As Exception
            ' empty catch 
        Finally
            ' make sure the base class gets called to do the drawing with
            ' the possibly changed brushes
            MyBase.Paint(g, bounds, source, rowNum, backBrush, foreBrush, alignToRight)
        End Try

    End Sub
End Class


