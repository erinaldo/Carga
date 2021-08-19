Public Class FrmRegistro_auto_guias
    Dim numero As Long = 0
    'tarifas
    '-------
    Dim tarifa_Peso As Double
    Dim tarifa_Volumen As Double
    Dim tarifa_Articulo As Double
    Dim Monto_Base As Double
    Dim tarifa_Sobre As Double

    Dim ObjGeneral As New ClsLbTepsa.dtoGENERAL
    Dim ObjPersona As New ClsLbTepsa.dtoPersona
    Dim dvlistar_persona_todos As DataView
    Dim dvlistar_forma_pago As DataView
    Dim dvidtipo_entrega As DataView
    Dim dvListar_facturas As DataView
    Dim dvListar_facturas2 As DataView


    Dim ObjFactura As New ClsLbTepsa.dtoFACTURA

    Dim DT As DataTable
    Dim xIMPRESORA As Integer

    Dim Colllistar_persona_todos As New Collection
    Dim Iwinlistar_persona_todos As New AutoCompleteStringCollection
    Dim ObjReport As New ClsLbTepsa.dtoFrmReport
    Dim objREGISTRO_AUTO_GUIAS As New ClsLbTepsa.dtoREGISTRO_AUTO_GUIAS
    Dim bIngreso As Boolean = False
    Public hnd As Long

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub


   
    Sub FORMAT_GRILLA(ByVal DV As DataView)
        DGV.Columns.Clear()

        With DGV
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = DV
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With




        Dim ID As New DataGridViewTextBoxColumn
        With ID
            .HeaderText = "ID"
            .Name = "ID"
            .DataPropertyName = "ID"
            .Width = 60
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_RECOJO As New DataGridViewTextBoxColumn
        With FECHA_RECOJO
            .HeaderText = "FECHA_RECOJO"
            .Name = "FECHA_RECOJO"
            .DataPropertyName = "FECHA_RECOJO"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim RUC_CLIENTE As New DataGridViewTextBoxColumn
        With RUC_CLIENTE
            .HeaderText = "RUC_CLIENTE"
            .Name = "RUC_CLIENTE"
            .DataPropertyName = "RUC_CLIENTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim IDTIPO_ENTREGA As New DataGridViewTextBoxColumn
        With IDTIPO_ENTREGA
            .HeaderText = "IDTIPO_ENTREGA"
            .Name = "IDTIPO_ENTREGA"
            .DataPropertyName = "IDTIPO_ENTREGA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Nombre_destinatario As New DataGridViewTextBoxColumn
        With Nombre_destinatario
            .HeaderText = "Nombre_destinatario"
            .Name = "Nombre_destinatario"
            .DataPropertyName = "Nombre_destinatario"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Documento_Destinatario As New DataGridViewTextBoxColumn
        With Documento_Destinatario
            .HeaderText = "Documento_Destinatario"
            .Name = "Documento_Destinatario"
            .DataPropertyName = "Documento_Destinatario"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Direccion_Destinatario As New DataGridViewTextBoxColumn
        With Direccion_Destinatario
            .HeaderText = "Direccion_Destinatario"
            .Name = "Direccion_Destinatario"
            .DataPropertyName = "Direccion_Destinatario"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim Nro_cajas As New DataGridViewTextBoxColumn
        With Nro_cajas
            .HeaderText = "Nro_cajas"
            .Name = "Nro_cajas"
            .DataPropertyName = "Nro_cajas"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim PESO As New DataGridViewTextBoxColumn
        With PESO
            .HeaderText = "PESO"
            .Name = "PESO"
            .DataPropertyName = "PESO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim VOLUMEN As New DataGridViewTextBoxColumn
        With VOLUMEN
            .HeaderText = "VOLUMEN"
            .Name = "VOLUMEN"
            .DataPropertyName = "VOLUMEN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim nro_sobres As New DataGridViewTextBoxColumn
        With nro_sobres
            .HeaderText = "nro_sobres"
            .Name = "nro_sobres"
            .DataPropertyName = "nro_sobres"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N0"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim Guia_Remision As New DataGridViewTextBoxColumn
        With Guia_Remision
            .HeaderText = "Guia_Remision"
            .Name = "Guia_Remision"
            .DataPropertyName = "Guia_Remision"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DGV

            .Columns.AddRange(ID, FECHA_GUIA, FECHA_RECOJO, RUC_CLIENTE, DESTINO, IDTIPO_ENTREGA, Nombre_destinatario, Documento_Destinatario, Direccion_Destinatario, Nro_cajas, PESO, VOLUMEN, nro_sobres, Guia_Remision)

        End With
    End Sub
    Private Sub BtnBuscarArchi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscarArchi.Click
        Me.TxtNro_Grupo_result.Text = ""
        Dim OFD As New OpenFileDialog

        OFD.Filter = "txt files (*.txt)|*.txt"
        OFD.FilterIndex = 1

        If OFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            If Not OFD.OpenFile Is Nothing Then
                Me.TxtRutaArchi.Text = OFD.FileName
                leer_texto()
                BtnRegis.Enabled = True
            Else
                Me.TxtRutaArchi.Text = ""
                DGV.DataSource = Nothing
                BtnRegis.Enabled = False
            End If
        Else
            Me.TxtRutaArchi.Text = ""
            DGV.DataSource = Nothing
            BtnRegis.Enabled = False
        End If

        OFD.Reset()
        OFD.Dispose()


    End Sub
    Private Function CREAR_CAMPOS() As DataTable
        Dim namesTable As DataTable = New DataTable("GUIAS_ENVIO")
        Dim id As DataColumn = New DataColumn()
        id.DataType = System.Type.GetType("System.String")
        id.ColumnName = "id"
        id.AutoIncrement = False
        namesTable.Columns.Add(id)


        Dim FECHA_GUIA As DataColumn = New DataColumn()
        FECHA_GUIA.DataType = System.Type.GetType("System.String")
        FECHA_GUIA.ColumnName = "FECHA_GUIA"
        namesTable.Columns.Add(FECHA_GUIA)

        Dim FECHA_RECOJO As DataColumn = New DataColumn()
        FECHA_RECOJO.DataType = System.Type.GetType("System.String")
        FECHA_RECOJO.ColumnName = "FECHA_RECOJO"
        namesTable.Columns.Add(FECHA_RECOJO)


        Dim RUC_CLIENTE As DataColumn = New DataColumn()
        RUC_CLIENTE.DataType = System.Type.GetType("System.String")
        RUC_CLIENTE.ColumnName = "RUC_CLIENTE"
        namesTable.Columns.Add(RUC_CLIENTE)


        Dim DESTINO As DataColumn = New DataColumn()
        DESTINO.DataType = System.Type.GetType("System.String")
        DESTINO.ColumnName = "DESTINO"
        namesTable.Columns.Add(DESTINO)

        Dim IDTIPO_ENTREGA As DataColumn = New DataColumn()
        IDTIPO_ENTREGA.DataType = System.Type.GetType("System.Int32")
        IDTIPO_ENTREGA.ColumnName = "IDTIPO_ENTREGA"
        namesTable.Columns.Add(IDTIPO_ENTREGA)

        Dim Nombre_destinatario As DataColumn = New DataColumn()
        Nombre_destinatario.DataType = System.Type.GetType("System.String")
        Nombre_destinatario.ColumnName = "Nombre_destinatario"
        namesTable.Columns.Add(Nombre_destinatario)

        Dim Documento_Destinatario As DataColumn = New DataColumn()
        Documento_Destinatario.DataType = System.Type.GetType("System.String")
        Documento_Destinatario.ColumnName = "Documento_Destinatario"
        namesTable.Columns.Add(Documento_Destinatario)

        Dim Direccion_Destinatario As DataColumn = New DataColumn()
        Direccion_Destinatario.DataType = System.Type.GetType("System.String")
        Direccion_Destinatario.ColumnName = "Direccion_Destinatario"
        namesTable.Columns.Add(Direccion_Destinatario)

        Dim Nro_cajas As DataColumn = New DataColumn()
        Nro_cajas.DataType = System.Type.GetType("System.Int32")
        Nro_cajas.ColumnName = "Nro_cajas"
        namesTable.Columns.Add(Nro_cajas)

        Dim Peso As DataColumn = New DataColumn()
        Peso.DataType = System.Type.GetType("System.Double")
        Peso.ColumnName = "Peso"
        namesTable.Columns.Add(Peso)

        Dim Volumen As DataColumn = New DataColumn()
        Volumen.DataType = System.Type.GetType("System.Double")
        Volumen.ColumnName = "Volumen"
        namesTable.Columns.Add(Volumen)

        Dim Nro_sobres As DataColumn = New DataColumn()
        Nro_sobres.DataType = System.Type.GetType("System.Int32")
        Nro_sobres.ColumnName = "Nro_sobres"
        namesTable.Columns.Add(Nro_sobres)


        Dim Guia_Remision As DataColumn = New DataColumn()
        Guia_Remision.DataType = System.Type.GetType("System.String")
        Guia_Remision.ColumnName = "Guia_Remision"
        namesTable.Columns.Add(Guia_Remision)



        ' Create an array for DataColumn objects.
        Dim keys(0) As DataColumn
        keys(0) = id
        namesTable.PrimaryKey = keys
        ' Return the new DataTable.

        CREAR_CAMPOS = namesTable

    End Function
    Private Sub leer_texto()

        DT = New DataTable
        DT = CREAR_CAMPOS()

        Dim oFile As System.IO.File
        Dim oRead As System.IO.StreamReader
        Dim MyDatarow As DataRow

        oRead = IO.File.OpenText(Me.TxtRutaArchi.Text)

        Try

            While oRead.Peek <> -1
                Dim cadena As String = oRead.ReadLine()



                MyDatarow = DT.NewRow

                MyDatarow("id") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("fecha_recojo") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("fecha_GUIA") = Format(CDate(fnGetHora_()), "dd/MM/yyyy")

                MyDatarow("ruc_cliente") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("destino") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("idtipo_entrega") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("Nombre_destinatario") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("Documento_Destinatario") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("Direccion_Destinatario") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("Nro_cajas") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("peso") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("volumen") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("nro_sobres") = Mid(cadena, 1, InStr(cadena, ",") - 1)
                cadena = Mid(cadena, InStr(cadena, ",") + 1, Len(cadena) - InStr(cadena, ","))

                MyDatarow("Guia_Remision") = Mid(cadena, 1, Len(cadena))

                DT.Rows.Add(MyDatarow)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad del Sistema...")
            MsgBox(MyDatarow("id"))
        End Try
        FORMAT_GRILLA(DT.DefaultView)
    End Sub
    Private Function fnvalidar() As Boolean
        Label4.Text = "Validando Cantidades..."
        Label4.Visible = True
        pb.Visible = True
        pb.Minimum = 0
        pb.Maximum = DGV.RowCount - 1

        Label4.Text = "Validando Cantidades..."
        For i As Integer = 0 To DGV.RowCount - 1
            pb.Value = i
            DGV.CurrentCell = DGV.Rows(i).Cells(1)
            If DGV.CurrentRow.Cells("peso").Value = 0 And DGV.CurrentRow.Cells("volumen").Value = 0 And DGV.CurrentRow.Cells("nro_sobres").Value = 0 Then
                MsgBox("Existe un registro, con Peso, Volmen y Nro de Sobres igual a cero (0) Registro nro" & DGV.CurrentRow.Cells("ID").Value & "...", MsgBoxStyle.Exclamation, "Seguridad del sistema...")
                Label4.Visible = False
                pb.Visible = False
                Return False
            End If

        Next

        Label4.Text = "Validando Tarifas..."
        For i As Integer = 0 To DGV.RowCount - 1
            pb.Value = i
            DGV.CurrentCell = DGV.Rows(i).Cells(1)

            Dim MydataRow As DataRow = DT.Rows(i)

            Dim DV As New DataView

            With objREGISTRO_AUTO_GUIAS

                .CODIGO_IATA = DGV.CurrentRow.Cells("DESTINO").Value

                objGuiaEnvio.sNU_DOCU_SUNAT = DGV.CurrentRow.Cells("RUC_CLIENTE").Value
                objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad
                'Datahelper
                DV = .sp_recu_idunidad_agencia()
                '
                objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = DV.Table.Rows(0)("P_idunidad_agencia")

                objGuiaEnvio.iIDCENTRO_COSTO = 999
                If fnTarifario(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, objGuiaEnvio.sNU_DOCU_SUNAT) = False Then
                    'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
                    If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                        tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                        tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                        tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                        Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                        tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre


                        'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen + 100000)
                    ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA() = True Then 'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                        tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                        tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                        tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                        Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base

                    Else
                        MsgBox("NO EXISTE TARIFA PARA ESTE ORIGEN Y DESTINO, NI ASOCIADO A UNA TARIFA DEL CLIENTER, egistro Nro." & DGV.CurrentRow.Cells("ID").Value & ", Destino " & DGV.CurrentRow.Cells("DESTINO").Value & "...", MsgBoxStyle.Exclamation, "Seguridad del sistema...")
                        Label4.Visible = False
                        pb.Visible = False
                        Return False
                    End If
                End If
            End With
        Next

        Label4.Visible = False
        pb.Visible = False
        Return True

    End Function

    Private Sub BtnRegis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRegis.Click
        If fnvalidar() = False Then
            Exit Sub
        End If


        Dim objGuiaEnvio As New dtoGuiaEnvio

        'If ObjVentaCargaContado.fnNroDocuemnto(3) = True Then
        '    TxtGuiaEnvio.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
        'Else
        '    MsgBox("No podra Realizar esta Operacion El Nro de Guia Envio no esta configurado")
        'End If

        'Datahyelper
        objREGISTRO_AUTO_GUIAS.sp_recupera_nro_grupo()

        Label4.Visible = True
        pb.Visible = True

        pb.Minimum = 0
        pb.Maximum = DT.Rows.Count
        Label4.Text = "Registrando guias..."

        For i As Integer = 0 To DT.Rows.Count - 1
            Try
                pb.Value = i

                Dim MydataRow As DataRow = DT.Rows(i)

                Dim DV As New DataView

                With objREGISTRO_AUTO_GUIAS

                    .CODIGO_IATA = MydataRow("DESTINO")

                    objGuiaEnvio.sNU_DOCU_SUNAT = MydataRow("RUC_CLIENTE")
                    objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad
                    'Datahelper
                    DV = .sp_recu_idunidad_agencia()

                    objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = DV.Table.Rows(0)("P_idunidad_agencia")

                    objGuiaEnvio.iIDCENTRO_COSTO = 999
                    If fnTarifario(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO, objGuiaEnvio.sNU_DOCU_SUNAT) = False Then
                        'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
                        If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                            tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                            tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                            tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                            Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                            tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre


                            'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen + 100000)
                        ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA() = True Then 'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                            tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                            tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                            tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                            Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base

                        Else
                            MsgBox("NO EXISTE TARIFA PARA ESTE ORIGEN Y DESTINO, NI ASOCIADO A UNA TARIFA DEL CLIENTE", MsgBoxStyle.Information, "REVICE SUS DATOS")
                        End If

                    End If


                    .FECHA_GUIA = MydataRow("FECHA_GUIA")
                    'If ObjVentaCargaContado.fnNroDocuemnto(3) = True Then
                    '    .NRO_GUIA = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                    'End If

                    .NRO_GUIA = "9999999999999"
                    .CODIGO_CLIENTE = MydataRow("RUC_CLIENTE")
                    'Datahelper
                    .IDPERSONA = .sp_recu_datos_cliente()
                    '
                    .IDTIPO_ENTREGA_CARGA = MydataRow("idtipo_entrega")
                    .IDFORMA_PAGO = 2
                    .IDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad
                    .IDCIUDAD_TRANSITO = dtoUSUARIOS.m_idciudad
                    .IDUNIDAD_AGENCIA_DESTINO = DV.Table.Rows(0)("P_idunidad_agencia")
                    .IDAGENCIAS = dtoUSUARIOS.iIDAGENCIAS

                    .MONTO_BASE = Monto_Base
                    .TOTAL_PESO = MydataRow("PESO")
                    If Not MydataRow("PESO") = 0 Then
                        .CANTIDAD = MydataRow("Nro_cajas")
                    End If


                    .TOTAL_VOLUMEN = MydataRow("VOLUMEN")

                    If Not MydataRow("VOLUMEN") = 0 Then
                        .CANTIDAD_X_UNIDAD_VOLUMEN = MydataRow("Nro_cajas")
                    End If

                    'datos del remitente
                    '-------------------
                    .x_iIDCONTACTO_REMITENTE = "0"
                    .x_iIDDIRECCION_REMITENTE = ""
                    .x_iIDTEFONO_REMITENTE = ""
                    .NRODOCUMENTO = MydataRow("RUC_CLIENTE")
                    .NOMBRES = ""
                    .DIRECCION = ""

                    .NOMBRES_REMITENTE_ORI = ""
                    .NRODOCUMENTO_REMITENTE_ORI = MydataRow("RUC_CLIENTE")


                    'datos del contacto remitente
                    '----------------------------
                    .x_iIDCONTACTO_DESTINATARIO = "0"
                    .x_iIDDIRECCION_DESTINATARIO = ""
                    .x_iIDTEFONO_CONSIGNADO = 0


                    'datos del destinatario
                    '----------------------
                    .NRODOCUMENTO_DESTI = MydataRow("Documento_Destinatario")
                    .NROCOMUNICACION_CONTACTO_DESTI = ""
                    .NOMBRES_DESTI = MydataRow("Nombre_destinatario")

                    .DIRECCION_DESTI = MydataRow("Direccion_Destinatario")

                    .docu_clien = MydataRow("guia_remision")

                    If .docu_clien = "" Then
                        .docu_clien = "0"
                    End If





                    'solamente cuando la venta es por articulos en esta caso es solo volumen y peso no se considera

                    .CANTIDAD_X_UNIDAD_ARTI = 0

                    .PRECIO_X_UNIDAD = tarifa_Articulo



                    .IDUSUARIO_PERSONAL = dtoUSUARIOS.IdLogin
                    .IDROL_USUARIO = dtoUSUARIOS.IdRol

                    .IP = dtoUSUARIOS.IP
                    .IDESTADO_REGISTRO = 2


                    .PRECIO_X_PESO = tarifa_Peso
                    .PRECIO_X_VOLUMEN = tarifa_Volumen
                    .CARGO = 0
                    .NROCOMUNICACION_CONTACTO = ""


                    .IDCENTRO_COSTO = 999
                    .CANTIDAD_SOBRES = MydataRow("NRO_SOBRES")
                    If Not MydataRow("NRO_SOBRES") = 0 Then
                        .IDSINO_SOBRES = 1
                    Else
                        .IDSINO_SOBRES = 0
                    End If

                    .IDAGENCIAS_DESTINO = DV.Table.Rows(0)("P_IDAGENCIAS")

                    .IMPUESTO = dtoUSUARIOS.vImpuesto

                    .TOTAL_COSTO = MydataRow("PESO") * .PRECIO_X_PESO + _
                    MydataRow("volumen") * .PRECIO_X_VOLUMEN + _
                    MydataRow("NRO_SOBRES") * .PRECIO_SOBRES + _
                    Monto_Base

                    .MONTO_IMPUESTO = FormatNumber(.TOTAL_COSTO * dtoUSUARIOS.vImpuesto, 2)
                    .TOTAL_COSTO = FormatNumber(.TOTAL_COSTO * (1 + dtoUSUARIOS.vImpuesto))


                    'Datahelper
                    If .SP_INS_GUIAS_ENVIO_VII() = True Then

                        'ObjVentaCargaContado.fnIncrementarNroDoc(3)

                        'If ObjVentaCargaContado.fnNroDocuemnto(3) = True Then
                        '    TxtGuiaEnvio.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
                        'Else
                        '    MsgBox("No podra Realizar esta Operacion El Nro de Guia Envio no esta configurado")
                        'End If


                    End If

                    TxtNro_Grupo_result.Text = .nro_grupo
                    BtnRegis.Enabled = False

                End With

            Catch eex As Exception
                MsgBox(eex.ToString, MsgBoxStyle.Exclamation, "Seguridad el Sistema..")

            End Try


        Next

        Label4.Visible = False
        pb.Visible = False
    End Sub
    Private Function fnTarifario(ByVal v_idunidad_agencia_destino As Long, ByVal v_codigo_cliente As String) As Boolean
        Dim flag As Boolean = False
        Try

            'Para Traer en una sola la tarifa Origen Destino
            tarifa_Peso = 0
            tarifa_Volumen = 0
            tarifa_Articulo = 0
            Monto_Base = 0
            objGuiaEnvio.sNU_DOCU_SUNAT = v_codigo_cliente
            'objGuiaEnvio.iIDUNIDAD_AGENCIA = 100
            'objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = 575
            Dim idOrigenvar As Integer = dtoUSUARIOS.m_idciudad
            Dim idDestinovar As Integer = v_idunidad_agencia_destino

            'MsgBox(objGuiaEnvio.iIDUNIDAD_AGENCIA)
            'MsgBox(objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO)

            'objGuiaEnvio.iIDUNIDAD_AGENCIA = Int(coll_iOrigen.Item(idOrigenvar.ToString))
            'objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = Int(coll_iOrigen.Item(idDestinovar.ToString))

            ' ''Try

            ' ''    objGuiaEnvio.iIDCENTRO_COSTO = Int(objGuiaEnvio.coll_Sub_Cuenta.Item(cmbSubCuenta.SelectedIndex.ToString))
            ' ''Catch ex As Exception
            ' ''    objGuiaEnvio.iIDCENTRO_COSTO = 0

            ' ''End Try

            objGuiaEnvio.iIDCENTRO_COSTO = 0




            objGuiaEnvio.iIDUNIDAD_AGENCIA = dtoUSUARIOS.m_idciudad


            objGuiaEnvio.iIDUNIDAD_AGENCIA_DESTINO = v_idunidad_agencia_destino
            'Mod. 27/08/2009 -->Omendoza - Pasando al datahelper   
            If objGuiaEnvio.fnLISTA_TARIFA_CLIENTE() = True Then
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base
                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Sobre

                flag = True

                'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen + 100000)
            ElseIf objGuiaEnvio.fnTARIFA_PUBLICA_CARGA() = True Then 'Mod. 26/08/2009 -->Omendoza - Pasando al datahelper   
                tarifa_Peso = objGuiaEnvio.iTarifa_Publica_Monto_Peso
                tarifa_Volumen = objGuiaEnvio.iTarifa_Publica_Monto_Volumen
                tarifa_Articulo = objGuiaEnvio.dPRECIO_X_UNIDAD
                Monto_Base = objGuiaEnvio.iTarifa_Publica_Monto_Base

                tarifa_Sobre = objGuiaEnvio.iTarifa_Publica_Monto_Base_Xpostal
                flag = True

                'MsgBox(Monto_Base + objGuiaEnvio.iTarifa_Publica_Monto_Peso + objGuiaEnvio.iTarifa_Publica_Monto_Volumen)
            Else
                flag = False
                MsgBox("NO EXISTE TARIFA PARA ESTE ORIGEN Y DESTINO, NI ASOCIADO A UNA TARIFA DEL CLIENTE", MsgBoxStyle.Information, "REVICE SUS DATOS")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flag
    End Function

    Private Sub FrmRegistro_auto_guias_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
    End Sub

    Private Sub FrmRegistro_auto_guias_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        G_Fila = Acceso.ObtieneFila(Me, Me.hnd)
        Acceso.Eliminar(Me, G_Fila)
    End Sub

    Private Sub FrmRegistro_auto_guias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            iProceso = 0
            'ObjWebService.fnWebService(1, 206663, 56)

            Dim objREGISTRO_AUTO_GUIAS As New ClsLbTepsa.dtoREGISTRO_AUTO_GUIAS
            Dim objGuiaEnvio As New dtoGuiaEnvio

            If ObjVentaCargaContado.fnNroDocuemnto(3) = True Then
                TxtGuiaEnvio.Text = RellenoRight(11, ObjVentaCargaContado.NroDoc)
            Else
                MsgBox("No podra Realizar esta Operacion El Nro de Guia Envio no esta configurado")
            End If
            ' objgeneral.fnlistar_forma_pago(dvlistar_forma_pago, Me.cbidforma_pago, VOCONTROLUSUARIO)
            'dvlistar_forma_pago.RowFilter = "idforma_pago <> 2"
            'cbidforma_pago.DataSource = dvlistar_forma_pago
            'cbidforma_pago.DisplayMember = "FORMA_PAGO"
            'cbidforma_pago.ValueMember = "IDFORMA_PAGO"

            'objgeneral.fnlistar_tipo_comprobante(dvlistar_forma_pago, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            'dvlistar_forma_pago.RowFilter = "IDTIPO_COMPROBANTE = 1 or IDTIPO_COMPROBANTE = 2 or IDTIPO_COMPROBANTE = 3"
            'Mod.19/09/2009 -->Omendoza - Pasando al datahelper   
            ObjGeneral.SP_L_ESTADO_ENVIO(Me.CBIDESTADO_ENVIO)
            '
            'objgeneral.FNLISTAR_TIPO_MONEDA(dvlistar_tipo_moneda, Me.cbidtipo_comprobante, VOCONTROLUSUARIO)
            ObjGeneral.FN_cmb_Listar_agencias(Me.cmbAgencia)
            ObjPersona.CODIGO_CLIENTE = "NULL"
            ObjPersona.IDTIPO_PERSONA = 0
            ObjPersona.IDPERSONA = 0




            'datahelper 
            dvlistar_persona_todos = ObjPersona.FNLISTAR_PERSONA(ObjPersona.IDTIPO_PERSONA, ObjPersona.IDPERSONA, ObjPersona.CODIGO_CLIENTE)
            Dim ObjProcesos As New ClsLbTepsa.dtoProcesos
            ObjProcesos.fnCargar_iWin_r(Me.txtidpersona, dvlistar_persona_todos, Colllistar_persona_todos, Iwinlistar_persona_todos, 0)



            ObjGeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA)
            ObjGeneral.FN_L_UNIDAD_agencia_(Me.CBIDUNIDAD_AGENCIA_DESTINO)

            'objgeneral.fn_L_TIPO_ENTREGA(dvidtipo_entrega, Me.cbidtipo_entrega, VOCONTROLUSUARIO)

            'Me.cbidforma_pago.SelectedIndex = -1
            'Me.cbidtipo_comprobante.SelectedIndex = -1
            Me.cmbAgencia.SelectedIndex = -1
            Me.cmbUsuarios.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA.SelectedIndex = -1
            Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedIndex = -1
            'Me.cbidtipo_entrega.SelectedIndex = -1
            Me.CBIDESTADO_ENVIO.SelectedIndex = -1

            BtnRegis.Enabled = False


            bIngreso = False
            Dim dt As DataTable = Acceso.ObtieneConfiguracion(G_Rol, G_Fila)
            Acceso.AplicaConfiguracion(dt, Me, ContextMenuStrip)
            bIngreso = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub txtidpersona_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtidpersona.GotFocus, _
   DTPFECHAINICIOFACTURA.GotFocus, _
   DTPFECHAFINALFACTURA.GotFocus, _
       tbnro_factura.GotFocus, _
       cmbAgencia.GotFocus, _
       cmbUsuarios.GotFocus, _
       CBIDUNIDAD_AGENCIA.GotFocus, _
       CBIDUNIDAD_AGENCIA_DESTINO.GotFocus, _
       RBSINIMPRE.GotFocus, _
       RBIMPRE.GotFocus, _
       RBAMBOS.GotFocus, _
       RBREIMPRE.GotFocus, _
        CBIDESTADO_ENVIO.GotFocus

        dgv1.DataSource = Nothing
    End Sub
    Private Sub cmbAgencia_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAgencia.SelectionChangeCommitted
        Dim p_id_rol_usuario, p_idagencia As Int64
        p_id_rol_usuario = 0
        If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
            p_idagencia = CType(Me.cmbAgencia.SelectedValue, Int64)
            'datahelper
            ObjGeneral.FN_cmb_LISTAR_USUARIOS_AGENCIAS(Me.cmbUsuarios, p_id_rol_usuario, p_idagencia)
        Else
            cmbUsuarios.DataSource = Nothing
        End If
        Me.cmbUsuarios.SelectedIndex = -1

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click



        If Me.TabControl2.SelectedIndex = 1 Then
            listar_facturas2()
        Else
            listar_facturas()
        End If

        numero = 0
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then
            Me.btnImpri.Enabled = False
        Else
            Me.btnImpri.Enabled = True
        End If

        Label18.Text = IIf(numero = 0, "", numero)

        If IsNumeric(Me.TxtNroGuiaIni.Text) Then
            If numero = 0 Then
                Me.Label15.Text = ""
                Label23.Text = ""
            Else
                Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
                Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
            End If
        Else
            Me.Label15.Text = ""
            Label23.Text = ""
        End If



    End Sub
    Private Sub listar_facturas2()
        Try

            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else

                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"


            'If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
            '    ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            'Else
            '    ObjFactura.IDTIPO_COMPROBANTE = 0
            'End If

            ObjFactura.IDTIPO_COMPROBANTE = 0

            ObjFactura.IDTIPO_MONEDA = 0
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjFactura.IDUSUARIO_PERSONAL = 0
            End If

            If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                ObjFactura.NRO_FACTURA = 0
            Else
                ObjFactura.NRO_FACTURA = Me.tbnro_factura.Text.Trim
            End If
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjFactura.IDAGENCIAS = 0
            End If

            'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
            '    ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            'Else
            '    ObjFactura.IDFORMA_PAGO = 0
            'End If

            ObjFactura.IDFORMA_PAGO = 0

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjFactura.IDUNIDAD_ORIGEN = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjFactura.IDUNIDAD_DESTINO = 0
            End If

            'If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
            '    ObjFactura.idtipo_entrega = Me.cbidtipo_entrega.SelectedValue
            'Else
            '    ObjFactura.idtipo_entrega = 0
            'End If

            ObjFactura.IDTIPO_ENTREGA = 0

            If Not IsNothing(Me.CBIDESTADO_ENVIO.SelectedValue) Then
                ObjFactura.IDESTADO_ENVIO = Me.CBIDESTADO_ENVIO.SelectedValue
            Else
                ObjFactura.IDESTADO_ENVIO = 0
            End If

            ObjFactura.NRO_GRUPO = Val(Me.TxtNro_grupo.Text)

            If Me.RBIMPRE.Checked = True Then
                ObjFactura.SITU_IMPRESION = "IMPR"
            ElseIf Me.RBREIMPRE.Checked = True Then
                ObjFactura.SITU_IMPRESION = "REIM"
            ElseIf Me.RBSINIMPRE.Checked = True Then
                ObjFactura.SITU_IMPRESION = "SIIM"
            ElseIf Me.RBAMBOS.Checked = True Then
                ObjFactura.SITU_IMPRESION = "AMBO"
            End If
            'datahelper
            dvListar_facturas2 = ObjFactura.SP_LIST_GUIAS_AUTO_GENE2()

            If dvListar_facturas2.Count <= 0 Then
                MsgBox("No existen registros", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End If

            FORMAT_GRILLA2()

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Private Sub listar_facturas()
        Try




            If Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text) = -1 Then
                ObjFactura.IDPERSONA = 0
            Else

                ObjFactura.IDPERSONA = Int(Colllistar_persona_todos.Item(Me.Iwinlistar_persona_todos.IndexOf(Me.txtidpersona.Text).ToString))
            End If
            If Me.DTPFECHAINICIOFACTURA.Enabled = True Then ObjFactura.FECHA_INICIO = Me.DTPFECHAINICIOFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_INICIO = "NULL"
            If Me.DTPFECHAFINALFACTURA.Enabled = True Then ObjFactura.FECHA_FINAL = Me.DTPFECHAFINALFACTURA.Value.ToShortDateString Else ObjFactura.FECHA_FINAL = "NULL"


            'If Not IsNothing(Me.cbidtipo_comprobante.SelectedValue) Then
            '    ObjFactura.IDTIPO_COMPROBANTE = Me.cbidtipo_comprobante.SelectedValue
            'Else
            '    ObjFactura.IDTIPO_COMPROBANTE = 0
            'End If

            ObjFactura.IDTIPO_COMPROBANTE = 0

            ObjFactura.IDTIPO_MONEDA = 0
            If Not IsNothing(Me.cmbUsuarios.SelectedValue) Then
                ObjFactura.IDUSUARIO_PERSONAL = Me.cmbUsuarios.SelectedValue
            Else
                ObjFactura.IDUSUARIO_PERSONAL = 0
            End If

            If Len(Me.tbnro_factura.Text.Trim) = 0 Then
                ObjFactura.NRO_FACTURA = 0
            Else
                ObjFactura.NRO_FACTURA = Me.tbnro_factura.Text.Trim
            End If
            If Not IsNothing(Me.cmbAgencia.SelectedValue) Then
                ObjFactura.IDAGENCIAS = Me.cmbAgencia.SelectedValue
            Else
                ObjFactura.IDAGENCIAS = 0
            End If

            'If Not IsNothing(Me.cbidforma_pago.SelectedValue) Then
            '    ObjFactura.IDFORMA_PAGO = Me.cbidforma_pago.SelectedValue
            'Else
            '    ObjFactura.IDFORMA_PAGO = 0
            'End If

            ObjFactura.IDFORMA_PAGO = 0

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA.SelectedValue) Then
                ObjFactura.IDUNIDAD_ORIGEN = Me.CBIDUNIDAD_AGENCIA.SelectedValue
            Else
                ObjFactura.IDUNIDAD_ORIGEN = 0
            End If

            If Not IsNothing(Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue) Then
                ObjFactura.IDUNIDAD_DESTINO = Me.CBIDUNIDAD_AGENCIA_DESTINO.SelectedValue
            Else
                ObjFactura.IDUNIDAD_DESTINO = 0
            End If

            'If Not IsNothing(Me.cbidtipo_entrega.SelectedValue) Then
            '    ObjFactura.idtipo_entrega = Me.cbidtipo_entrega.SelectedValue
            'Else
            '    ObjFactura.idtipo_entrega = 0
            'End If

            ObjFactura.IDTIPO_ENTREGA = 0

            If Not IsNothing(Me.CBIDESTADO_ENVIO.SelectedValue) Then
                ObjFactura.IDESTADO_ENVIO = Me.CBIDESTADO_ENVIO.SelectedValue
            Else
                ObjFactura.IDESTADO_ENVIO = 0
            End If

            ObjFactura.NRO_GRUPO = Val(Me.TxtNro_grupo.Text)

            If Me.RBIMPRE.Checked = True Then
                ObjFactura.SITU_IMPRESION = "IMPR"
            ElseIf Me.RBREIMPRE.Checked = True Then
                ObjFactura.SITU_IMPRESION = "REIM"
            ElseIf Me.RBSINIMPRE.Checked = True Then
                ObjFactura.SITU_IMPRESION = "SIIM"
            ElseIf Me.RBAMBOS.Checked = True Then
                ObjFactura.SITU_IMPRESION = "AMBO"
            End If
            'Datahelper
            dvListar_facturas = ObjFactura.SP_LIST_GUIAS_AUTO_GENE()
            '
            If dvListar_facturas.Count <= 0 Then
                MsgBox("No existen registros", MsgBoxStyle.Information, "Seguridad del Sistema...")
            End If
            FORMAT_GRILLA()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
        End Try
    End Sub
    Sub FORMAT_GRILLA2()
        DGV2.Columns.Clear()

        With DGV2
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvListar_facturas2
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim CONFIRMADO As New DataGridViewCheckBoxColumn
        With CONFIRMADO
            .HeaderText = "CONFIRMADO"
            .Name = "CONFIRMADO"
            .DataPropertyName = "CONFIRMADO"
            .ThreeState = False
            .TrueValue = 1
            .Width = 50

            .ReadOnly = True

            .FalseValue = 0
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With



        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .Width = 4
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO_CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 20
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"

            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA_FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .Width = 2
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION_PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"

            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC_DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"

            .ReadOnly = True
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
        With FECHA_ENTREGA
            .HeaderText = "FECHA_ENTREGA"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
        With TIPO_ENTREGA
            .HeaderText = "TIPO_ENTREGA"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "EST. ENVIO."
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "EST. REG."
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_ORI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_ORI
            .HeaderText = "Ori."
            .Name = "Nombre_Unidad_ORI"
            .DataPropertyName = "Nombre_Unidad_ORI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim Nombre_Unidad_DESTI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_DESTI
            .HeaderText = "Dest."
            .Name = "Nombre_Unidad_DESTI"
            .DataPropertyName = "Nombre_Unidad_DESTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"

            .ReadOnly = True
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "MONTO_IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With

        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"

            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"

            .ReadOnly = True
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB_TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "USUARIO"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
        End With

        With DGV2
            .Columns.AddRange(CONFIRMADO, RAZON_SOCIAL, FECHA_GUIA, NRO_GUIA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LOGIN, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA)

        End With
    End Sub
    Sub FORMAT_GRILLA()
        dgv1.Columns.Clear()

        With dgv1
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
            .Font = New Font("Arial", 8.0!, FontStyle.Regular)
            .AllowUserToOrderColumns = True
            .AllowUserToDeleteRows = False
            .AllowUserToAddRows = False
            .AutoGenerateColumns = False
            .DataSource = dvListar_facturas
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .VirtualMode = True
            .RowHeadersVisible = True
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        Dim IMPRESO As New DataGridViewCheckBoxColumn
        With IMPRESO
            .HeaderText = "IMPRESO"
            .Name = "IMPRESO"
            .DataPropertyName = "IMPRESO"
            .ThreeState = False
            .TrueValue = 1
            .Width = 50
            If Me.RBIMPRE.Checked = True Or Me.RBAMBOS.Checked = True Then
                .ReadOnly = True
            Else
                .ReadOnly = False
            End If
            .FalseValue = 0
            .SortMode = DataGridViewColumnSortMode.NotSortable

        End With



        Dim ANIO_FACTURA As New DataGridViewTextBoxColumn
        With ANIO_FACTURA
            .HeaderText = "ANIO_FACTURA"
            .Name = "ANIO_FACTURA"
            .DataPropertyName = "ANIO_FACTURA"
            .Width = 4
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim CODIGO_CLIENTE As New DataGridViewTextBoxColumn
        With CODIGO_CLIENTE
            .HeaderText = "CODIGO_CLIENTE"
            .Name = "CODIGO_CLIENTE"
            .DataPropertyName = "CODIGO_CLIENTE"
            .Width = 20
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DESTINATARIO As New DataGridViewTextBoxColumn
        With DESTINATARIO
            .HeaderText = "DESTINATARIO"
            .Name = "DESTINATARIO"
            .DataPropertyName = "DESTINATARIO"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DESTINO As New DataGridViewTextBoxColumn
        With DESTINO
            .HeaderText = "DESTINO"
            .Name = "DESTINO"
            .DataPropertyName = "DESTINO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim DIA_FACTURA As New DataGridViewTextBoxColumn
        With DIA_FACTURA
            .HeaderText = "DIA_FACTURA"
            .Name = "DIA_FACTURA"
            .DataPropertyName = "DIA_FACTURA"
            .Width = 2
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DIRECCION_PERSONA As New DataGridViewTextBoxColumn
        With DIRECCION_PERSONA
            .HeaderText = "DIRECCION_PERSONA"
            .Name = "DIRECCION_PERSONA"
            .DataPropertyName = "DIRECCION_PERSONA"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim DIREC_DESTI As New DataGridViewTextBoxColumn
        With DIREC_DESTI
            .HeaderText = "DIREC_DESTI"
            .Name = "DIREC_DESTI"
            .DataPropertyName = "DIREC_DESTI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DIREC_REMI As New DataGridViewTextBoxColumn
        With DIREC_REMI
            .HeaderText = "DIREC_REMI"
            .Name = "DIREC_REMI"
            .DataPropertyName = "DIREC_REMI"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim DSCTO As New DataGridViewTextBoxColumn
        With DSCTO
            .HeaderText = "DSCTO"
            .Name = "DSCTO"
            .DataPropertyName = "DSCTO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim FECHA_GUIA As New DataGridViewTextBoxColumn
        With FECHA_GUIA
            .HeaderText = "FECHA_GUIA"
            .Name = "FECHA_GUIA"
            .DataPropertyName = "FECHA_GUIA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FECHA_ENTREGA As New DataGridViewTextBoxColumn
        With FECHA_ENTREGA
            .HeaderText = "FECHA_ENTREGA"
            .Name = "FECHA_ENTREGA"
            .DataPropertyName = "FECHA_ENTREGA"
            .Width = 80
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim TIPO_ENTREGA As New DataGridViewTextBoxColumn
        With TIPO_ENTREGA
            .HeaderText = "TIPO_ENTREGA"
            .Name = "TIPO_ENTREGA"
            .DataPropertyName = "TIPO_ENTREGA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim TIPO_COMPROBANTE As New DataGridViewTextBoxColumn
        With TIPO_COMPROBANTE
            .HeaderText = "TIPO_COMPROBANTE"
            .Name = "TIPO_COMPROBANTE"
            .DataPropertyName = "TIPO_COMPROBANTE"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim ESTADO_REGISTRO_ENVIO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO_ENVIO
            .HeaderText = "EST. ENVIO."
            .Name = "ESTADO_REGISTRO_ENVIO"
            .DataPropertyName = "ESTADO_REGISTRO_ENVIO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim ESTADO_REGISTRO As New DataGridViewTextBoxColumn
        With ESTADO_REGISTRO
            .HeaderText = "EST. REG."
            .Name = "ESTADO_REGISTRO"
            .DataPropertyName = "ESTADO_REGISTRO"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim Nombre_Unidad_ORI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_ORI
            .HeaderText = "Ori."
            .Name = "Nombre_Unidad_ORI"
            .DataPropertyName = "Nombre_Unidad_ORI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim Nombre_Unidad_DESTI As New DataGridViewTextBoxColumn
        With Nombre_Unidad_DESTI
            .HeaderText = "Dest."
            .Name = "Nombre_Unidad_DESTI"
            .DataPropertyName = "Nombre_Unidad_DESTI"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim NOMBRE_AGENCIA As New DataGridViewTextBoxColumn
        With NOMBRE_AGENCIA
            .HeaderText = "NOMBRE_AGENCIA"
            .Name = "NOMBRE_AGENCIA"
            .DataPropertyName = "NOMBRE_AGENCIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim FORMA_PAGO As New DataGridViewTextBoxColumn
        With FORMA_PAGO
            .HeaderText = "FORMA_PAGO"
            .Name = "FORMA_PAGO"
            .DataPropertyName = "FORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDAGENCIAS As New DataGridViewTextBoxColumn
        With IDAGENCIAS
            .HeaderText = "IDAGENCIAS"
            .Name = "IDAGENCIAS"
            .DataPropertyName = "IDAGENCIAS"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDFACTURA As New DataGridViewTextBoxColumn
        With IDFACTURA
            .HeaderText = "IDFACTURA"
            .Name = "IDFACTURA"
            .DataPropertyName = "IDFACTURA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDFORMA_PAGO As New DataGridViewTextBoxColumn
        With IDFORMA_PAGO
            .HeaderText = "IDFORMA_PAGO"
            .Name = "IDFORMA_PAGO"
            .DataPropertyName = "IDFORMA_PAGO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDTIPO_MONEDA As New DataGridViewTextBoxColumn
        With IDTIPO_MONEDA
            .HeaderText = "IDTIPO_MONEDA"
            .Name = "IDTIPO_MONEDA"
            .DataPropertyName = "IDTIPO_MONEDA"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim IDUSUARIO_PERSONAL As New DataGridViewTextBoxColumn
        With IDUSUARIO_PERSONAL
            .HeaderText = "IDUSUARIO_PERSONAL"
            .Name = "IDUSUARIO_PERSONAL"
            .DataPropertyName = "IDUSUARIO_PERSONAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim MEMO As New DataGridViewTextBoxColumn
        With MEMO
            .HeaderText = "MEMO"
            .Name = "MEMO"
            .DataPropertyName = "MEMO"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim MES_FACTURA As New DataGridViewTextBoxColumn
        With MES_FACTURA
            .HeaderText = "MES_FACTURA"
            .Name = "MES_FACTURA"
            .DataPropertyName = "MES_FACTURA"
            .Width = 10
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim MONTO_IMPUESTO As New DataGridViewTextBoxColumn
        With MONTO_IMPUESTO
            .HeaderText = "MONTO_IMPUESTO"
            .Name = "MONTO_IMPUESTO"
            .DataPropertyName = "MONTO_IMPUESTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim NRO_GUIA As New DataGridViewTextBoxColumn
        With NRO_GUIA
            .HeaderText = "NRO_GUIA"
            .Name = "NRO_GUIA"
            .DataPropertyName = "NRO_GUIA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        Dim ORIGEN As New DataGridViewTextBoxColumn
        With ORIGEN
            .HeaderText = "ORIGEN"
            .Name = "ORIGEN"
            .DataPropertyName = "ORIGEN"

            .ReadOnly = True
        End With
        Dim RAZON_SOCIAL As New DataGridViewTextBoxColumn
        With RAZON_SOCIAL
            .HeaderText = "RAZON_SOCIAL"
            .Name = "RAZON_SOCIAL"
            .DataPropertyName = "RAZON_SOCIAL"
            .Width = 200
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim REFE As New DataGridViewTextBoxColumn
        With REFE
            .HeaderText = "REFE"
            .Name = "REFE"
            .DataPropertyName = "REFE"
            .SortMode = DataGridViewColumnSortMode.NotSortable
            .ReadOnly = True
        End With
        Dim REMITENTE As New DataGridViewTextBoxColumn
        With REMITENTE
            .HeaderText = "REMITENTE"
            .Name = "REMITENTE"
            .DataPropertyName = "REMITENTE"
            .Width = 182
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim SERIE_FACTURA As New DataGridViewTextBoxColumn
        With SERIE_FACTURA
            .HeaderText = "SERIE_FACTURA"
            .Name = "SERIE_FACTURA"
            .DataPropertyName = "SERIE_FACTURA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .Visible = False
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim SIMBOLO_MONEDA As New DataGridViewTextBoxColumn
        With SIMBOLO_MONEDA
            .HeaderText = "SIMBOLO_MONEDA"
            .Name = "SIMBOLO_MONEDA"
            .DataPropertyName = "SIMBOLO_MONEDA"
            .Width = 30
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim SUB_TOTAL As New DataGridViewTextBoxColumn
        With SUB_TOTAL
            .HeaderText = "SUB_TOTAL"
            .Name = "SUB_TOTAL"
            .DataPropertyName = "SUB_TOTAL"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim LOGIN As New DataGridViewTextBoxColumn
        With LOGIN
            .HeaderText = "USUARIO"
            .Name = "LOGIN"
            .DataPropertyName = "LOGIN"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim TOTAL_COSTO As New DataGridViewTextBoxColumn
        With TOTAL_COSTO
            .HeaderText = "TOTAL_COSTO"
            .Name = "TOTAL_COSTO"
            .DataPropertyName = "TOTAL_COSTO"
            .Width = 50
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            .DefaultCellStyle.Format = "N2"
            .DefaultCellStyle.NullValue = "0,00"
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dim NRO_PREFACTURA As New DataGridViewTextBoxColumn
        With NRO_PREFACTURA
            .HeaderText = "NRO_PREFACTURA"
            .Name = "NRO_PREFACTURA"
            .DataPropertyName = "NRO_PREFACTURA"
            .Width = 100
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With

        With dgv1
            .Columns.AddRange(IMPRESO, RAZON_SOCIAL, FECHA_GUIA, NRO_GUIA, SUB_TOTAL, MONTO_IMPUESTO, TOTAL_COSTO, LOGIN, ESTADO_REGISTRO, ESTADO_REGISTRO_ENVIO, NOMBRE_AGENCIA, Nombre_Unidad_ORI, Nombre_Unidad_DESTI, TIPO_ENTREGA)

        End With
    End Sub

    Private Sub Panel2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub Panel4_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel4.Paint
        MyBase.OnPaint(e)
        Dim rec As New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), Me.ClientSize) 'New Point(500, 500))
        Dim gradiente As New Drawing2D.LinearGradientBrush(rec, Color.White, System.Drawing.SystemColors.Desktop, Drawing2D.LinearGradientMode.Vertical)
        e.Graphics.FillRegion(gradiente, New Region(rec))
    End Sub

    Private Sub SeleccionarTodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarTodoToolStripMenuItem.Click
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then Exit Sub
        For i As Integer = 0 To Me.dvListar_facturas.Count - 1
            Me.dvListar_facturas.Table.Rows(i)("IMPRESO") = 1

        Next


        numero = dvListar_facturas.Count

        Label18.Text = numero

        If IsNumeric(Me.TxtNroGuiaIni.Text) Then
            Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
            Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
        Else
            Me.Label15.Text = ""
            Label23.Text = ""
        End If
    End Sub

    Private Sub SeleccionarNingunoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeleccionarNingunoToolStripMenuItem.Click
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then Exit Sub
        For i As Integer = 0 To Me.dvListar_facturas.Count - 1
            Me.dvListar_facturas.Table.Rows(i)("IMPRESO") = 0

        Next

        numero = 0

        Label18.Text = IIf(numero = 0, "", numero)

        If IsNumeric(Me.TxtNroGuiaIni.Text) Then
            Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
            Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
        Else
            Me.Label15.Text = ""
            Label23.Text = ""
        End If
    End Sub

    Private Sub InvertirSeleccionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertirSeleccionToolStripMenuItem.Click
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then Exit Sub
        For i As Integer = 0 To Me.dvListar_facturas.Count - 1
            If Me.dvListar_facturas.Table.Rows(i)("IMPRESO") = 0 Then
                Me.dvListar_facturas.Table.Rows(i)("IMPRESO") = 1
                numero = numero + 1
            Else
                Me.dvListar_facturas.Table.Rows(i)("IMPRESO") = 0
                numero = numero - 1
            End If
        Next

        Label18.Text = IIf(numero = 0, "", numero)

        If IsNumeric(Me.TxtNroGuiaIni.Text) Then
            Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
            Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
        Else
            Me.Label15.Text = ""
            Label23.Text = ""
        End If
    End Sub
    Private Sub imprimir_etiquetas()

        Try
            ObjReport.dispose()
        Catch

        End Try

        ObjReport = New ClsLbTepsa.dtoFrmReport

        Dim DV As DataView

        ObjFactura.IDGUIAS_ENVIOS = ""

        Try

            For K As Integer = 0 To dvListar_facturas.Count - 1
                If dvListar_facturas.Table.Rows(K)("IMPRESO") = 1 Then

                    ObjFactura.IDGUIAS_ENVIOS = ObjFactura.IDGUIAS_ENVIOS + dvListar_facturas.Table.Rows(K)("IDGUIAS_ENVIO").ToString + ","
                End If
            Next

            Dim situ_impre As String
            '  Dim situ_impre As Char

            If Me.RBSINIMPRE.Checked Then
                situ_impre = "IMPR"
            ElseIf Me.RBREIMPRE.Checked Then
                situ_impre = "REIM"
            Else
                situ_impre = "NULL"
            End If


            Dim nroguia As String

            If Me.RBSINIMPRE.Checked And Not IsNumeric(Me.TxtNroGuiaIni.Text) Then
                MsgBox("Ingrese el número inicial de la guia de envio", MsgBoxStyle.Information, "Seguridad del sistema...")
                Me.TxtNroGuiaIni.Focus()
                Exit Sub
            Else
                nroguia = Me.TxtNroGuiaIni.Text
            End If


            If Me.RBREIMPRE.Checked And Not IsNumeric(Me.TxtNroGuiaIni.Text) Then
                nroguia = "0"
            End If



            ObjReport.rutaRpt = PathFrmReport
            ObjReport.conectar(rptservice, rptuser, rptpass)
            'ObjReport.printrptlpt(true, "", "GUI007.RPT", _
            ObjReport.printrpt(True, "", "GUI015.RPT", _
            "P_SITU_IMPRE;" & situ_impre, _
            "P_idagencias;" & dtoUSUARIOS.iIDAGENCIAS, _
            "p_ip;" & dtoUSUARIOS.IP, _
            "P_NRO_GUIA;" & Me.TxtNroGuiaIni.Text, _
            "P_IDGUIAS_ENVIOS;" & Mid(ObjFactura.IDGUIAS_ENVIOS, 1, Len(ObjFactura.IDGUIAS_ENVIOS) - 1))


            'ObjReport.rutaRpt = PathFrmReport
            'ObjReport.conectar(rptservice, rptuser, rptpass)
            'ObjReport.printrpt(True, "", "PG001.RPT", "P_IDPRE_GUIA;" & 596845, _
            '"P_NRO_GUIA_INI;" & CType(3308882, Long), _
            '"P_NRO_GUIA_FINAL;" & CType(3308912, Long))



        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try

        For I As Integer = 0 To dvListar_facturas.Count - 1


            DV = New DataView
            If dvListar_facturas.Table.Rows(I)("IMPRESO") = 1 Then
                ObjFactura.IDGUIAS_ENVIO = dvListar_facturas.Table.Rows(I)("IDGUIAS_ENVIO")
                ObjFactura.NRO_GUIA = "0"

                'Datahelper
                DV = ObjFactura.SP_LIST_GUIAS_IMPRE()
                '
                xIMPRESORA = fnSeleccionImpresion()





                Try


                    objGuiaEnvio.iIDGUIAS_ENVIO = ObjFactura.IDGUIAS_ENVIO

                    If objGuiaEnvio.iIDGUIAS_ENVIO = 0 Then
                        MsgBox("No Puede realizar esta Operacion ...", MsgBoxStyle.Information, "Seguridad Sistema")
                        Return
                    End If

                    'If objGuiaEnvio.fnControlEdicion(objGuiaEnvio.iIDGUIAS_ENVIO) = True Then
                    '    'MsgBox("La Guia de Envio esta Liquidada", MsgBoxStyle.Information, "Seguridad Sistema")
                    '    MsgBox("La Guia de esta Facturada O Prefacturada...", MsgBoxStyle.Information, "Seguridad Sistema")
                    '    GoTo SALIR
                    'End If

                    'bloque
                    If Acceso.SiRol(G_Rol, Me, 1) Then
                        'If fnValidar_Rol("21") = True Then
                        If ObjVentaCargaContado.fnREIMPRESIONCODIGOS(3, objGuiaEnvio.iIDGUIAS_ENVIO) = True Then
                            'If MsgBox("Esta Seguro de Imprimir Etiquetas..?", MsgBoxStyle.YesNo, "Seguridad Sistemas") = MsgBoxResult.Yes Then

                            If xIMPRESORA = 1 Then
                                fnImprimirEtiquetasN95()
                            Else
                                If xIMPRESORA = 2 Then
                                    fnImprimirEtiquetasFAC_IIN95()
                                Else
                                    fnImprimirEtiquetasFAC_IIN97()
                                End If
                                'fnImprimirEtiquetasFAC_IIN95() 
                            End If
                            'End If
                        Else
                            MsgBox("No puede cargar esta data, faltan datos...", MsgBoxStyle.Information, "Seguridad Sistema")
                        End If
                    Else
                        MsgBox("Usted No Tiene Persmisos para realizar esta Operaciom")
                    End If

