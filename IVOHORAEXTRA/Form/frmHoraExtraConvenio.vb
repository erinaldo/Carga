Imports INTEGRACION_LN

Public Class frmHoraExtraConvenio
    Private intId As Integer
    Public Property id() As Integer
        Get
            Return intId
        End Get
        Set(ByVal value As Integer)
            intId = value
        End Set
    End Property

    Private Sub frmHoraExtraConvenio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim obj As New Cls_HoraExtra_LN
            Dim dt As DataTable = obj.ListarConvenio(id)
            Dim strLista(13) As String
            Dim str As String
            With Me.txtConvenio
                If dt.Rows.Count > 0 Then
                    strLista(1) = "" & dt.Rows(0).Item("trabajador")
                    strLista(2) = "" & dt.Rows(0).Item("dni")
                    strLista(3) = "" & dt.Rows(0).Item("direccion")
                    strLista(4) = "" & dt.Rows(0).Item("ingreso")
                    strLista(5) = "" & dt.Rows(0).Item("cargo")
                    strLista(6) = "" & dt.Rows(0).Item("sueldo")
                    strLista(7) = "" & dt.Rows(0).Item("fecha1")
                    strLista(8) = "" & dt.Rows(0).Item("hora1")
                    strLista(9) = "" & dt.Rows(0).Item("total1")
                    strLista(10) = "" & dt.Rows(0).Item("fecha2")
                    strLista(11) = "" & dt.Rows(0).Item("hora2")
                    strLista(12) = "" & dt.Rows(0).Item("total2")
                    strLista(13) = "" & FechaServidor()
                End If
                str = Space(130) & "CONVENIO PRIVADO  DE COMPENSACION DE HORAS EXTRAS" & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf
                str &= "Conste por el presente documento el Convenio Privado de Compensación de Horas Extras que celebran de una parte la empresa "
                str &= "TRANSPORTES EL PINO S.A.C., con RUC No. 20502324927, con domicilio en Jirón Manuel Echeandía Nº 303, San Luis, debidamente "
                str &= "representada por su Apoderada General Maria del Pilar Suarez Egoavil, , identificada con DNI Nº 40243308, según poderes "
                str &= "inscritos en la Partida Electrónica Nº 1128741 del Registro de Personas Jurídicas de Lima, a quien en adelante se le denominará "
                str &= "LA EMPRESA, y por la otra parte:" & strLista(1) & " identificado con DNI Nº " & strLista(2) & " "
                str &= "con domicilio en " & strLista(3) & " de Lima, a quien en adelante se le denominará EL TRABAJADOR; en los términos y condiciones siguientes:" & ControlChars.CrLf & ControlChars.CrLf
                str &= "PRIMERO: EL TRABAJADOR  ingreso a laborar para LA EMPRESA con fecha " & strLista(4) & ", desempeñando actualmente el cargo de " & strLista(5) & " "
                str &= "percibiendo una remuneración  mensual  ascendente  a  S/. " & strLista(6) & " Nuevos Soles." & ControlChars.CrLf & ControlChars.CrLf

                str &= "SEGUNDO: EL TRABAJADOR señala que durante los periodos señalados líneas abajo ha realizado horas extras, por lo cual LA EMPRESA le debe reconocer la compensación de las mismas." & ControlChars.CrLf & ControlChars.CrLf
                str &= "Fechas" & Space(12) & "Horas" & ControlChars.CrLf
                str &= strLista(7) & Space(5) & strLista(8) & ControlChars.CrLf & ControlChars.CrLf
                str &= "Total: " & strLista(9) & ControlChars.CrLf & ControlChars.CrLf

                str &= "TERCERO: Las partes acuerdan que las horas extras realizadas por EL TRABAJADOR durante el período señalado son de un total de " & strLista(9) & " horas." & ControlChars.CrLf & ControlChars.CrLf

                str &= "CUARTO: En ese sentido, las partes acuerdan que las  horas referidas en la Cláusula Tercera del presente documento serán compensadas en las siguientes fechas y horas:" & ControlChars.CrLf & ControlChars.CrLf
                str &= "Fechas" & Space(12) & "Horas" & ControlChars.CrLf
                str &= strLista(10) & Space(5) & strLista(11) & ControlChars.CrLf & ControlChars.CrLf
                str &= "Total: " & strLista(12) & ControlChars.CrLf & ControlChars.CrLf

                str &= "QUINTO: EL TRABAJADOR manifiesta su conformidad con los acuerdos antes referidos, no teniendo nada que reclamar por concepto de horas extras en  la LA EMPRESA o  a sus empleados, funcionarios, gerentes, directores, accionistas, dependientes y  representantes; señalando EL TRABAJADOR  además  que al  celebrar este  convenio no ha mediado  vicio  de  voluntad alguna,  ni  coacción,  habiendo  participado  en forma libre  y  voluntaria." & ControlChars.CrLf & ControlChars.CrLf
                str &= "SEXTO: Asimismo, EL TRABAJADOR manifiesta que no tiene nada que reclamar ante LA EMPRESA por concepto de horas extras referidas a periodos anteriores al señalado" & ControlChars.CrLf & ControlChars.CrLf
                str &= "SETIMO: Para todos los efectos del presente convenio las partes señalan como sus domicilios los que figuran en la parte introductoria de la misma, donde se entregarán todas las comunicaciones y notificaciones a que hubiere lugar. Surtiendo plenos efectos las comunicaciones que se reciban en los domicilios arriba mencionados." & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf & ControlChars.CrLf

                str &= "En señal de conformidad las partes suscriben  este documento en la ciudad de Lima, a los " & strLista(13)

                .Text = str
            End With
            'Return

            'Dim strRuta As String
            'Dim word As New Microsoft.Office.Interop.Word.Application
            'Dim docu As Microsoft.Office.Interop.Word.Document

            'strRuta = System.Windows.Forms.Application.StartupPath
            ''docu = word.Documents.Open("c:\backup\cpc.docx")
            'docu = word.Documents.Open(strRuta & "\cpc.docx")
            ''docu.Bookmarks("trabajador").Range.Text = "Juan Perez"

            'If dt.Rows.Count > 0 Then
            '    docu.Bookmarks("trabajador").Range.Text = dt.Rows(0).Item("trabajador")
            '    docu.Bookmarks("cargo").Range.Text = "" & dt.Rows(0).Item("cargo")
            '    docu.Bookmarks("direccion").Range.Text = "" & dt.Rows(0).Item("direccion")
            '    docu.Bookmarks("dni").Range.Text = "" & dt.Rows(0).Item("dni")
            '    docu.Bookmarks("fecha").Range.Text = FechaServidor()
            '    docu.Bookmarks("fecha1").Range.Text = "" & dt.Rows(0).Item("fecha1")
            '    docu.Bookmarks("fecha2").Range.Text = "" & dt.Rows(0).Item("fecha2")
            '    docu.Bookmarks("he").Range.Text = "" & dt.Rows(0).Item("total1")
            '    docu.Bookmarks("hora1").Range.Text = "" & dt.Rows(0).Item("hora1")
            '    docu.Bookmarks("hora2").Range.Text = "" & dt.Rows(0).Item("hora2")
            '    docu.Bookmarks("ingreso").Range.Text = "" & dt.Rows(0).Item("ingreso")
            '    docu.Bookmarks("sueldo").Range.Text = "" & dt.Rows(0).Item("sueldo")
            '    docu.Bookmarks("total1").Range.Text = "" & dt.Rows(0).Item("total1")
            '    docu.Bookmarks("total2").Range.Text = "" & dt.Rows(0).Item("total2")
            'End If
            'docu.ActiveWindow.Selection.WholeStory()
            'docu.ActiveWindow.Selection.Copy()
            'Dim data As IDataObject = Clipboard.GetDataObject
            'Me.txtConvenio.Rtf = data.GetData(DataFormats.Rtf).ToString
            'docu.Close(SaveChanges:=False)
            'word.Quit()
            'Return

            ''replace Carriage Return
            'txtConvenio.Text = txtConvenio.Text.Replace(Chr(13).ToString, vbCrLf.ToString)

            ''replace Line Feed
            'txtConvenio.Text = txtConvenio.Text.Replace(Chr(10).ToString, vbLf.ToString)

            ''replace Tabs - Assume 5 spaces for each tab
            'txtConvenio.Text = txtConvenio.Text.Replace(Chr(9).ToString, " ".ToString)

            '' Make a Word server object.
            'Dim word_server As New Word.Application

            '' Hide the server.
            'word_server.Visible = False

            '' Make a Word Document.
            'Dim doc As Word.Document = _
            'word_server.Documents.Add()
            'Dim rng As Word.Range

            '' Make a Range to represent the Document.
            'rng = doc.Range()

            '' Copy the text into the Document.
            'rng.Text = txtConvenio.Text

            '' Activate the Document and call its CheckSpelling method.
            'doc.Activate()
            'doc.CheckSpelling()

            '' Copy the results back into the TextBox, trimming off trailing CR and LF characters.
            'Dim chars() As Char = {CType(vbCr, Char), _
            'CType(vbLf, Char)}
            'txtConvenio.Text = doc.Range().Text.Trim(chars)

            ''Modified by Burt Gardner
            ''Replace the following text after coming from Microsoft Word, because
            ''we dont want Word's special characters.

            ''replace Carriage Return
            'txtConvenio.Text = txtConvenio.Text.Replace(Chr(13).ToString, vbCrLf.ToString)

            ''replace Line Feed
            'txtConvenio.Text = txtConvenio.Text.Replace(Chr(10).ToString, vbLf.ToString)

            ''replace Tabs - Assume 5 spaces for each tab
            'txtConvenio.Text = txtConvenio.Text.Replace(Chr(9).ToString, " ".ToString)

            '' Close the Document, not saving changes.
            'doc.Close(SaveChanges:=False)

            '' Close the Word server.
            'word_server.Quit()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub chkAceptar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAceptar.CheckedChanged
        Me.btnAceptar.Enabled = Me.chkAceptar.Checked
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

    End Sub
End Class