
Public Class FrmPrinterView

    '    Dim sfh As New Microsoft.Win32.SafeHandles.SafeFileHandle(fh, True)
    '   Dim fs As IO.FileStream = New IO.FileStream(sfh, IO.FileAccess.ReadWrite)

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        '      Dim fh As IntPtr
        '     Dim SW As StreamWriter
        '    Dim FS As FileStream
        '   fh = Win32API.CreateFile("LPT1:", Win32API.GENERIC_WRITE, 0, 0, Win32API.CREATE_ALWAYS, 0, 0)
        '  Dim sfh As New Microsoft.Win32.SafeHandles.SafeFileHandle(fh, True)
        ' FS = New FileStream(sfh, FileAccess.Write)
        '        FS.Flush()
        '       SW = New StreamWriter(FS)
        '      SW.WriteLine("Simple Text")
        '     FS.Flush()
        '   SW.Close()
        '        FS.Close()
        '       sfh.Close()

    End Sub
End Class