SALIR:
                Catch ex As Exception
                    MsgBox("Revice sus Datos.., Operacion Cancelada", MsgBoxStyle.Information, "Seguridad Sistema")
                End Try




            End If
        Next




    End Sub

    Public Function fnImprimirEtiquetasN95() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            prn.Nombre_impresora = NOMBRE_IMPRESORA '"\\192.168.50.147\PRNZEBRA"
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            'ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 1
            'Mod.16/09/2009 -->Omendoza - Pasando al datahelper   
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("^XA")
                prn.EscribeLinea("^PW400")
                prn.EscribeLinea("^FT15,92^A0N,28,28^FH\^FD " & ObjCODIGOBARRA.NroDOC & "          " & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & "^FS")
                prn.EscribeLinea("^FT14,42^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.clinte & "^FS")
                prn.EscribeLinea("^BY2,2,46^FT190,144^BEN,,Y,N^FD" & ObjCODIGOBARRA.CodigoBarra & "^FS")
                prn.EscribeLinea("^FT17,141^A0N,28,28^FH\^FD" & ObjCODIGOBARRA.Origen & " /^FS")
                prn.EscribeLinea("^FT96,142^A0N,39,45^FH\^FD" & ObjCODIGOBARRA.Destino & " ^FS")
                prn.EscribeLinea("^FT305,188^AAN,18,10^FH\^FDTEPSAC^FS")
                prn.EscribeLinea("^FT183,188^AAN,18,10^FH\^FD" & HoraActual & "^FS")
                prn.EscribeLinea("^FT21,188^AAN,18,10^FH\^FD" & ObjCODIGOBARRA.Fecha & "^FS")
                prn.EscribeLinea("^PQ1,0,1,Y")
                prn.EscribeLinea("^XZ")
                prn.EscribeLinea(cadena)
                'ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.MoveNext()
                I = I + 1
                'End While
            Next
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetasFAC_IIN95() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()

            'ObjCODIGOBARRA.Origen = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_ORIGEN)
            'ObjCODIGOBARRA.Destino = objGuiaEnvio.fnIATA(ObjVentaCargaContado.v_IDUNIDAD_DESTINO)
            'ObjCODIGOBARRA.Fecha = dtoUSUARIOS.m_sFecha
            'ObjCODIGOBARRA.Cantidad = ObjVentaCargaContado.v_CANTIDAD_ETIQUETAS

            Dim I As Int16 = 1
            For Each fila As DataRow In ObjVentaCargaContado.dt_cur_cont_origen.Rows
                'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                prn.EscribeLinea("<STX><ESC>C0<ETX>")
                prn.EscribeLinea("<STX><ESC>k<ETX>")
                prn.EscribeLinea("<STX><SI>N60<ETX>")
                prn.EscribeLinea("<STX><SI>L197<ETX>")
                prn.EscribeLinea("<STX><SI>S20<ETX>")
                prn.EscribeLinea("<STX><SI>d0<ETX>")
                prn.EscribeLinea("<STX><SI>h0,0;<ETX>")
                prn.EscribeLinea("<STX><SI>l8<ETX>")
                prn.EscribeLinea("<STX><SI>I3<ETX>")
                prn.EscribeLinea("<STX><SI>F20<ETX>")
                prn.EscribeLinea("<STX><SI>D0<ETX>")
                prn.EscribeLinea("<STX><SI>t0<ETX>")
                prn.EscribeLinea("<STX><SI>W394<ETX>")
                prn.EscribeLinea("<STX><SI>g1,567<ETX>")
                prn.EscribeLinea("<STX><ESC>P<ETX>")
                prn.EscribeLinea("<STX>E*;F*;<ETX>")
                prn.EscribeLinea("<STX>L1;<ETX>")
                prn.EscribeLinea("<STX>D0;<ETX>")
                prn.EscribeLinea("<STX>H0;o165,12;f3;c25;h12;w20;d3," & ObjCODIGOBARRA.clinte & ";<ETX>")
                prn.EscribeLinea("<STX>D1;<ETX>")
                prn.EscribeLinea("<STX>H1;o130,13;f3;c25;h9;w15;d3," & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & "   " & ObjCODIGOBARRA.AGEDOM & ";<ETX>")
                prn.EscribeLinea("<STX>H2;o88,11;f3;c25;h11;w11;d3," & ObjCODIGOBARRA.Origen & " / ;<ETX>")
                prn.EscribeLinea("<STX>B3;o96,160;f3;c7,0,2;h69;w2;r0;i1;d3," & ObjCODIGOBARRA.CodigoBarra & ";<ETX>")
                prn.EscribeLinea("<STX>H4;o14,13;f3;c25;h7;w7;d3," & ObjCODIGOBARRA.Fecha & ";<ETX>")
                prn.EscribeLinea("<STX>H5;o14,200;f3;c25;h7;w7;d3," & HoraActual & ";<ETX>")
                prn.EscribeLinea("<STX>H6;o14,300;f3;c25;h7;w7;d3,TEPSAC;<ETX>")
                prn.EscribeLinea("<STX>H7;o102,96;f3;c25;h17;w16;d3," & ObjCODIGOBARRA.Destino & ";<ETX>")
                prn.EscribeLinea("<STX>R<ETX>")
                prn.EscribeLinea("<STX><ESC>E*<CAN><ETX>")
                prn.EscribeLinea("<STX><RS>1<US>1<ETB><ETX>")
                prn.EscribeLinea(cadena)
                ' ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
                I = I + 1
                'End While
            Next
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function
    Public Function fnImprimirEtiquetasFAC_IIN97() As Boolean
        Dim flag As Boolean = True
        Try
            Dim prn As New PrinterTxt.PrintTxt
            Dim cadena As String = ""
            Dim HoraActual As String = ObjCODIGOBARRA.HoraImpresion
            'prn.Nombre_impresora = "PRNZEBRA"
            prn.Nombre_impresora = NOMBRE_IMPRESORA
            Dim EXISTE As Boolean = prn.SetearImpresora()
            '
            Dim I As Int16 = 1
            For Each fila As DataRow In ObjVentaCargaContado.dt_Cur_CODIGOBARRAS.Rows
                'While ObjVentaCargaContado.Cur_CODIGOBARRAS.EOF = False And ObjVentaCargaContado.Cur_CODIGOBARRAS.BOF = False
                ObjCODIGOBARRA.CodigoBarra = fila.Item(0)
                '
                prn.EscribeLinea("N")
                prn.EscribeLinea("N")
                '
                prn.EscribeLinea("A30,14,0,4,1,1,N,""" & ObjCODIGOBARRA.clinte & """")
                prn.EscribeLinea("A30,47,0,4,1,1,N,""" & ObjCODIGOBARRA.NroDOC & " -" & I.ToString & "/" & ObjCODIGOBARRA.Cantidad & """")
                prn.EscribeLinea("A317,47,0,3,1,1,N,""" & ObjCODIGOBARRA.AGEDOM & """")
                prn.EscribeLinea("A30,110,0,3,1,1,N,""" & ObjCODIGOBARRA.Origen & "-  """)
                prn.EscribeLinea("A30,163,0,1,1,1,N,""" & ObjCODIGOBARRA.Fecha & """")
                prn.EscribeLinea("A321,163,0,1,1,1,N,""TEPSAC""")
                prn.EscribeLinea("A205,163,0,1,1,1,N,""" & HoraActual & """")
                prn.EscribeLinea("A89,94,0,4,1,2,N,""" & ObjCODIGOBARRA.Destino & """")
                prn.EscribeLinea("B148,83,0,E30,2,2,59,B,""" & ObjCODIGOBARRA.CodigoBarra & """")
                '
                prn.EscribeLinea("P1")
                prn.EscribeLinea("N")
                prn.EscribeLinea(cadena)
                i = i + 1
                ' ObjVentaCargaContado.Cur_CODIGOBARRAS.MoveNext()
            Next
            prn.FinDoc()
        Catch ex As Exception
            flag = False
        End Try
        Return flag
    End Function

    Private Sub txtNro_guia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNro_guia.KeyDown

    End Sub

    Private Sub txtNro_guia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNro_guia.KeyPress
        If e.KeyChar = Chr(13) Then
            For i As Integer = 0 To dvListar_facturas2.Count - 1
                If Val(dvListar_facturas2.Table.Rows(i)("nro_guia")) = Val(txtNro_guia.Text) Then
                    dvListar_facturas2.Table.Rows(i)("CONFIRMADO") = 1
                    txtNro_guia.SelectAll()
                    ObjFactura.IDGUIAS_ENVIO = dvListar_facturas2.Table.Rows(i)("idguias_envio")
                    'Datahelper
                    ObjFactura.sp_confir_regis_pend()
                    '
                    DGV2.CurrentCell = DGV2.Rows(i).Cells(1)
                    DGV2.CurrentRow.Cells("ESTADO_REGISTRO").Value = ""
                    Exit Sub
                End If
            Next

            MsgBox("No existe este número de documento en la lista", MsgBoxStyle.Exclamation, "Seguridad del Sistema")

        End If
    End Sub

    Private Sub txtNro_guia_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNro_guia.KeyUp

    End Sub

    Private Sub txtNro_guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNro_guia.TextChanged

    End Sub

    Private Sub btnImpri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpri.Click
        btnImpri.Enabled = False
        imprimir_etiquetas()
        limpiar_valores()


        If Me.TabControl2.SelectedIndex = 1 Then
            listar_facturas2()
        Else
            listar_facturas()
        End If

        numero = 0
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then
            Me.btnImpri.Enabled = False
        Else
            Me.btnImpri.Enabled = True
        End If

        Label18.Text = IIf(numero = 0, "", numero)

        If IsNumeric(Me.TxtNroGuiaIni.Text) Then
            If numero = 0 Then
                Me.Label15.Text = ""
                Label23.Text = ""
            Else
                Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
                Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
            End If
        Else
            Me.Label15.Text = ""
            Label23.Text = ""
        End If
        btnImpri.Enabled = True
    End Sub

    Private Sub TxtNroGuiaIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNroGuiaIni.KeyPress
        

        Try
            Dim tb As TextBox = CType(sender, TextBox)
            Dim chr As Char = e.KeyChar
            If IsNumeric(e.KeyChar) Then
                e.Handled = Not IsNumeric(tb.Text & e.KeyChar)
                'ElseIf e.KeyChar = "." Then
                'If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & e.KeyChar)) Then
                'e.Handled = True
                'End If
                'ElseIf e.KeyChar = "-" Then
                'If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then
                'e.Handled = True
                'End If
            ElseIf Not Char.IsControl(e.KeyChar) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Sub

    Private Sub TxtNroGuiaIni_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNroGuiaIni.TextChanged
        If IsNumeric(TxtNroGuiaIni.Text) Then
            Label11.Text = ObjGeneral.fn_retorna_digito_checkeo(TxtNroGuiaIni.Text)
            If IsNumeric(Label18.Text) Then
                Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
                Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
            Else
                Label15.Text = ""
                Label23.Text = ""
            End If
        Else
            Label11.Text = ""
            Label15.Text = ""
            Label23.Text = ""
        End If

    End Sub

    Private Sub dgv1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgv1.CellMouseUp
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then Exit Sub
        If Not e.Button = Windows.Forms.MouseButtons.Left Then Exit Sub
        If dvListar_facturas.Table.Rows(dgv1.CurrentRow.Index)("IMPRESO") = 1 Then
            dvListar_facturas.Table.Rows(dgv1.CurrentRow.Index)("IMPRESO") = 0
            numero = numero - 1
        Else
            dvListar_facturas.Table.Rows(dgv1.CurrentRow.Index)("IMPRESO") = 1
            numero = numero + 1
        End If

        Label18.Text = IIf(numero = 0, "", numero)

        If IsNumeric(Me.TxtNroGuiaIni.Text) Then
            Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
            Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
        Else
            Me.Label15.Text = ""
            Label23.Text = ""
        End If

    End Sub
    Private Sub dgv1_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellValidated
        
    End Sub

    Private Sub dgv1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv1.CellContentClick

    End Sub

    Private Sub cms_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cms.Opening
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then
            cms.Enabled = False
            Me.btnImpri.Enabled = False
        Else
            cms.Enabled = True
            Me.btnImpri.Enabled = True
        End If
    End Sub

    Private Sub dgv1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv1.KeyUp
        If Not (Me.RBSINIMPRE.Checked Or Me.RBREIMPRE.Checked) Then Exit Sub
        If Not e.KeyCode = Keys.Space Then Exit Sub
        If dvListar_facturas.Table.Rows(dgv1.CurrentRow.Index)("IMPRESO") = 1 Then
            dvListar_facturas.Table.Rows(dgv1.CurrentRow.Index)("IMPRESO") = 0
            numero = numero - 1
        Else
            dvListar_facturas.Table.Rows(dgv1.CurrentRow.Index)("IMPRESO") = 1
            numero = numero + 1
        End If

        Label18.Text = IIf(numero = 0, "", numero)

        If IsNumeric(Me.TxtNroGuiaIni.Text) Then
            Me.Label15.Text = Me.TxtNroGuiaIni.Text + numero - 1
            Label23.Text = ObjGeneral.fn_retorna_digito_checkeo(Me.Label15.Text)
        Else
            Me.Label15.Text = ""
            Label23.Text = ""
        End If

    End Sub
    Function limpiar_valores()
        TxtNroGuiaIni.text = ""
        Label11.text = ""
        Label15.text = ""
        Label23.text = ""
    End Function

    Private Sub DGV_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV.CellContentClick

    End Sub
End Class