Public Class FrmInicio

    Private Sub FrmInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Mod.15/10/2009 -->Omendoza - Pasando al datahelper -  
        ' Call ModConexion.InitConexion()
    End Sub
    Private Sub RutasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutasToolStripMenuItem.Click

    End Sub
    Private Sub RutasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RutasToolStripMenuItem1.Click
        Dim ciudad As New FrmRutas
        ciudad.ShowDialog()
    End Sub
End Class