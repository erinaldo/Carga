Imports System.Windows.Forms
Imports System.Drawing
Imports System.Data
Module ModItinerarios
    Public SwFlgDet As Integer = 0
    Public SwDetRuta As Integer = 0
    Public SwDetAge1 As Integer = 0
    Public SwDetAge2 As Integer = 0
    Public DtAyuRut As New System.Data.DataTable
    'Public bmActivo, bmPendiente, bm2, bmEliminado As Bitmap [mendoza - repite en modutil]
    Public bmpendiente, bm2 As Bitmap
    'Public Function ListaAgencias_2009() As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_LISTA_AGENCIAS", 0}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    'Public Function GrabaAgencias_2009(ByVal nacc As Integer, ByVal npais As Integer, ByVal ndepa As Integer, ByVal nprov As Integer, ByVal ndist As Integer, ByVal nund As Integer, ByVal vid As Integer, ByVal nnomage As String, ByVal napepat As String, ByVal napemat As String, ByVal ncont As String, ByVal ntele1 As String, ByVal ntele2 As String, ByVal nrpm1 As String, ByVal nrpm2 As String, ByVal nfax1 As String, ByVal nfax2 As String, ByVal nmail As String, ByVal ncorto As String, ByVal ncodi As String) As ADODB.Recordset
    '    Dim ObjUnd2 As Object() = {"PKG_IVOITINERARIOS.SP_INSUPD_AGENCIAS", 50, nacc, 1, vid, 1, ndist, 1, nprov, 1, ndepa, 1, npais, 1, nnomage, 2, napepat, 2, napemat, 2, ncont, 2, "000", 2, ntele1, 2, ntele2, 2, nfax1, 2, nfax2, 2, nmail, 2, nrpm1, 2, nrpm2, 2, 1, 1, 1, 1, "192.168.50.47", 2, ncorto, 2, nund, 1, ncodi, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(ObjUnd2)
    'End Function
    Public Function UbicaCombo(ByVal dva As DataView, ByVal dra As DataRowView, ByVal ncampo As String) As Integer
        Dim valor As String
        Dim filcb As Integer
        dva.Sort = ncampo
        valor = IIf(IsDBNull(dra(ncampo)) = True, 0, dra(ncampo))
        filcb = dva.Find(valor)
        If filcb < 0 Then
            filcb = 0
        End If
        Return filcb
    End Function
    Public Function UbicaCombo2(ByVal dva As DataView, ByVal dra As DataRowView, ByVal ncampo1 As String, ByVal ncampo2 As String, ByVal ncampo3 As String) As Integer
        Dim valor As Integer
        Dim valor2 As String
        Dim filcb As Integer
        Dim drc As DataRowView
        dva.Sort = ncampo1
        valor = IIf(IsDBNull(dra(ncampo2)) = True, 0, dra(ncampo2))
        filcb = dva.Find(valor)
        If filcb < 0 Then
            filcb = 0
        End If
        drc = dva.Item(filcb)
        valor2 = drc(ncampo3)
        dva.Sort = ncampo3
        filcb = dva.Find(valor2)
        If filcb < 0 Then
            filcb = 0
        End If
        Return filcb
    End Function
    Public Sub LlenaCombo2(ByVal dva As DataView, ByVal Cba As ComboBox, ByVal ncampo As String)
        dva.AllowNew = False
        Cba.DataSource = dva
        Cba.DisplayMember = ncampo
        Cba.ValueMember = ncampo
        dva.Sort = ncampo
    End Sub


    Public Sub LlenaCombo3(ByVal dva As DataView, ByVal Cba As ComboBox, ByVal ncampo As String, ByVal ncampo2 As String)
        dva.AllowNew = False
        Cba.DataSource = dva
        Cba.DisplayMember = ncampo
        Cba.ValueMember = ncampo2
        dva.Sort = ncampo
    End Sub

    Function CalculaFechaLlegada(ByVal dias As Double, ByVal hora As String, ByVal fecha_ini As Date) As Date
        Dim fecha_fin As Date
        Try
            If hora = "00:00" Then
                MessageBox.Show("Hora de Viaje Vacio...Verifique", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return fecha_fin
                Exit Function
            End If
            fecha_fin = DateAdd(DateInterval.Day, Convert.ToDouble(dias), fecha_ini)
            fecha_fin = DateAdd(DateInterval.Hour, Convert.ToDouble(Mid(Convert.ToString(hora), 1, 2)), fecha_fin)
            fecha_fin = DateAdd(DateInterval.Minute, Convert.ToDouble(Mid(Convert.ToString(hora), 4, 2)), fecha_fin)
            Return fecha_fin
        Catch ex As Exception
            MessageBox.Show("Formato de Fecha Incorrecta...Verifique", "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return fecha_fin
        End Try
    End Function
    'Public Sub IniciarImagenes()
    '    Try
    '        bmPendiente = New Bitmap("C:\icon\Pendiente.bmp")
    '        bmActivo = New Bitmap("C:\icon\Activo.bmp")
    '        bm2 = New Bitmap("C:\icon\Activo.bmp")
    '        bmEliminado = New Bitmap("C:\icon\Eliminado.bmp")

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    'End Sub    
    Function AsignaValorMasivo(ByVal ImpBase As Double, ByVal ImpPorc As String, ByVal ImpMonto As String) As Double
        Dim cifra, ctemp As Double
        Dim iMonto As Double = Val(ImpMonto)
        If ImpPorc = "0.00" Then
            If ImpMonto <> "0.00" Then
                cifra = Convert.ToDouble(ImpMonto)
                SwFlgDet = 1
            Else
                cifra = ImpBase
            End If
        Else
            If Val(iMonto) > 0 Then
                ctemp = iMonto * (Convert.ToDouble(ImpPorc) / 100)
                cifra = iMonto + ctemp
            Else
                ctemp = ImpBase * (Convert.ToDouble(ImpPorc) / 100)
                cifra = ImpBase + ctemp
            End If
            SwFlgDet = 1
        End If
        Return cifra
    End Function
    Public Function UbicaComboDirecto(ByVal dva As DataView, ByVal valor As String, ByVal ncampo1 As String, ByVal ncampo3 As String) As Integer
        Dim valor2 As String
        Dim filcb As Integer
        Dim drc As DataRowView
        dva.Sort = ncampo1
        'valor = IIf(IsDBNull(dra(ncampo2)) = True, 0, dra(ncampo2))
        filcb = dva.Find(valor)
        If filcb < 0 Then
            filcb = 0
        End If
        drc = dva.Item(filcb)
        valor2 = drc(ncampo3)
        dva.Sort = ncampo3
        filcb = dva.Find(valor2)
        If filcb < 0 Then
            filcb = 0
        End If
        Return filcb
    End Function
End Module
