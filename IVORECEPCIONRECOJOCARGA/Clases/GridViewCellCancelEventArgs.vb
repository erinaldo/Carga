Public Class frmPrueba
    Inherits System.ComponentModel.CancelEventArgs
    Private vColumnIndex As Int32
    Private vRowIndex As Int32

    Public ReadOnly Property ColumnIndex() As System.Int32
        Get
            Return vColumnIndex
        End Get
    End Property

    Public ReadOnly Property RowIndex() As System.Int32
        Get
            Return vRowIndex
        End Get
    End Property

End Class



