'Imports System.Windows.Forms
'Imports System.Drawing
'Imports System.Drawing.Image
'Imports System.ComponentModel
'Imports System.Resources
Imports AccesoDatos
'Imports INTEGRACION_LN
'Imports ADODB
Enum TipoEntrega
    Agencia = 1
    Domicilio = 2
End Enum
Enum TipoVenta
    Contado = 1
    Credito = 2
End Enum
Public Class Win32API
    Public Const GENERIC_WRITE = &H40000000
    Public Const CREATE_ALWAYS = 2
    Public Const OPEN_EXISTING = 3
    Public Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As Integer
    Public Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Long) As Long
    '
End Class

Module ModuUtil
    Public rptuser As String = "titan"
    Public rptpass As String = "titan"
    Public rptservice As String = "tepsa"
    '
    Public HoraImpresion As String
    Public NombreServidor As String
    '
    Public Glosa_Persona As String
    ' Version con la que cambia
    Public Const V_VERSION = "Version 1.0.0.0"
    '
    Public Dt_Otros_Gastos As DataTable
    '
    Public nFrmCreaRelaCobra As FrmCreaRelaCobra
    Public nFrmCierre_LiquiTurno As FrmCierre_LiquiTurno

    Public nfrmdespacho_vs_recepcion As frmdespacho_vs_recepcion
    '
    '19/07/2007 
    Public C_DEVOLUCION, C_ABANDONO_LEGAL As Bitmap
    '
    Public ObjBusquedaClientes As New dtoBusquedaClientes
    Public ObjEntregaCarga As New dtoEntregaCarga
    '
    Public ObjManteClienteContado As New dtoManteClienteContado
    Public ObjEntrega_Recojo As New dtoEntrega_Recojo
    Public ObjFiltrosEntregaRecojos As New dtoFiltrosEntregaRecojos
    Public ObjEditarDatosDocumentos As New dtoEditarDatosDocumentos
    Public ObjPagosSoles As New dtoPagos
    Public ObjPagosDolares As New dtoPagos
    Public objControlFacturasBol As New dtoControlFacturasBol
    Public ObjVentaCargaContado As New dtoVentaCargaContado
    Public ObjVentagiroContado As New dtoVentaGiroContado  'Ritcher
    Public ObjCODIGOBARRA As New dtoCODIGOBARRA
    Public ObjRegistroGenerico As New dtoRegistroGenerico
    Public ObjControlDescuento As New dtoControlDescuento
    '
    Public ObjVentaPasaje As New dtoventapasaje ' Omendoza 
    Public Objexcesoequipaje As New dtoexcesoequipaje ' Omendoza 
    Public Objfacturacargo As New dtofactura_cargo 'Omendoza 
    Public ObjDctogratuitos As New dtocomprobantegratuitos 'Omendoza 
    Public Objrefacturacion As New dtorefacturacion 'Omendoza
    Public objguia_transp_despacho_vs_recepcion As New dtoguia_transp_despacho_vs_recepcion 'Omendoza
    Public ObjGuia_Transp_xdcto As New dtoguia_transp_xdcto 'Omendoza 
    Public objOtras_facturas As New dto_otras_facturas 'Omendoza 
    Public objmant_clte_facturacion As New dto_mant_clte_facturacion 'Omendoza
    Public objseguimiento_despacho_x_dia As New dtoseguimiento_despacho_x_dia 'Omendoza
    '
    Public PuertoSock As Integer
    Public dtoUSUARIOS As New dtoCONTROLUSUARIOS
    Public dtoCONTROL_ACCESOS As New dtoCONTROLACCESOS()
    Public dtoForm As New dtoFORMULARIOS()
    Public dtoToolBar As New dtoCONTROLTOOLBAR()
    Public dtoTabControl As New dtoCONTROLTAB()
    Public objGuiaEnvio As New dtoGuiaEnvio()
    Public objCONFIGURACION_DOCUMENTARIA As New dtoCONFIGURACION_DOCUMENTARIA()
    Public objGuia_Envio_Articulo As New dtoGuia_Envio_Articulo()
    'Public objLOG As New LogSistemaTitan
    '
    Public objRecepcionGuias As New dtoRecepcionGuias()
    Public ObjTarifaSubCuenta As New dtoTarifaSubCuenta
    'Mod - 17/09/2009 - No es usado en todo el proyecto y asi quitado 
    'Public dtoControl_Especies As New dtoCONTROL_ESPECIES_VAL()
    'Public dtoEspecies_val As New dtoESPECIES_VALORADAS()
    'Public dtoEspecies_val_detall As New dtoESPECIES_VALORADAS_DETALL()
    '    
    'Public rst_err As ADODB.Recordset
    '
    'Public rst_cur_datos As ADODB.Recordset
    Public dt_rst_cur_datos As DataTable
    '
    Public coll_Lista_Roles As New Collection
    ' Modificado Omendoza 
    Public objbusqunidadtransporte As New dtobusquedaunidadtransporte
    Public objsalidavehiculodespacho As New dtosalidavehiculo
    '
    Public dtoLista_Usuario As New dtoLISTAAGENCIAUSUARIOS()
    'Public ObjCierre_LiqFactura As New dtoCIERRE_LIQ_FACTURA No es usado 
    'Modificado por Ritcher
    Public ObjCIERRE_LIQUIDACIONES As New dtoCIERRE_LIQUIDACIONES
    Public nFrmManteMensajeriaPersona As FrmManteMensajeriaPesona
    Public ddd As FrmCreaRelaCobra
    '
    Public RGT_CODIGO_CLIENTE As String
    Public RGT_RAZON_SOCIAL As String
    Public rgt_password_giro As String
    Public rgt_pregunta_giro As String
    Public rgt_respuesta_giro As String
    Public rgt_respuesta_entre_giro As String
    '
    Public rgt_desicion_seguridad As String


    Dim ControlError As Integer
    Dim FECHA_SERVIDOR As String
    ' 08/08/2007 
    Public NOMBRE_IMPRESORA As String
    Public Impresora As Integer = 1
    ' 16/08/2007
    Public objsalidamovilreparto As New dtosalidamovil
    '24/08/2007 
    Public ObjWebService As New dtoWebService
    '27/08/2007
    Public objbultos_leidos_pdt_vs_manual As New dtobultos_leidos_pdt_vs_manual
    '15/09/2007 
    'Public objtarifario_giro As New dto_tarifario_giro
    '18/02/2008 - Rgomez 
    Public correlativo_inicial As Long
    Public correlativo_final As Long

    'Public total_bultos As Long

    '04/04/2008 - Dto para carga asegurada - Rgomez
    Public objComprobanteAsegurada() As ClsLbTepsa.dtoCargaAsegurada.ComprobanteAsegurada
    '15/04/2008 - 
    Public nFrmIngreCargoAdi As FrmIngreCargoAdi
    ' 
    '24/06/2008
    Public recuperando_datos_contado As Boolean
    '
    '19/07/2008 
    Public nFrmOpciones As FrmOpciones
    Public objCargaAsegurada As New ClsLbTepsa.dtoCargaAsegurada
    '
    Public iIndex As Integer
    Dim it As ListViewCabecera
    Private LETTERS As String = "AÁBCDEÉFGHIÍJKLMNÑOÓPQRSTUÚÜVWXYZ"
    Private NUMBERS As String = "1234567890"
    Private NUMBERS_CONTROL As String = "^[1-9][0-9]{1,6}"
    Private EMAIL As String = "^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
    Private IP As String = "(?<First>[01]?\d\d?|2[0-4]\d|25[0-5])\.(?<Second>[01]?\d\d?|2[0-4]\d|25[0-5])\.(?<Third>[01]?\d\d?|2[0-4]\d|25[0-5])\.(?<Fourth>[01]?\d\d?|2[0-4]\d|25[0-5])(?x) "
    Private URL As String = "^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/"
    Private DATEC As String = "(?<Month>\d{1,2})/(?<Day>\d{1,2})/(?<Year>(?:\d{4}|\d{2}))(?x)"
    Private ZIP As String = "(?<Zip>\d{5})-(?<Sub>\d{4})(?x)"
    Public bmActivo, bmpNoImagen, bmpAtendido, bmRecepcionado, bmEliminado, bmSolicitado, bmNoImagen As Bitmap
    Public bmpGUIAS_CARGO, bmpGUIAS_LIQUIDADAS, bmpGUIAS_ENTREGADAS As Bitmap
    Public bmpFACTURA_EMITIDA, bmpFACTURA_ANULADA, bmpFACTURA_DEVUELTA, bmpFACTURA_ENTREGADA As Bitmap
    '06/02/2008 
    Public bmpC_REPARTO_PARCIAL, bmpC_ENTREGADO_PARCIAL As Bitmap
    '07/04/2008 - Rgomez 
    Public factura_o_boleta As Integer

    '
    Public C_RECEPCIONADO, C_DESPACHADO, C_DESPACHO_PARCIAL, C_LLEGADA, C_LLEGADA_PARCIAL, C_PERDIDO, C_ENTREGADO, C_CARGO, C_REPARTO, C_RECOJO, C_FACTURADO As Bitmap
    '
    '    Public strPlus1 As String = "C:\icon\plus1.bmp"   12/10/2006 
    '
    Public strPlus1 As String = "..\icon\plus1.bmp"
    Public sIPMAQUINA As String
    Public bControl As Boolean
    '19/08/2008 - Hlamas
    Public sImpresora As String
    Public mParametros(3) As Integer
    Public iProceso As Integer = 0
    Public bPyme As Boolean = False
    '
    Public Sub IniciarImagenes()
        Try
            PuertoSock = 8050
            'Application.StartupPath
            'Orden de Paso de cada variable
            '1:Solicitado()
            '2:Atendido()
            '3:Recepcionado()
            '4:TODOS()
            '5:ELIMINADO()
            'bmActivo = New Bitmap("C:\icon\Activo.bmp")       'Verde    Modificado 12/10/2006 
            'bmSolicitado = New Bitmap("C:\icon\Activo.bmp")   'Verde 
            'bmRecepcionado = New Bitmap("C:\icon\Recepcionado.bmp") ' Amatillo Recepcionado
            'bmEliminado = New Bitmap("C:\icon\Eliminado.bmp") 'Rojo Eliminado
            'bmpAtendido = New Bitmap("C:\icon\Atendido.bmp")  'Celeste Atendido 
            'bmpNoImagen = New Bitmap("C:\icon\NoImagen.bmp")  'Blanco No Imagen
            'bmNoImagen = New Bitmap("C:\icon\bmNoImagen.bmp")  ' X Rojo No Imagen 
            'bmNoImagen = New Bitmap("C:\icon\bmNoImagen.bmp")  ' X Rojo No Imagen
            'bmpendiente = New Bitmap("C:\icon\bmNoImagen.bmp")

            bmActivo = New Bitmap("..\icon\Activo.bmp")       'Verde
            bmSolicitado = New Bitmap("..\icon\Activo.bmp")   'Verde 
            bmRecepcionado = New Bitmap("..\icon\Recepcionado.bmp") ' Amatillo Recepcionado
            bmEliminado = New Bitmap("..\icon\Eliminado.bmp") 'Rojo Eliminado
            bmpAtendido = New Bitmap("..\icon\Atendido.bmp")  'Celeste Atendido 
            bmpNoImagen = New Bitmap("..\icon\NoImagen.bmp")  'Blanco No Imagen
            bmNoImagen = New Bitmap("..\icon\bmNoImagen.bmp")  ' X Rojo No Imagen 
            bmNoImagen = New Bitmap("..\icon\bmNoImagen.bmp")  ' X Rojo No Imagen
            bmpendiente = New Bitmap("..\icon\bmNoImagen.bmp")
            'bmpGUIAS_CARGO = New Bitmap("C:\icon\GUIAS_CARGO.bmp")  ' AZUL
            'bmpGUIAS_LIQUIDADAS = New Bitmap("C:\icon\GUIAS_LIQUIDADAS.bmp")  ' AMARILLO
            'bmpGUIAS_ENTREGADAS = New Bitmap("C:\icon\GUIAS_ENTREGADAS.bmp")  ' ENTREGADAS
            bmpGUIAS_CARGO = New Bitmap("..\icon\GUIAS_CARGO.bmp")  ' AZUL
            bmpGUIAS_LIQUIDADAS = New Bitmap("..\icon\GUIAS_LIQUIDADAS.bmp")  ' AMARILLO
            bmpGUIAS_ENTREGADAS = New Bitmap("..\icon\GUIAS_ENTREGADAS.bmp")  ' ENTREGADAS
            '
            bmpFACTURA_EMITIDA = New Bitmap("..\icon\FACTURA_EMITIDA.bmp")  ' Emisión 
            bmpFACTURA_ANULADA = New Bitmap("..\icon\FACTURA_ANULADA.bmp")  ' Anulación 
            bmpFACTURA_DEVUELTA = New Bitmap("..\icon\FACTURA_DEVUELTA.bmp")  ' Devolución 
            bmpFACTURA_ENTREGADA = New Bitmap("..\icon\FACTURA_ENTREGADA.bmp")  ' Entregada 
            '
            C_RECOJO = New Bitmap("..\icon\C_RECOJO.bmp")
            C_RECEPCIONADO = New Bitmap("..\icon\C_RECEPCIONADO.bmp")
            C_DESPACHADO = New Bitmap("..\icon\C_DESPACHADO.bmp")
            C_DESPACHO_PARCIAL = New Bitmap("..\icon\C_DESPACHO_PARCIAL.bmp")
            C_LLEGADA = New Bitmap("..\icon\C_LLEGADA.bmp")
            C_LLEGADA_PARCIAL = New Bitmap("..\icon\C_LLEGADA_PARCIAL.bmp")
            C_PERDIDO = New Bitmap("..\icon\C_PERDIDO.bmp")
            C_ENTREGADO = New Bitmap("..\icon\C_ENTREGADO.bmp")
            C_CARGO = New Bitmap("..\icon\C_CARGO.bmp")
            C_REPARTO = New Bitmap("..\icon\C_REPARTO.bmp")
            '
            C_DEVOLUCION = New Bitmap("..\icon\C_DEVOLUCION.bmp")
            C_ABANDONO_LEGAL = New Bitmap("..\icon\C_ABANDONO_LEGAL.bmp")
            C_FACTURADO = New Bitmap("..\icon\C_FACTURADO.bmp")
            '06/02/2008
            bmpC_REPARTO_PARCIAL = New Bitmap("..\icon\C_REPARTO_PARCIAL.bmp")
            bmpC_ENTREGADO_PARCIAL = New Bitmap("..\icon\C_ENTREGADO_PARCIAL.bmp")
            '
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Sub
    Public Sub LoadFrm(ByVal var As System.Windows.Forms.Form)

        'var.ShowModal()
        var.ShowDialog()
    End Sub
    Public Function ValiadarEXP_REG_Mail(ByRef txtStr As String) As Boolean
        Try
            Dim re As System.Text.RegularExpressions.Regex
            re = New System.Text.RegularExpressions.Regex(EMAIL)
            'Regex rx = new Regex(@"^-?\d+(\.\d{2})?$");
            If re.IsMatch(txtStr.ToString()) Then
                ValiadarEXP_REG_Mail = True
            Else
                ValiadarEXP_REG_Mail = False
            End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Function
    Public Function ValiadarEXP_REG_NUMERO(ByRef txtStr As String) As Boolean
        Try
            Dim re As System.Text.RegularExpressions.Regex
            're = New System.Text.RegularExpressions.Regex(NUMBERS_CONTROL)
            're = New System.Text.RegularExpressions.Regex(NUMBERS_CONTROL)
            re = New System.Text.RegularExpressions.Regex("^\d+$")
            If re.IsMatch(txtStr.ToString()) Then
                ValiadarEXP_REG_NUMERO = True
            Else
                ValiadarEXP_REG_NUMERO = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Function
    Public Function LlenarCabeceraLista(ByRef cLista As ListView, ByRef cCabeceraLista As Collection) As Integer
        Try
            cLista.FullRowSelect = True
            cLista.GridLines = True
            cLista.Sorting = SortOrder.Ascending
            Dim imageListSmall As New ImageList()
            'imageListSmall.Images.Add(Bitmap.FromFile("c:\icon\Personas.bmp"))  modificado 12/10/2006
            'imageListSmall.Images.Add(Bitmap.FromFile("c:\icon\Personas.bmp"))
            imageListSmall.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
            imageListSmall.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
            cLista.SmallImageList = imageListSmall
            With cLista
                .View = View.Details
                .FullRowSelect = True
                .GridLines = True
                .LabelEdit = False
                .CheckBoxes = True
                For Each thisObject As ListViewCabecera In cCabeceraLista
                    .Columns.Add(thisObject.Nombre().ToString(), thisObject.Tamanio, thisObject.Aliniacion)
                Next thisObject
            End With
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
        End Try
    End Function
    ' Public Function LlenarLista2009(ByVal rst As ADODB.Recordset, ByRef cLista As ListView, ByRef cCabeceraLista As Collection) As Integer
    'Try
    '    'ejemplo solo para imagenes....
    '    'ListView1.SmallImageList.Images(0) = New Bitmap("c:\green.bmp")
    '    'ListView1.Items(0).ImageIndex = 1
    '    'ListView1.Items(0).ImageIndex = 0

    '    '            cLista.CheckBoxes = True
    '    '           cLista.FullRowSelect = True
    '    '          cLista.GridLines = True

    '    'Dim listView1 As New ListView()
    '    'cLista.Bounds = New Rectangle(New Point(10, 10), New Size(300, 200))

    '    ' Set the view to show details.
    '    'cLista.View = View.Details
    '    ' Allow the user to edit item text.
    '    'cLista.LabelEdit = True
    '    ' Allow the user to rearrange columns.
    '    'cLista.AllowColumnReorder = True
    '    ' Display check boxes.
    '    'cLista.CheckBoxes = True
    '    ' Select the item and subitems when selection is made.
    '    cLista.FullRowSelect = True
    '    ' Display grid lines.
    '    cLista.GridLines = True
    '    ' Sort the items in the list in ascending order.
    '    cLista.Sorting = SortOrder.Ascending


    '    Dim imageListSmall As New ImageList()
    '    Dim imageListLarge As New ImageList()

    '    ' Initialize the ImageList objects with bitmaps.
    '    'imageListSmall.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))  Modificado 12/10/2006
    '    'imageListSmall.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
    '    'imageListLarge.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
    '    'imageListLarge.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))

    '    imageListSmall.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
    '    imageListSmall.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
    '    imageListLarge.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))
    '    imageListLarge.Images.Add(Bitmap.FromFile("..\icon\Personas.bmp"))

    '    'Assign the ImageList objects to the ListView.
    '    cLista.LargeImageList = imageListLarge
    '    cLista.SmallImageList = imageListSmall
    '    'cLista.SmallImageList.Images(0) = New Bitmap("c:\Personas.bmp")


    '    ' Add the ListView to the control collection.
    '    'Controls.Add(cLista)


    '    'cLista.Bounds = New Rectangle(New Point(10, 10), New Size(300, 200))

    '    ' Set the view to show details.
    '    'cLista.View = View.Details
    '    ' Allow the user to edit item text.
    '    'cLista.LabelEdit = True
    '    'cLista.SmallImageList.Images(0) = New Bitmap("c:\Personas.bmp")

    '    'If rst.EOF = True And rst.BOF = True Then
    '    'For Each thisObject As ListViewCabecera In cCabeceraLista
    '    'cLista.Columns.Add(thisObject.Nombre().ToString(), thisObject.Tamanio, thisObject.Aliniacion)
    '    'Next thisObject
    '    'Exit Function
    '    'End If

    '    With cLista
    '        .View = View.Details
    '        .FullRowSelect = True
    '        .GridLines = True
    '        .LabelEdit = False
    '        .CheckBoxes = True
    '        '.Columns.Clear()
    '        '.Items.Clear()


    '        ' If cCabeceraLista.Count > 0 Then
    '        'it = cCabeceraLista(0)
    '        '   Else
    '        'Return -1
    '        '   End If

    '        For Each thisObject As ListViewCabecera In cCabeceraLista
    '            .Columns.Add(thisObject.Nombre().ToString(), thisObject.Tamanio, thisObject.Aliniacion)
    '        Next thisObject
    '        'For iIndex = 0 To cCabeceraLista.Count - 1
    '        '.Columns.Add(cCabeceraLista(iIndex).Item(0), cCabeceraLista(iIndex).Item(1), cCabeceraLista(iIndex).Item(2))
    '        'Next iIndex
    '        '.Columns.Add("Cadena", 90, HorizontalAlignment.Left)
    '        '.Columns.Add("Número", 90, HorizontalAlignment.Right)
    '        '.Columns.Add("Fecha", 90, HorizontalAlignment.Center)
    '        ' Asignar algunos valores al listview
    '        Dim i As Integer
    '        'Dim r As New System.Random()
    '        Dim it1 As Integer
    '        If rst.EOF = False And rst.BOF = False Then
    '            rst.MoveFirst()
    '        Else
    '            Exit Function
    '        End If
    '        'Dim type As DataTypeEnum
    '        i = 0
    '        While rst.BOF = False And rst.EOF = False
    '            With .Items.Add(Int(rst.Fields(0).Value.ToString()))
    '                cLista.Items(i).Tag = Int(rst.Fields(0).Value.ToString())
    '                cLista.Items(i).ImageIndex = 0

    '                If (i Mod 2) = 0 Then
    '                    cLista.Items(i).BackColor = Color.Silver
    '                Else
    '                    cLista.Items(i).BackColor = Color.DarkCyan
    '                End If

    '                'itmp.BackColor = System.Drawing.Color.Silver

    '                'cLista.Items(i).ImageIndex = 0
    '                'cLista.Items(0).Tag = 1
    '                '.SubItems.Add(((i + 1) * 2500).ToString("###,###"))
    '                '.SubItems.Add((DateTime.Now.AddYears(i).ToString("dd/MM/yyyy")));
    '                For it1 = 1 To cCabeceraLista.Count - 1
    '                    If rst.Fields(it1).Type <> DataTypeEnum.adEmpty Then
    '                        .SubItems.Add(rst.Fields(it1).Value.ToString())
    '                        .SubItems(1).BackColor = Color.Cyan
    '                    Else
    '                        .SubItems.Add("")
    '                    End If
    '                Next it1
    '                rst.MoveNext()
    '            End With
    '            i = i + 1
    '        End While



    '        ' Por defecto se clasifica por la primera columna
    '        '.Sorting = SortOrder.Ascending
    '        '.Sort()
    '    End With


    '    Exit Function

    'Catch ex As Exception
    '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema...")
    'End Try


    'End Function
    '   Public Function LlenarCombo2009(ByVal rst As ADODB.Recordset, ByRef cLista As ComboBox) As Integer
    'Try
    '    Dim index As Integer
    '    index = 0
    '    cLista.DropDownStyle = ComboBoxStyle.DropDownList

    '    While rst.BOF = False And rst.EOF = False
    '        cLista.Items.Insert(index, rst.Fields(1).Value)
    '        'cLista.Items.Item(index).  
    '        '                cLista.Items(index).tag = rst.Fields(0).Value
    '        'cLista.Items.in .Item(0)
    '        rst.MoveNext()
    '        index = index + 1
    '    End While
    '    If cLista.Items.Count > 0 Then
    '        cLista.SelectedIndex = 0
    '    Else
    '        cLista.SelectedIndex = -1
    '    End If
    '    ControlError = 1
    'Catch ex As Exception
    '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
    '    ControlError = 0
    'End Try
    'Return ControlError
    'End Function
    Public Function CargaTxtCmb(ByRef cLista As ComboBox, ByRef cColecion As Collection, ByVal i As Integer) As String
        Dim strEstados As String = ""
        Try
            Dim index As Integer = 0
            For index = 0 To cLista.Items().Count
                If Int(cColecion.Item(index.ToString)) = i Then

                    strEstados = cLista.Items().Item(index)
                    index = cLista.Items().Count
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
            strEstados = "NULL"
        End Try
        Return strEstados
    End Function
    'ref:
    'Esta funcion tiene 4 parametros
    'rst los datos a llenar de preferencia idcampo del tipo numeric,nombrecampo varchar(30)
    'cLista es el objeto donde se llenara los datos
    'id es el array donde se llenaran los id del rst
    'idSel 
    'Public Function SelItem2009(ByVal rst As ADODB.Recordset, ByRef cLista As ComboBox, ByRef idSel As Integer) As Integer
    'Try
    '    Dim index As Integer
    '    Dim indexSeleccion As Integer
    '    index = 0
    '    indexSeleccion = 0
    '    If rst.BOF = False And rst.EOF = False Then
    '        rst.MoveFirst()
    '    End If
    '    While rst.BOF = False And rst.EOF = False
    '        If idSel = rst.Fields(0).Value Then
    '            indexSeleccion = index
    '        End If
    '        rst.MoveNext()
    '        index = index + 1
    '    End While
    '    If cLista.Items.Count > 0 Then
    '        cLista.SelectedIndex = indexSeleccion
    '    Else
    '        cLista.SelectedIndex = -1
    '    End If
    '    ControlError = 1
    'Catch ex As Exception
    '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
    '    ControlError = 0
    'End Try
    'Return ControlError
    'End Function
    Public Function NingunoComboIDs(ByRef cLista As ComboBox, ByRef id As Collection) As Integer
        Try
            cLista.DropDownStyle = ComboBoxStyle.DropDownList
            cLista.Controls.Clear()
            cLista.Items.Clear()
            id = Nothing
            id = New Collection()
            cLista.Items.Insert(0, "-NINGUNO-")
            id.Add(0, "0")
            cLista.SelectedIndex = 0
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
    End Function
    'Public Function LlenarComboIDs2009(ByVal rst As ADODB.Recordset, ByRef cLista As ComboBox, ByRef id As Collection, ByRef idSel As Integer) As Integer
    '    Try
    '        Dim index As Integer
    '        Dim indexSeleccion As Integer
    '        index = 0
    '        indexSeleccion = 0
    '        cLista.DropDownStyle = ComboBoxStyle.DropDownList
    '        cLista.Controls.Clear()
    '        cLista.Items.Clear()
    '        id = Nothing
    '        id = New Collection()
    '        '
    '        If Not (rst Is Nothing) Then
    '            While rst.BOF = False And rst.EOF = False
    '                '
    '                cLista.Items.Insert(index, rst.Fields(1).Value)
    '                id.Add(rst.Fields(0).Value, index.ToString())
    '                If idSel = rst.Fields(0).Value Then
    '                    indexSeleccion = index
    '                End If

    '                rst.MoveNext()
    '                index = index + 1
    '            End While
    '        End If
    '        ' 
    '        If cLista.Items.Count > 0 Then
    '            cLista.SelectedIndex = indexSeleccion
    '        Else
    '            cLista.SelectedIndex = -1
    '        End If
    '        ControlError = 1
    '    Catch ex As Exception
    '        MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
    '        ControlError = 0
    '    End Try
    '    Return ControlError
    'End Function
    '29/08/2009 - Por Datahelper
    Public Function LlenarComboIDs_dt(ByVal dt As DataTable, ByRef cLista As ComboBox, ByRef id As Collection, ByRef idSel As Integer) As Integer
        Try
            Dim index As Integer
            Dim indexSeleccion As Integer
            index = 0
            indexSeleccion = 0
            cLista.DropDownStyle = ComboBoxStyle.DropDownList
            cLista.Controls.Clear()
            cLista.Items.Clear()
            id = Nothing
            id = New Collection()
            '
            For Each row As DataRow In dt.Rows
                '
                cLista.Items.Insert(index, row.Item(1))
                id.Add(row.Item(0), index.ToString())
                If idSel = row.Item(0) Then
                    indexSeleccion = index
                End If
                index = index + 1
            Next
            ' 
            If cLista.Items.Count > 0 Then
                cLista.SelectedIndex = indexSeleccion
            Else
                cLista.SelectedIndex = -1
            End If
            ControlError = 1
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
            ControlError = 0
        End Try
        Return ControlError
    End Function
    Public Function LlenarTreeCtrl2009(ByVal rst As ADODB.Recordset, ByRef cTree As TreeView, ByRef Cabecera As String) As Integer
        '' Modificado por el codigo x  
        'Try
        '    cTree.Nodes.Clear()
        '    cTree.CheckBoxes = True
        '    cTree.Nodes.Add(Cabecera)
        '    Dim i, j As Integer


        '    Dim imageListSmall As New ImageList()
        '    Dim imageListLarge As New ImageList()

        '    ' Initialize the ImageList objects with bitmaps.
        '    'imageListSmall.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
        '    'imageListSmall.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
        '    'imageListLarge.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))
        '    'imageListLarge.Images.Add(Bitmap.FromFile("C:\Personas.bmp"))

        '    'Assign the ImageList objects to the ListView.
        '    'cTree.ImageList = imageListLarge
        '    'cTree.SmallImageList = imageListSmall
        '    'For i = 0 To rst.Fields.Count - 1
        '    'cTree.Nodes(0).Nodes.Add(rst.Fields(1).Value)
        '    'cTree.Nodes(0).SelectedImageIndex = 0
        '    'cTree.Nodes(0).Nodes(i).Tag = rst.Fields(0).Value
        '    'cTree.Nodes(0).Nodes(i).SelectedImageIndex = 0
        '    'rst.MoveNext()
        '    'Next i
        '    i = 0
        '    j = 0
        '    Dim tmp As String
        '    tmp = "xxx"
        '    If rst.BOF = False Then
        '        rst.MoveFirst()
        '        While rst.BOF = False And rst.EOF = False
        '            If tmp <> rst.Fields(1).Value Then
        '                cTree.Nodes(0).Nodes.Add(rst.Fields(1).Value)
        '                'cTree.Nodes(0).SelectedImageIndex = 0
        '                cTree.Nodes(0).Nodes(i).Tag = rst.Fields(0).Value
        '                'cTree.Nodes(0).Nodes(i).SelectedImageIndex = 0
        '                tmp = rst.Fields(1).Value
        '                i = i + 1
        '                '      j = 0
        '                '   Else
        '                '     cTree.Nodes(0).Nodes(1).Nodes.Add("JAIMESS")
        '                '    cTree.Nodes(0).Nodes(1).Nodes(j).Tag = 1
        '            End If
        '            rst.MoveNext()
        '            'i = i + 1
        '        End While
        '        'rst.Close()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
        'Return 1
    End Function
    Public Function LlenarTreeListViewCtrl2009(ByVal rst As ADODB.Recordset, ByRef cTree As TreeView, ByRef Cabecera As String) As Integer
        'Try
        '    cTree.Nodes.Clear()
        '    'cTree.CheckBoxes = True
        '    cTree.Nodes.Add(Cabecera)
        '    Dim i, j As Integer

        '    i = 0
        '    j = 0
        '    Dim tmp As String
        '    tmp = "xxx"
        '    If rst.BOF = False Then
        '        rst.MoveFirst()
        '        Dim n, nn As TreeNode
        '        While rst.BOF = False And rst.EOF = False
        '            If tmp <> rst.Fields(1).Value Then
        '                n = cTree.Nodes(0).Nodes.Add(rst.Fields(1).Value)
        '                cTree.Nodes(0).Nodes(i).Tag = rst.Fields(0).Value
        '                tmp = rst.Fields(1).Value
        '                i = i + 1
        '                j = 0
        '            Else
        '                nn = n.Nodes.Add(rst.Fields(3).Value)
        '                'n.Nodes(j).Tag = rst.Fields(2).Value
        '                j = j + 1
        '            End If
        '            rst.MoveNext()
        '        End While
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        'End Try
    End Function
    Public Function NroEnLetras(ByVal curNumero As Double, Optional ByVal blnO_Final As Boolean = True) As String
        Try
        Catch ex As Exception
        End Try
        'Devuelve un número expresado en letras.
        'El parámetro blnO_Final se utiliza en la recursión para saber si se debe colocar
        'la "O" final cuando la palabra es UN(O)
        Dim dblCentavos As Double
        Dim lngContDec As Long
        Dim lngContCent As Long
        Dim lngContMil As Long
        Dim lngContMillon As Long
        Dim strNumLetras As String = ""

        'Dim strNumero As Object
        'Dim strDecenas As Object
        'Dim strCentenas As Object

        Dim blnNegativo As Boolean
        Dim blnPlural As Boolean
        If Int(curNumero) = 0.0# Then
            strNumLetras = "CERO"
        End If
        Dim strNumero() As Object = {vbNullString, "UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", _
                       "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", _
                       "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE", _
                       "VEINTE"}

        Dim strDecenas() As Object = {vbNullString, vbNullString, "VEINTI", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", _
                        "SETENTA", "OCHENTA", "NOVENTA", "CIEN"}
        Dim strCentenas() As Object = {vbNullString, "CIENTO", "DOSCIENTOS", "TRESCIENTOS", _
                         "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", _
                         "OCHOCIENTOS", "NOVECIENTOS"}

        If curNumero < 0.0# Then
            blnNegativo = True
            curNumero = Abs(curNumero)
        End If

        If Int(curNumero) <> curNumero Then
            dblCentavos = Abs(curNumero - Int(curNumero))
            curNumero = Int(curNumero)
        End If

        Do While curNumero >= 1000000.0#
            lngContMillon = lngContMillon + 1
            curNumero = curNumero - 1000000.0#
        Loop
        Do While curNumero >= 1000.0#
            lngContMil = lngContMil + 1
            curNumero = curNumero - 1000.0#
        Loop
        Do While curNumero >= 100.0#
            lngContCent = lngContCent + 1
            curNumero = curNumero - 100.0#
        Loop
        If Not (curNumero > 10.0# And curNumero <= 20.0#) Then
            Do While curNumero >= 10.0#
                lngContDec = lngContDec + 1
                curNumero = curNumero - 10.0#
            Loop
        End If
        If lngContMillon > 0 Then
            If lngContMillon >= 1 Then   'si el número es >1000000 usa recursividad
                strNumLetras = NroEnLetras(lngContMillon, False)
                If Not blnPlural Then blnPlural = (lngContMillon > 1)
                lngContMillon = 0
            End If
            strNumLetras = Trim(strNumLetras) & strNumero(lngContMillon) & " MILLON" & _
                                                                        IIf(blnPlural, "ES ", " ")
        End If
        If lngContMil > 0 Then
            If lngContMil >= 1 Then   'si el número es >100000 usa recursividad
                strNumLetras = strNumLetras & NroEnLetras(lngContMil, False)
                lngContMil = 0
            End If
            strNumLetras = Trim(strNumLetras) & strNumero(lngContMil) & " MIL "
        End If

        If lngContCent > 0 Then
            If lngContCent = 1 And lngContDec = 0 And curNumero = 0.0# Then
                strNumLetras = strNumLetras & "CIEN"
            Else
                strNumLetras = strNumLetras & strCentenas(lngContCent) & " "
            End If
        End If

        If lngContDec >= 1 Then
            If lngContDec = 1 Then
                strNumLetras = strNumLetras & strNumero(10)
            Else
                strNumLetras = strNumLetras & strDecenas(lngContDec)
            End If

            If lngContDec >= 3 And curNumero > 0.0# Then
                strNumLetras = strNumLetras & " Y "
            End If
        Else
            If curNumero >= 0.0# And curNumero <= 20.0# Then
                strNumLetras = strNumLetras & strNumero(curNumero)
                If curNumero = 1.0# And blnO_Final Then
                    strNumLetras = strNumLetras & "O"
                End If
                If dblCentavos > 0.0# Then
                    strNumLetras = Trim(strNumLetras) & " CON " & Format$(CInt(dblCentavos * 100.0#), "00") & "/100"
                End If
                NroEnLetras = strNumLetras
                Exit Function
            End If
        End If

        If curNumero > 0.0# Then
            strNumLetras = strNumLetras & strNumero(curNumero)
            If curNumero = 1.0# And blnO_Final Then
                strNumLetras = strNumLetras & "O"
            End If
        End If
        If dblCentavos > 0.0# Then
            strNumLetras = strNumLetras & " CON " + Format$(CInt(dblCentavos * 100.0#), "00") & "/100"
        End If
        NroEnLetras = IIf(blnNegativo, "(" & strNumLetras & ")", strNumLetras)
    End Function
    Public Function Abs(ByVal curNumero As Double) As Double
        On Error GoTo 0
        If curNumero < 0 Then
            curNumero = (-1) * curNumero
        End If
        Abs = curNumero
        Exit Function
0:
        MsgBox(Err.Description(), MsgBoxStyle.Critical, "Seguridad Sistema")
    End Function

    Public Class ListViewCabecera
        Public m_sNombre As String
        Public m_sTamanio As Integer
        Public m_iAliniacion As HorizontalAlignment 'Left =0 , Right=1 ' Center=2
        Public m_iTipoDato As Integer '0 imagen,1 integer , 2 decimal 3 string 4 fecha, 5 object     
        Public Property Nombre() As String
            Get
                Return m_sNombre
            End Get
            Set(ByVal Value As String)
                m_sNombre = Value
            End Set
        End Property
        Public Property Tamanio() As Integer
            Get
                Return m_sTamanio
            End Get
            Set(ByVal Value As Integer)
                m_sTamanio = Value
            End Set
        End Property
        Public Property Aliniacion() As HorizontalAlignment
            Get
                Return m_iAliniacion
            End Get
            Set(ByVal Value As HorizontalAlignment)
                m_iAliniacion = Value
            End Set
        End Property
        Public Property TipoDato() As Integer
            Get
                Return m_iTipoDato
            End Get
            Set(ByVal Value As Integer)
                If Value >= 0 And Value < 5 Then
                    m_iTipoDato = Value
                Else
                    m_iTipoDato = 5
                End If
            End Set
        End Property
        Public Sub New(ByVal Nombre As String, ByVal _
            Tamanio As Integer, ByVal Aliniacion As HorizontalAlignment, ByVal TipoDato As Integer)
            m_sNombre = Nombre
            m_sTamanio = Tamanio
            m_iAliniacion = Aliniacion
            m_iTipoDato = TipoDato
        End Sub
    End Class


    Function AnalyseNode(ByRef pNode As TreeView) As String

        Dim lStr As String
        lStr = ""
        '      Dim i As Integer
        ''lStr = cstr(pNode.Tag)+";"+"cstr(pNode.Parent.Tag)+";"+pNode.Text
        ' For i = 0 To pNode.Nodes.ChildNode.Count
        'lStr += "|" + AnalyseNode(pNode.Item(i))
        '  Next
        Return lStr

    End Function
    Public Function ControlAccesos(ByVal pForm As Windows.Forms.Form) As Boolean
        Try
            Dim i As Integer
            pForm.Controls(1).Enabled = False
            Dim varname As String
            For i = 0 To pForm.Controls.Count - 1
                varname = pForm.Controls(i).Name
                pForm.Controls(i).Enabled = True
            Next i
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Function
    Public Function ControlAccesosUsuarios(ByVal pForm As Windows.Forms.Form, ByVal irRol As Integer) As Boolean
        Try
            Dim i As Integer

            pForm.Controls(1).Enabled = False
            Dim varname As String
            'Dim pForm1 As Windows.Forms.Form
            'pForm1 = CType(" ", Windows.Forms.Form)
            For i = 0 To pForm.Controls.Count - 1
                varname = pForm.Controls(i).Name
            Next i
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Function
    'Public Function BuscarItemCM(ByVal rst As ADODB.Recordset, ByVal cmbCtrl As ComboBox, ByVal idSel As Integer) As Boolean
    '    Try
    '        Dim index, indexSeleccion As Integer
    '        index = 0
    '        rst.MoveFirst()
    '        While rst.BOF = False And rst.EOF = False
    '            If idSel = rst.Fields(0).Value Then
    '                indexSeleccion = index
    '            End If
    '            rst.MoveNext()
    '            index = index + 1
    '        End While

    '        If index > 0 Then
    '            cmbCtrl.SelectedIndex = indexSeleccion
    '        Else
    '            cmbCtrl.SelectedIndex = -1
    '        End If
    '        ControlError = 1
    '        If indexSeleccion > 0 Then

    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    '    End Try
    'End Function
    Public Function BuscarItemCM(ByVal dt As DataTable, ByVal cmbCtrl As ComboBox, ByVal idSel As Integer) As Boolean
        Try
            Dim index, indexSeleccion As Integer
            index = 0
            If dt.Rows.Count > 0 Then
                For Each obj As DataRow In dt.Rows
                    If idSel = obj.Item(0) Then
                        indexSeleccion = index
                    End If
                    index += 1
                Next
            Else
                cmbCtrl.SelectedIndex = -1
            End If

            If index > 0 Then
                cmbCtrl.SelectedIndex = indexSeleccion
            Else
                cmbCtrl.SelectedIndex = -1
            End If
            ControlError = 1

        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function LimpiarGrid(ByVal dgrid As DataGridView) As Boolean
        Try
            Dim i, CountITEN As Integer
            CountITEN = dgrid.Rows().Count
            For i = 0 To dgrid.Rows().Count - 2
                dgrid.Rows().RemoveAt(CountITEN - i - 2)
            Next
            dgrid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
        Return False
    End Function
    'Public Function CargarDataGrid2009(ByVal rst As ADODB.Recordset, ByVal grid As DataGridView, ByVal nCol As Integer) As Boolean
    'Try
    '    LimpiarGrid(grid)
    '    Dim i As Integer
    '    For i = 0 To grid.Rows().Count - 1
    '        'grid.Rows().Remove(grid.Rows(0))
    '    Next
    '    While rst.BOF = False And rst.EOF = False
    '        Dim dto() As Object = {rst.Fields.Item(0).Value, rst.Fields.Item(1).Value}
    '        grid.Rows().Add(dto)
    '        rst.MoveNext()
    '        i = i + 1
    '    End While
    '    grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
    'Catch ex As Exception
    '    MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
    'End Try
    'Return True
    'End Function
    Public Function FormatoMenorandum(ByVal str As String, ByVal car As String, ByVal iNro As Integer) As String
        Dim StrFormato As String = ""
        StrFormato = str
        Try
            Dim CountSTR As Integer = Len(str)
            Dim i As Integer = 0
            For i = 1 To iNro - CountSTR
                StrFormato = car & StrFormato
            Next
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Exclamation, "Seguridad Sistema")
        End Try
        Return StrFormato
    End Function
    Public Sub Tab_Control3(ByVal Menutab As MenuStrip, ByVal tab As Integer)
        Try
            If tab = 1 Then 'Load /grabar/cancelar
                Menutab.Items(0).Enabled = True
                Menutab.Items(1).Enabled = False
                Menutab.Items(2).Enabled = False
            End If
            If tab = 2 Then 'Nuevo /editar
                Menutab.Items(0).Enabled = False
                Menutab.Items(1).Enabled = True
                Menutab.Items(2).Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Sub
    'Public Function SP_CONTROL_UBIGEO_2009(ByVal iControl As Integer, ByVal iFiltro As Integer) As Boolean
    '    Dim flat As Boolean = True
    '    Try
    '        Dim varSP_OBJECT As Object() = {"PKG_IVOUUTILS.SP_CONTROL_UBIGEO", 6, iControl, 1, iFiltro, 1}
    '        rst_cur_datos = Nothing
    '        rst_cur_datos = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If rst_cur_datos.EOF = False And rst_cur_datos.BOF = False Then
    '            flat = True
    '        Else
    '            flat = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Critical, "Seguridad Sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function SP_CONTROL_UBIGEO(ByVal iControl As Integer, ByVal iFiltro As Integer) As Boolean
        Dim flat As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            dt_rst_cur_datos = Nothing
            dt_rst_cur_datos = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOUUTILS.SP_CONTROL_UBIGEO", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iControl", iControl, OracleClient.OracleType.Int32)
            db_bd.AsignarParametro("idFiltro", iFiltro, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            If ldt_tmp.Rows.Count > 0 Then
                dt_rst_cur_datos = ldt_tmp
                flat = True
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flat
    End Function
    'Public Function Get_LocalIPAddress() As String
    '    Dim strIP As String = ""
    '    Try
    '        Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
    '        strIP = CType(h.AddressList.GetValue(0), System.Net.IPAddress).ToString
    '    Catch ex As Exception
    '        MsgBox(ex.ToString & " No Tiene IP", MsgBoxStyle.Information, "Seguridad Sistem")
    '    End Try
    '    Return strIP
    'End Function

    Public Function Get_LocalIPAddress() As String
        Dim strIP As String = ""
        Dim db_bd As New BaseDatos
        Dim ldt_tmp As DataTable

        Try

            Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
            'strIP = CType(h.AddressList.GetValue(0), System.Net.IPAddress).ToString

            For Each tmpIpAddress As System.Net.IPAddress In h.AddressList

                If tmpIpAddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                    strIP = tmpIpAddress.ToString
                    db_bd.Conectar()

                    db_bd.CrearComando("PKG_UTILITARIOS.SP_VALIDAR_IP", CommandType.StoredProcedure)
                    db_bd.AsignarParametro("P_Ip", strIP, OracleClient.OracleType.VarChar)
                    db_bd.AsignarParametro("Cur_Acceso", OracleClient.OracleType.Cursor)

                    db_bd.Desconectar()
                    ldt_tmp = db_bd.EjecutarDataTable

                    If Not IsNothing(ldt_tmp) Then
                        If ldt_tmp.Rows.Count = 1 Then
                            If Convert.ToInt32(ldt_tmp.Rows(0)(0).ToString) = 1 Then
                                Exit For
                            End If
                        End If
                    End If
                End If

            Next
        Catch ex As Exception
            MsgBox(ex.ToString & " No Tiene IP", MsgBoxStyle.Information, "Seguridad Sistem")
        End Try
        Return strIP
    End Function

    Public Function fnValidar_Rol(ByRef IdRol_Control As String) As Boolean
        Dim flag As Boolean = False
        Try
            'dtoUSUARIOS.rst_Rol_Usuario.MoveFirst()
            'If dtoUSUARIOS.rst_Rol_Usuario.BOF = False And dtoUSUARIOS.rst_Rol_Usuario.EOF = False Then

            '    While dtoUSUARIOS.rst_Rol_Usuario.BOF = False And dtoUSUARIOS.rst_Rol_Usuario.EOF = False
            '        If dtoUSUARIOS.rst_Rol_Usuario.Fields.Item(0).Value.ToString = IdRol_Control Then
            '            flag = True
            '            dtoUSUARIOS.IdRol = IdRol_Control
            '            GoTo CONTROL_SALIDA
            '        End If
            '        dtoUSUARIOS.rst_Rol_Usuario.MoveNext()
            '    End While
            If dtoUSUARIOS.dt_rst_Rol_Usuario.Rows.Count > 0 Then

                For Each fila As DataRow In dtoUSUARIOS.dt_rst_Rol_Usuario.Rows
                    If fila.Item(0).ToString = IdRol_Control Then
                        flag = True
                        dtoUSUARIOS.IdRol = IdRol_Control
                        GoTo CONTROL_SALIDA
                    End If
                Next
            Else
                flag = False
            End If
            'For Each thisObject As dtoRoles In coll_Lista_Roles
            '    If thisObject.ToString = IdRol_Control Then
            '        flag = True
            '        GoTo CONTROL_SALIDA
            '    End If
            'Next thisObject

        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
            flag = False
        End Try
CONTROL_SALIDA:
        Return flag
    End Function
    'Public Function fnINICIO_SESION_2009() As Boolean
    '    Dim flag As Boolean = False
    '    Try
    '        'Public rst_Rol_Usuario As ADODB.Recordset
    '        'Public cur_Datos_Generales_Server As New ADODB.Recordset
    '        'Public cur_Menu_Usuario As New ADODB.Recordset
    '        'Public cur_Formularios_Usuario As New ADODB.Recordset
    '        'Public cur_Error As New ADODB.Recordset
    '        ' 21/08/2007 
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_INICIO_SESION_", 8, dtoUSUARIOS.iLOGIN, 2, dtoUSUARIOS.Password, 2, dtoUSUARIOS.IP, 2}
    '        ' Dim varSP_OBJECT() As Object = {"PKG_IVOUUTILS.SP_INICIO_SESION", 8, dtoUSUARIOS.iLOGIN, 2, dtoUSUARIOS.Password, 2, dtoUSUARIOS.IP, 2}
    '        dtoUSUARIOS.cur_Datos_Generales_Server = Nothing
    '        dtoUSUARIOS.cur_Datos_Generales_Server = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        If dtoUSUARIOS.cur_Datos_Generales_Server.EOF = False And dtoUSUARIOS.cur_Datos_Generales_Server.BOF = False Then
    '            'Quitando el mensaje de bienvenido. 
    '            'MsgBox(dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            dtoUSUARIOS.IdLogin = Int(dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(2).Value.ToString)
    '            ' 
    '            dtoUSUARIOS.dfecha_sistema = CType(dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(3).Value, Date)
    '            dtoUSUARIOS.m_sFecha = CType(dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(3).Value, Date)
    '            dtoUSUARIOS.iIDAGENCIAS = Int(dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(4).Value.ToString)
    '            dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.iIDAGENCIAS
    '            dtoUSUARIOS.iIGV = dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(6).Value
    '            dtoUSUARIOS.m_idciudad = dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(7).Value
    '            dtoUSUARIOS.vImpuesto = dtoUSUARIOS.iIGV / 100
    '            ' 
    '            Try
    '                Dim strFecha As String() = Split(dtoUSUARIOS.dfecha_sistema, "/")
    '                If strFecha.Length = 3 Then
    '                    'objLOG.CrearFolderLog("C:\", dtoUSUARIOS.iLOGIN, strFecha(2) & strFecha(1) & strFecha(0)) modificado 12/10/2006
    '                    objLOG.CrearFolderLog("..\", dtoUSUARIOS.iLOGIN, strFecha(2) & strFecha(1) & strFecha(0))
    '                    objLOG.fnLog("[ INGRESO AL SISTEMA ]")
    '                End If

    '            Catch ex As Exception

    '            End Try
    '            '
    '            If Int(dtoUSUARIOS.cur_Datos_Generales_Server.Fields.Item(0).Value.ToString) = 1 Then
    '                'Es lo + imp arrays de roles 
    '                dtoUSUARIOS.rst_Rol_Usuario = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '                dtoUSUARIOS.cur_Menu_Usuario = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '                dtoUSUARIOS.cur_Formularios_Usuario = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '                dtoUSUARIOS.cur_Error = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '                If dtoUSUARIOS.rst_Rol_Usuario.EOF = False And dtoUSUARIOS.rst_Rol_Usuario.BOF = False Then
    '                    flag = True
    '                Else
    '                    MsgBox("No tiene Asignado ningun ROL para el ingreso al  sistema", MsgBoxStyle.Information, "Seguridad Sistema")
    '                    flag = False
    '                End If
    '            Else
    '                flag = False
    '            End If
    '        Else
    '            dtoUSUARIOS.rst_Rol_Usuario = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '            dtoUSUARIOS.cur_Menu_Usuario = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '            dtoUSUARIOS.cur_Formularios_Usuario = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '            dtoUSUARIOS.cur_Error = dtoUSUARIOS.cur_Datos_Generales_Server.NextRecordset
    '            If dtoUSUARIOS.cur_Error.EOF = False And dtoUSUARIOS.cur_Error.BOF = False Then
    '                MsgBox(dtoUSUARIOS.cur_Error.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '            End If
    '            flag = False
    '        End If
    '    Catch ex As Exception
    '        Dim smensaje As String
    '        smensaje = "Usuario desconcido"
    '        If dtoUSUARIOS.cur_Error.EOF = False And dtoUSUARIOS.cur_Error.BOF = False Then
    '            MsgBox(smensaje, MsgBoxStyle.Information, "Seguridad Sistema")
    '            'MsgBox(dtoUSUARIOS.cur_Error.Fields.Item(1).Value.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        Else
    '            MsgBox(smensaje, MsgBoxStyle.Information, "Seguridad Sistema")
    '            'MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        End If

    '        flag = False
    '    End Try
    '    Return flag
    'End Function
    Public Function fnINICIO_SESION() As Boolean
        Dim flag As Boolean = False
        Try
            '
            Dim db_bd As New BaseDatos
            Dim lds_tmp As New DataSet
            '
            dtoUSUARIOS.dt_cur_Datos_Generales_Server = Nothing
            dtoUSUARIOS.dt_cur_Datos_Generales_Server = New DataTable
            '
            dtoUSUARIOS.dt_rst_Rol_Usuario = Nothing
            dtoUSUARIOS.dt_rst_Rol_Usuario = New DataTable
            '
            dtoUSUARIOS.dt_cur_Menu_Usuario = Nothing
            dtoUSUARIOS.dt_cur_Menu_Usuario = New DataTable
            '
            dtoUSUARIOS.dt_cur_Formularios_Usuario = Nothing
            dtoUSUARIOS.dt_cur_Formularios_Usuario = New DataTable
            '
            dtoUSUARIOS.dt_cur_cpu = Nothing
            dtoUSUARIOS.dt_cur_cpu = New DataTable
            '
            dtoUSUARIOS.dt_cur_Error = Nothing
            dtoUSUARIOS.dt_cur_Error = New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_IVOUUTILS.SP_INICIO_SESION_2", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iLogin", dtoUSUARIOS.iLOGIN, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iPassword", dtoUSUARIOS.Password, OracleClient.OracleType.VarChar)
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_Datos_Generales_Server", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Roles_Usuario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Menu_Usuario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Formularios_Usuario", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_cpu", OracleClient.OracleType.Cursor)
            db_bd.AsignarParametro("cur_Error", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            lds_tmp = db_bd.EjecutarDataSet
            '
            dtoUSUARIOS.dt_cur_Datos_Generales_Server = lds_tmp.Tables(0)
            If dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows.Count > 0 And dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(0) = 1 Then
                dtoUSUARIOS.IdLogin = Int(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(2).ToString)
                dtoUSUARIOS.IdLoginReal = Int(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(2).ToString)
                dtoUSUARIOS.dfecha_sistema = CType(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(3), Date)
                dtoUSUARIOS.m_sFecha = CType(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(3), Date)
                dtoUSUARIOS.iIDAGENCIAS = Int(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(4).ToString)
                dtoUSUARIOS.m_iIdAgencia = dtoUSUARIOS.iIDAGENCIAS
                dtoUSUARIOS.IdAgenciaReal = dtoUSUARIOS.iIDAGENCIAS
                dtoUSUARIOS.m_iIdUnidadAgencia = Int(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(10).ToString) 'Cambio
                dtoUSUARIOS.IdUnidadAgenciaReal = dtoUSUARIOS.m_iIdUnidadAgencia
                dtoUSUARIOS.Unidad = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("unidad").ToString
                dtoUSUARIOS.LoginPasaje = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("login_pasaje").ToString
                dtoUSUARIOS.DNI = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("dni").ToString
                dtoUSUARIOS.TipoDocumento = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("tipo").ToString
                'dtoUSUARIOS.Portavalor = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("portavalor")
                dtoUSUARIOS.CentroCosto = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("centro_costo").ToString.Trim
                dtoUSUARIOS.CentroCostoDescripcion = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("centro_costo_descripcion").ToString.Trim
                dtoUSUARIOS.CodigoPlanilla = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("codigo_planilla").ToString.Trim
                dtoUSUARIOS.Cierre = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("cierre").ToString.Trim
                dtoUSUARIOS.marcador = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("marcador")
                'pyme

                dtoUSUARIOS.iIGV = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(6)

                dtoUSUARIOS.m_idciudad = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(7)
                dtoUSUARIOS.vImpuesto = dtoUSUARIOS.iIGV / 100
                dtoUSUARIOS.TipoIp = lds_tmp.Tables(4).Rows(0).Item(0).ToString
                dtoUSUARIOS.Cofre = lds_tmp.Tables(4).Rows(0).Item(1).ToString
                dtoUSUARIOS.RolDefecto = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("rol")
                dtoUSUARIOS.NameLogin = dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item("usuario").ToString
                dtoUSUARIOS.FormatoTicket = lds_tmp.Tables(4).Rows(0).Item("formato_ticket").ToString

                If Int(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(0).ToString) = 1 Then
                    '
                    dtoUSUARIOS.dt_rst_Rol_Usuario = lds_tmp.Tables(1)
                    dtoUSUARIOS.dt_cur_Menu_Usuario = lds_tmp.Tables(2)
                    dtoUSUARIOS.dt_cur_Formularios_Usuario = lds_tmp.Tables(3)
                    dtoUSUARIOS.dt_cur_cpu = lds_tmp.Tables(4)
                    dtoUSUARIOS.dt_cur_Error = lds_tmp.Tables(5)
                    '
                    If dtoUSUARIOS.dt_rst_Rol_Usuario.Rows.Count > 0 Then
                        flag = True
                    Else
                        MsgBox("No tiene asignado ningún ROL para el ingreso al  sistema", MsgBoxStyle.Information, "Seguridad Sistema")
                        flag = False
                    End If
                    '
                Else
                    MsgBox(lds_tmp.Tables(0).Rows(0)(1), MsgBoxStyle.Information, "Seguridad Sistema")
                    flag = False
                End If
            Else
                '
                dtoUSUARIOS.dt_rst_Rol_Usuario = lds_tmp.Tables(1)
                dtoUSUARIOS.dt_cur_Menu_Usuario = lds_tmp.Tables(2)
                dtoUSUARIOS.dt_cur_Formularios_Usuario = lds_tmp.Tables(3)
                dtoUSUARIOS.dt_cur_cpu = lds_tmp.Tables(4)
                dtoUSUARIOS.dt_cur_Error = lds_tmp.Tables(5)
                '
                If dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(0) = 0 Then
                    Throw New Exception(dtoUSUARIOS.dt_cur_Datos_Generales_Server.Rows(0).Item(1))
                    flag = False
                End If
                If dtoUSUARIOS.dt_rst_Rol_Usuario.Rows.Count > 0 Then
                    flag = True
                Else
                    MsgBox("No tiene asignado ningún ROL para el ingreso al  sistema", MsgBoxStyle.Information, "Seguridad Sistema")
                    flag = False
                End If
                'Datahelper - 22/10/2009 
                'If dtoUSUARIOS.cur_Error.EOF = False And dtoUSUARIOS.cur_Error.BOF = False Then
                If dtoUSUARIOS.dt_cur_Error.Rows.Count > 0 Then
                    MsgBox(dtoUSUARIOS.dt_cur_Error.Rows(0).Item(1).ToString, MsgBoxStyle.Information, "Seguridad Sistema")
                End If
                flag = False
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return flag
    End Function
    'Public Function LlenarComboIDs22009(ByVal rst As ADODB.Recordset, ByRef cLista As ComboBox, ByRef id As Collection, ByRef idSel As Integer, ByRef cLista1 As ComboBox, ByRef id1 As Collection, ByRef idSel1 As Integer) As Integer
    'Try
    '    Dim index, index1 As Integer
    '    Dim indexSeleccion, indexSeleccion1 As Integer
    '    index = 0
    '    indexSeleccion = 0
    '    index1 = 0
    '    indexSeleccion1 = 0

    '    cLista.DropDownStyle = ComboBoxStyle.DropDownList
    '    cLista.Controls.Clear()
    '    cLista.Items.Clear()
    '    id = Nothing
    '    id = New Collection()

    '    cLista1.DropDownStyle = ComboBoxStyle.DropDownList
    '    cLista1.Controls.Clear()
    '    cLista1.Items.Clear()
    '    id1 = Nothing
    '    id1 = New Collection()


    '    'If rst.BOF = False And rst.EOF = False Then
    '    '    indexSeleccion = rst.Fields(0).Value
    '    'End If
    '    While rst.BOF = False And rst.EOF = False
    '        cLista.Items.Insert(index, rst.Fields(1).Value)
    '        cLista1.Items.Insert(index1, rst.Fields(1).Value)
    '        id.Add(rst.Fields(0).Value, index.ToString())
    '        id1.Add(rst.Fields(0).Value, index.ToString())
    '        If idSel = rst.Fields(0).Value Then
    '            indexSeleccion = index
    '        End If

    '        If idSel1 = rst.Fields(0).Value Then
    '            indexSeleccion1 = index1
    '        End If

    '        rst.MoveNext()
    '        index = index + 1
    '        index1 = index1 + 1
    '    End While
    '    If cLista.Items.Count > 0 Then
    '        cLista.SelectedIndex = indexSeleccion
    '    Else
    '        cLista.SelectedIndex = -1
    '    End If

    '    If cLista1.Items.Count > 0 Then
    '        cLista1.SelectedIndex = indexSeleccion1
    '    Else
    '        cLista1.SelectedIndex = -1
    '    End If

    '    ControlError = 1
    'Catch ex As Exception
    '    MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
    '    ControlError = 0
    'End Try
    'Return ControlError
    'End Function
    'Modificado 29/08/2009 - Datahelper 
    Public Function LlenarComboIDs2(ByVal dt As DataTable, ByRef cLista As ComboBox, ByRef id As Collection, ByRef idSel As Integer, ByRef cLista1 As ComboBox, ByRef id1 As Collection, ByRef idSel1 As Integer) As Integer
        Try
            Dim index, index1 As Integer
            Dim indexSeleccion, indexSeleccion1 As Integer
            index = 0
            indexSeleccion = 0
            index1 = 0
            indexSeleccion1 = 0

            cLista.DropDownStyle = ComboBoxStyle.DropDownList
            cLista.Controls.Clear()
            cLista.Items.Clear()
            id = Nothing
            id = New Collection()

            cLista1.DropDownStyle = ComboBoxStyle.DropDownList
            cLista1.Controls.Clear()
            cLista1.Items.Clear()
            id1 = Nothing
            id1 = New Collection()
            '
            For Each row As DataRow In dt.Rows
                '
                cLista.Items.Insert(index, row.Item(1))
                cLista1.Items.Insert(index1, row.Item(1))
                id.Add(row.Item(0), index.ToString())
                id1.Add(row.Item(0), index.ToString())
                If idSel = row.Item(0) Then
                    indexSeleccion = index
                End If
                If idSel1 = row.Item(0) Then
                    indexSeleccion1 = index1
                End If
                index = index + 1
                index1 = index1 + 1
            Next
            If cLista.Items.Count > 0 Then
                cLista.SelectedIndex = indexSeleccion
            Else
                cLista.SelectedIndex = -1
            End If
            '
            If cLista1.Items.Count > 0 Then
                cLista1.SelectedIndex = indexSeleccion1
            Else
                cLista1.SelectedIndex = -1
            End If
            '
            ControlError = 1
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistemas")
            ControlError = 0
        End Try
        Return ControlError
    End Function
    Public Function ValidarEXP_REG_IP(ByVal txtIP As String) As Boolean
        Try
            Dim re As System.Text.RegularExpressions.Regex
            re = New System.Text.RegularExpressions.Regex(IP)
            'Regex rx = new Regex(@"^-?\d+(\.\d{2})?$");
            If re.IsMatch(txtIP.ToString()) Then
                ValidarEXP_REG_IP = True
            Else
                ValidarEXP_REG_IP = False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
    End Function
    Public Sub Formato_GridView(ByVal dtGridView As DataGridView)
        With dtGridView
            '    .AllowUserToAddRows = False
            '    .AllowUserToDeleteRows = False
            '    .AllowUserToOrderColumns = True
            .BackgroundColor = SystemColors.Window
            .Font = New System.Drawing.Font("Tahoma", 8.0!, FontStyle.Bold)
            .ReadOnly = True
            '    .AutoGenerateColumns = False
            '    '.DataSource = dtable_Lista_Control_Comprobante
            '    .VirtualMode = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .RowHeadersWidth = 10
            .ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#507EF2")
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 8, FontStyle.Bold)
            .AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        End With
    End Sub
    Public Function RellenoRight(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = "0" & sNewCadena
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function
    Public Function RellenoLeft(ByVal Nro As Integer, ByVal texto As String) As String
        Dim cCount As Integer = Len(texto)
        Dim sNewCadena As String = texto
        If Nro = cCount Then
            Return texto
        End If
        Try
            Dim i As Integer
            For i = 1 To Nro - cCount
                sNewCadena = sNewCadena & "0"
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return sNewCadena
    End Function
    Public Function fnDigito_Chequeo(ByVal strNroGuia As String) As Boolean
        Dim flag As Boolean = False
        Try
            Dim iCantidad As Integer = LTrim(strNroGuia).Length
            Dim control As Integer = 0
            Dim val As Integer = 0
            Dim i As Integer = 0

            If iCantidad > 0 Then
                For i = 1 To iCantidad - 1
                    val = Int(strNroGuia(iCantidad - i - 1).ToString)
                    control = control + 3 * val
                    i = i + 1
                    If iCantidad - i - 1 >= 0 Then
                        val = Int(strNroGuia(iCantidad - i - 1).ToString)
                        control = control + val
                    End If

                Next
                If Int(control) Mod 10 = 0 And Int(strNroGuia(iCantidad - 1).ToString) = 0 Then
                    flag = True
                    GoTo FINAL
                Else
                    If Int(Int(control) + Int(strNroGuia(iCantidad - 1).ToString)) Mod 10 = 0 Then
                        flag = True
                        GoTo FINAL
                    End If
                End If
            End If
FINAL:
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return flag
    End Function
    Public Function fnGeneraDigitoChequeo(ByVal strNroGuia As String) As String
        Dim v_str As String = ""
        Dim v_strGuia As String = strNroGuia
        Try
            strNroGuia = strNroGuia & "0"
            Dim iCantidad As Integer = LTrim(strNroGuia).Length
            Dim control As Integer = 0
            Dim val As Integer = 0
            Dim i As Integer = 0

            If iCantidad > 0 Then
                For i = 1 To iCantidad - 1
                    val = Int(strNroGuia(iCantidad - i - 1).ToString)
                    control = control + 3 * val
                    i = i + 1
                    If iCantidad - i - 1 >= 0 Then
                        val = Int(strNroGuia(iCantidad - i - 1).ToString)
                        control = control + val
                    End If
                Next
            End If

            If Int(control) Mod 10 = 0 Then
                v_str = v_strGuia & "0"
                GoTo FINAL
            Else
                Dim Digito As Integer = ((Int(control / 10)) + 1) * 10 - control
                v_str = v_strGuia & Digito
                GoTo FINAL
            End If
        Catch ex As Exception

        End Try
FINAL:
        Return v_str
    End Function
    Public Function fnLoagObj(ByVal obj As Object()) As String
        Dim var_str As String = "@"
        Try
            Dim i As Integer = 0
            Dim n As Integer = obj.Length
            For i = 0 To n - 1
                If i = 0 Then
                    var_str = obj(i).ToString()
                Else
                    var_str = var_str & "," & obj(i).ToString()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
            var_str = "ERROR"
        End Try
        Return var_str
    End Function
    Public Function fnValidarRUC(ByVal strRUC As String) As Boolean
        If strRUC.Trim.Length <> 11 Then
            Return False
        End If
        If Not (strRUC.Trim.Substring(0, 1) = "1" Or strRUC.Trim.Substring(0, 1) = "2") Then
            Return False
        End If

        Dim ret As Boolean = False
        Try
            Dim nDig, nd0, nd1, nd2, nd3, nd4, nd5, nd6, nd7, nd8, nd9, nRUC, nRes As Integer
            Dim strRes As String
            nDig = Int(strRUC.Substring(strRUC.Length - 1).ToString)
            nd0 = Int(strRUC.Substring(0, 1).ToString()) * 5
            nd1 = Int(strRUC.Substring(1, 1).ToString()) * 4
            nd2 = Int(strRUC.Substring(2, 1).ToString()) * 3
            nd3 = Int(strRUC.Substring(3, 1).ToString()) * 2
            nd4 = Int(strRUC.Substring(4, 1).ToString()) * 7
            nd5 = Int(strRUC.Substring(5, 1).ToString()) * 6
            nd6 = Int(strRUC.Substring(6, 1).ToString()) * 5
            nd7 = Int(strRUC.Substring(7, 1).ToString()) * 4
            nd8 = Int(strRUC.Substring(8, 1).ToString()) * 3
            nd9 = Int(strRUC.Substring(9, 1).ToString()) * 2
            nRUC = nd0 + nd1 + nd2 + nd3 + nd4 + nd5 + nd6 + nd7 + nd8 + nd9
            nRes = nRUC Mod 11
            strRes = Int(nRes.ToString)
            nRes = 11 - Int(strRes.Substring(strRes.Length - 1).ToString)
            strRes = Int(nRes)
            If nDig = Int(strRes.Substring(strRes.Length - 1).ToString) Then
                ret = True
            End If
        Catch ex As Exception
            ret = False
        End Try
        Return ret
    End Function
    'Public Function fnGetHora_2009() As String
    '    Try
    '        Dim SQLQuery As Object() = {"select to_char(sysdate,'HH:Mi AM') hora from dual", 2}            
    '        Dim rstHoras = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstHoras.State = 1 Then
    '            If rstHoras.BOF = False And rstHoras.EOF = False Then
    '                HoraImpresion = rstHoras.Fields.Item("hora").Value.ToString
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        HoraImpresion = Now
    '    End Try
    '    Return HoraImpresion
    'End Function

    Public Function fnGetHora() As String
        Dim db_bd As New BaseDatos
        Try
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select PKG_GENERICO.sf_get_hora_servidor from  dual"
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            ' No tiens 
            'Variables de salidas 
            'No existe parametros de salida 
            HoraImpresion = CType(db_bd.EjecutarEscalar(), String)
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return HoraImpresion
    End Function
    'Public Function fnGetHora__2009() As String
    '    Try
    '        Dim SQLQuery As Object() = {"select to_char(sysdate,'dd/mm/yyyy HH:Mi:ss AM') hora from dual", 2}
    '        Dim rstHoras = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstHoras.State = 1 Then
    '            If rstHoras.BOF = False And rstHoras.EOF = False Then
    '                HoraImpresion = rstHoras.Fields.Item("hora").Value.ToString
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        HoraImpresion = Now
    '    End Try
    '    Return HoraImpresion
    'End Function
    Public Function fnGetHora_() As String
        Dim db_bd As New BaseDatos
        Try
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select PKG_GENERICO.sf_get_dia_hora_seg_servidor from  dual"
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            ' No tiens 
            'Variables de salidas 
            'No existe parametros de salida 
            HoraImpresion = db_bd.EjecutarEscalar()
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return HoraImpresion
    End Function
    'Public Function fnGetHOST_SERVIDOR_2009() As String
    '    Try
    '        'Dim SQLQuery As Object() = {"SELECT distinct coalesce(s.MACHINE,'OTRO USUARIO')  MACHINE  FROM   v$session s where s.osuser='oracle' OR s.osuser='titan'", 2}

    '        Dim SQLQuery As Object() = {"SELECT DISTINCT coalesce(SERVICE_NAME,'OTRO USUARIO') MACHINE FROM   v$session WHERE USERNAME = 'TITAN'", 2}
    '        Dim rstServer = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstServer.State = 1 Then
    '            If rstServer.BOF = False And rstServer.EOF = False Then
    '                NombreServidor = rstServer.Fields.Item("MACHINE").Value.ToString
    '                rptservice = "tepsa" 'NombreServidor
    '            Else
    '                NombreServidor = "SERVIDOR DE PRUEBA"
    '                rptservice = "tepsa" '"titan"
    '            End If
    '        End If
    '        ' Cadena Conexión, para los reportes 
    '        '
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '        NombreServidor = "NO HAY SERVIDOR"
    '    End Try
    '    Return NombreServidor
    'End Function
    Public Function fnGetHOST_SERVIDOR() As String
        NombreServidor = "NO HAY SERVIDOR"
        Dim db_bd As New BaseDatos
        Try
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select PKG_GENERICO.sf_get_nombre_servidor from  dual"
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando(ls_sql, CommandType.Text)
            NombreServidor = db_bd.EjecutarEscalar()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return NombreServidor
    End Function
    Public Function fnNumeroDecimal(ByVal nro As String) As Double
        Dim NroVar As String = ""
        Try
            Dim numeric() As String = Split(nro, ".")
            If numeric.Length > 1 Then
                Dim Entero() As String = Split(numeric(0), ",")
                Dim i As Integer = 0
                For i = 0 To Entero.Length - 1
                    NroVar = NroVar & Entero(i)
                Next
                NroVar = NroVar & "." & numeric(1)
            End If
        Catch ex As Exception
        End Try
        Return Val(NroVar)
    End Function
    'Public Function fnGetCiudad_2009(ByVal idCiudad As String) As String
    '    Dim ciudad As String = "NINGUNO"
    '    Try
    '        Dim SQLQuery As Object() = {"  select t_Unidad_Agencia.Nombre_Unidad from t_Unidad_Agencia where t_Unidad_Agencia.Idunidad_Agencia= " & idCiudad, 2}
    '        Dim rstServer = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstServer.State = 1 Then
    '            If rstServer.BOF = False And rstServer.EOF = False Then
    '                ciudad = rstServer.Fields.Item("Nombre_Unidad").Value.ToString

    '            Else
    '                ciudad = "NINGUNO"
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Return ciudad
    'End Function
    Public Function fnGetCiudad(ByVal idCiudad As String) As String
        Dim ciudad As String = "NINGUNO"
        Dim db_bd As New BaseDatos
        Try
            '
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select sf_get_ciudad(" & idCiudad & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            '
            ciudad = CType(db_bd.EjecutarEscalar, String)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return ciudad
    End Function
    'Public Function fnGetAGENCIA_2009(ByVal idAgencia As String) As String
    '    Dim Agencia As String = "NINGUNO"
    '    Try ' Modificado 01/02/2008 
    '        Dim SQLQuery As Object() = {" select t_agencias.nombre_agencia from t_agencias where t_agencias.idagencias= " & idAgencia, 2}
    '        Dim rstServer = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstServer.State = 1 Then
    '            If rstServer.BOF = False And rstServer.EOF = False Then
    '                Agencia = rstServer.Fields.Item("nombre_agencia").Value.ToString
    '            Else
    '                Agencia = "NINGUNO"
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Return Agencia
    'End Function
    Public Function fnGetAGENCIA(ByVal idAgencia As String) As String
        Dim Agencia As String = "NINGUNO"
        Dim db_bd As New BaseDatos
        Try
            '
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select sf_get_agencia(" & idAgencia & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            '
            Agencia = db_bd.EjecutarEscalar
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try

        Return Agencia
    End Function
    '01/02/2008 - Recupera si es terminal  
    'Public Function fnGetAGENCIA_esterminal_2009(ByVal idAgencia As String) As Long
    '    Dim esterminal As Long
    '    Try ' Modificado 01/02/2008 - Se le ha puesto es terminal 
    '        Dim SQLQuery As Object() = {"select t_agencias.es_terminal from t_agencias where t_agencias.idagencias= " & idAgencia, 2}
    '        Dim rstServer = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstServer.State = 1 Then
    '            If rstServer.BOF = False And rstServer.EOF = False Then
    '                If IsDBNull(rstServer.Fields.Item("es_terminal").Value) = True Then
    '                    esterminal = 0
    '                Else
    '                    esterminal = CType(rstServer.Fields.Item("es_terminal").Value, Long)
    '                End If
    '            Else
    '                esterminal = 0
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Return esterminal
    'End Function
    Public Function fnGetAGENCIA_esterminal(ByVal idAgencia As String) As Long
        Dim esterminal As Long = 0
        Dim db_bd As New BaseDatos
        Try
            '
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select sf_get_es_terminal_agencia(" & idAgencia & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            '
            esterminal = CType(db_bd.EjecutarEscalar, Long)
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return esterminal
    End Function
    Public Function ConvercionNroEnLetras(ByVal curNumero As Double, Optional opcion As Integer = 1) As String
        Try
            Dim strMoneda As String = IIf(opcion = 1, "SOLES", "DOLARES AMERICANOS")
            Dim str As String() = Split(curNumero.ToString, ".")
            Dim ForMatoDeciaml As String = " " & strMoneda
            If str.Length = 1 Then
                ForMatoDeciaml = " CON 00/100 " & strMoneda
            ElseIf str.Length = 2 Then
                If Int(str(1)) = 0 Then
                    ForMatoDeciaml = " CON 00/100 " & strMoneda
                End If
            End If
            ConvercionNroEnLetras = NroEnLetras(curNumero) & ForMatoDeciaml
        Catch ex As Exception
            '
            ConvercionNroEnLetras = ""
        End Try
    End Function
    'Public Function fnSeleccionImpresion_2009() As Integer
    '    Dim Impresora As Integer = 1
    '    Try
    '        Dim SQLQuery As Object() = {"PKG_UTILITARIOS.SP_LOAD_IMPRESION", 4, dtoUSUARIOS.IP, 2}
    '        Dim rstImpresora As New ADODB.Recordset
    '        rstImpresora = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rstImpresora.State = 1 Then
    '            If rstImpresora.BOF = False And rstImpresora.EOF = False Then
    '                Impresora = rstImpresora.Fields.Item("IMPRESION").Value
    '                NOMBRE_IMPRESORA = rstImpresora.Fields.Item("Control_Impresoras").Value
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Return Impresora
    'End Function
    Public Function fnSeleccionImpresion() As Integer
        Dim Impresora As Integer = 1
        Dim ldt_tmp As DataTable
        Try
            '
            Dim ls_sql As String
            Dim db_bd As New BaseDatos
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("PKG_UTILITARIOS.SP_LOAD_IMPRESION", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("iIP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable
            ' 
            If ldt_tmp.Rows.Count > 0 Then
                Impresora = ldt_tmp.Rows(0).Item("IMPRESION")
                NOMBRE_IMPRESORA = ldt_tmp.Rows(0).Item("Control_Impresoras")
            Else
                Impresora = 0
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return Impresora
        '
    End Function
    Public Function fnEXCELGrid(ByVal dGridView As DataGridView) As Boolean
        Try
            Dim xlApp As New Excel.Application()
            Dim xlBook As Excel.Workbook
            Dim xlSheet As Excel.Worksheet
            Dim rowIndex, colIndex, i, j As Integer
            rowIndex = 1
            colIndex = 0
            xlBook = xlApp.Workbooks().Add
            xlSheet = xlBook.Worksheets("hoja1")
            '  Dim cVisibles As Integer = 0

            'For i = 0 To dGridView.Columns().Count - 1

            '    If dGridView.Columns().Item(i).Visible = True Then
            '        cVisibles = cVisibles + 1
            '    End If
            'Next

            For i = 0 To dGridView.Columns().Count - 1
                If dGridView.Columns().Item(i).Visible = True Then
                    colIndex = colIndex + 1
                    xlApp.Cells(1, colIndex) = dGridView.Columns().Item(i).DataPropertyName

                End If
            Next
            For i = 0 To dGridView.Rows().Count - 1
                rowIndex = rowIndex + 1
                colIndex = 0
                For j = 0 To dGridView.Columns().Count - 1

                    If dGridView.Columns().Item(j).Visible = True Then
                        colIndex = colIndex + 1
                        xlApp.Cells(rowIndex, colIndex) = dGridView.Rows(i).Cells(j).Value
                    End If

                Next
            Next
            With xlSheet
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Name = "Template"
                .Range(.Cells(1, 1), .Cells(1, colIndex)).Font.Bold = True
                .Range(.Cells(1, 1), .Cells(rowIndex, colIndex)).Borders.LineStyle = 1
            End With
            xlApp.Visible = True

        Catch ex As Exception
            MsgBox("Verifique sus Datos..", MsgBoxStyle.Information, "Seguridad Sistema")
        End Try
        Return False
    End Function
    'Public Function fnSP_CONTROL_PCE_2009(ByVal idTIPO_DOC As Integer, ByVal idCOMPROBANTE As String) As Integer
    '    Dim IDCONTROL As Integer = 0
    '    Try
    '        Dim SQLQuery As Object() = {"AA_TEST.SP_CONTROL_PCE", 6, idTIPO_DOC, 1, idCOMPROBANTE, 2}
    '        Dim rst_cur_datos As New ADODB.Recordset
    '        rst_cur_datos = VOCONTROLUSUARIO.fnSQLQuery(SQLQuery)
    '        If rst_cur_datos.State = 1 Then
    '            If rst_cur_datos.BOF = False And rst_cur_datos.EOF = False Then
    '                If rst_cur_datos.Fields.Item("IDMSGBOX").Value = 1 Then
    '                    IDCONTROL = 1
    '                Else
    '                    MsgBox(rst_cur_datos.Fields.Item("V_MSGBOX").Value, MsgBoxStyle.Information, "Seguridad Sistema")
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    Return IDCONTROL
    'End Function
    Public Function fnSP_CONTROL_PCE(ByVal idTIPO_DOC As Integer, ByVal idCOMPROBANTE As String) As Integer
        Dim IDCONTROL As Integer = 0
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            db_bd.CrearComando("AA_TEST.SP_CONTROL_PCE", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            db_bd.AsignarParametro("v_idTipo_Comprobante", idTIPO_DOC, OracleClient.OracleType.Int16)
            db_bd.AsignarParametro("v_idComprobante", idCOMPROBANTE, OracleClient.OracleType.VarChar)
            'Variables de salidas 
            db_bd.AsignarParametro("cur_datos", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            ldt_tmp = db_bd.EjecutarDataTable
            '
            If ldt_tmp.Rows.Count > 0 Then
                If ldt_tmp.Rows(0).Item("IDMSGBOX") = 1 Then
                    IDCONTROL = 1
                Else
                    MsgBox(ldt_tmp.Rows(0).Item("V_MSGBOX"), MsgBoxStyle.Information, "Seguridad Sistema")
                End If
            End If
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
        Return IDCONTROL
    End Function
    Public Function ConvercionNroEnLetrasDolares(ByVal curNumero As Double) As String
        Try
            Dim str As String() = Split(curNumero.ToString, ".")
            Dim ForMatoDeciaml As String = " DOLARES AMERICANOS"
            If str.Length = 1 Then
                ForMatoDeciaml = " CON 00/100 DOLARES AMERICANOS"
            ElseIf str.Length = 2 Then
                If Int(str(1)) = 0 Then
                    ForMatoDeciaml = " CON 00/100 DOLARES AMERICANOS"
                End If
            End If
            ConvercionNroEnLetrasDolares = NroEnLetras(curNumero) & ForMatoDeciaml
        Catch ex As Exception
            '
            ConvercionNroEnLetrasDolares = ""
        End Try
    End Function
    Public Function convertADODB2009(ByRef table As DataTable) As ADODB.Recordset
        'Dim result As New ADODB.Recordset

        'result.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'Dim resultfields As ADODB.Fields = result.Fields
        'Dim col As DataColumn
        ''
        'For Each col In table.Columns
        '    resultfields.Append(col.ColumnName, TranslateType(col.DataType), col.MaxLength, col.AllowDBNull = ADODB.FieldAttributeEnum.adFldIsNullable)
        'Next
        'result.Open(System.Reflection.Missing.Value, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, 0)
        'For Each row As DataRow In table.Rows
        '    result.AddNew(System.Reflection.Missing.Value, System.Reflection.Missing.Value)
        '    For i As Integer = 0 To table.Columns.Count
        '        resultfields(i).Value = row(i)
        '    Next
        'Next
        'Return result
    End Function
    Public Function TranslateType(ByRef type As Type) As ADODB.DataTypeEnum
        Try
            Select Case type.UnderlyingSystemType.ToString
                Case "System.Boolean"
                    Return ADODB.DataTypeEnum.adBoolean
                Case "System.Byte"
                    Return ADODB.DataTypeEnum.adUnsignedBigInt
                Case "System.Char"
                    Return ADODB.DataTypeEnum.adChar
                Case "System.DateTime"
                    Return ADODB.DataTypeEnum.adDate
                Case "System.Decimal"
                    Return ADODB.DataTypeEnum.adCurrency
                Case "System.Double"
                    Return ADODB.DataTypeEnum.adDouble
                Case "System.Int16"
                    Return ADODB.DataTypeEnum.adSmallInt
                Case "System.Int32"
                    Return ADODB.DataTypeEnum.adInteger
                Case "System.Int64"
                    Return ADODB.DataTypeEnum.adBigInt
                Case "System.SByte"
                    Return ADODB.DataTypeEnum.adTinyInt
                Case "System.UInt16"
                    Return ADODB.DataTypeEnum.adUnsignedSmallInt
                Case "System.UInt32"
                    Return ADODB.DataTypeEnum.adUnsignedInt
                Case "System.UInt64"
                    Return ADODB.DataTypeEnum.adUnsignedBigInt
                Case "System.String"
                    Return ADODB.DataTypeEnum.adVarWChar
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '
    End Function
    'Modificado por Hlamas - Para el control del datahelper
    Public Function LlenarTreeListViewCtrl(ByVal rst As DataTable, ByRef cTree As TreeView, ByRef Cabecera As String) As Integer
        Try
            cTree.Nodes.Clear()
            cTree.Nodes.Add(Cabecera)
            Dim i, j As Integer
            i = 0 : j = 0
            Dim tmp As String
            tmp = "xxx"
            If rst.Rows.Count > 0 Then
                Dim n, nn As TreeNode
                For Each obj As DataRow In rst.Rows
                    If tmp <> obj.Item(1).ToString Then
                        n = cTree.Nodes(0).Nodes.Add(obj.Item(1).ToString)
                        cTree.Nodes(0).Nodes(i).Tag = obj.Item(0).ToString
                        tmp = obj.Item(1).ToString
                        i = i + 1
                        j = 0
                    Else
                        nn = n.Nodes.Add(obj.Item(3).ToString)
                        Dim dt As DataTable
                        j = j + 1
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function LlenarCombo2(ByVal rst As DataTable, ByRef cLista As ComboBox, ByRef id As Collection, ByRef idSel As Integer) As Integer
        Try
            Dim index As Integer
            Dim indexSeleccion As Integer
            index = 0
            indexSeleccion = 0
            cLista.DropDownStyle = ComboBoxStyle.DropDownList
            cLista.Controls.Clear()
            cLista.Items.Clear()
            id = Nothing
            id = New Collection()
            '
            If rst.Rows.Count > 0 Then
                For Each row As DataRow In rst.Rows
                    cLista.Items.Insert(index, row.Item(1).ToString)
                    id.Add(row.Item(0).ToString, index.ToString)
                    If idSel = row.Item(0).ToString Then
                        indexSeleccion = index
                    End If
                    index = index + 1
                Next
            End If
            If cLista.Items.Count > 0 Then
                cLista.SelectedIndex = indexSeleccion
            Else
                cLista.SelectedIndex = -1
            End If
            ControlError = 1
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return ControlError
    End Function
    Public Function CargarDataGrid(ByVal rst As DataTable, ByVal grid As DataGridView, ByVal nCol As Integer) As Boolean
        Try
            LimpiarGrid(grid)
            For Each obj As DataRow In rst.Rows
                Dim dto() As Object = {obj.Item(0).ToString, obj.Item(1).ToString}
                grid.Rows().Add(dto)
            Next
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#E5FFE5")
        Catch ex As Exception
            MsgBox(ex.ToString(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
        Return True
    End Function
    Public Function LlenarTreeCtrl(ByVal dt As DataTable, ByRef cTree As TreeView, ByRef Cabecera As String) As Integer
        Try
            cTree.Nodes.Clear()
            cTree.CheckBoxes = True
            cTree.Nodes.Add(Cabecera)
            Dim i, j As Integer
            Dim imageListSmall As New ImageList()
            Dim imageListLarge As New ImageList()

            i = 0
            j = 0
            Dim tmp As String
            tmp = "xxx"
            If dt.Rows.Count > 0 Then
                For Each obj As DataRow In dt.Rows
                    If tmp <> obj.Item(1) Then
                        cTree.Nodes(0).Nodes.Add(obj.Item(1))
                        cTree.Nodes(0).Nodes(i).Tag = obj.Item(0)
                        tmp = obj.Item(1)
                        i = i + 1
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
        Return 1
    End Function

    Public Function LlenarTreeCtrl(ByVal dt As DataTable, ByRef cTree As TreeView, ByRef Cabecera As String, ByVal check As Boolean) As Integer
        Try
            cTree.Nodes.Clear()
            cTree.CheckBoxes = check
            cTree.Nodes.Add(Cabecera)
            Dim i, j As Integer
            Dim imageListSmall As New ImageList()
            Dim imageListLarge As New ImageList()

            i = 0
            j = 0
            Dim tmp As String
            tmp = "xxx"
            If dt.Rows.Count > 0 Then
                For Each obj As DataRow In dt.Rows
                    If tmp <> obj.Item(1) Then
                        cTree.Nodes(0).Nodes.Add(obj.Item(1))
                        cTree.Nodes(0).Nodes(i).Tag = obj.Item(0)
                        tmp = obj.Item(1)
                        i = i + 1
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message(), MsgBoxStyle.Critical, "Seguridad Sistema")
        End Try
        Return 1
    End Function

    Public Function Replicate(ByVal str As String, ByVal Times As Int32) As String
        Replicate = String.Empty
        For i As Integer = 1 To Times
            Replicate += str
        Next
    End Function

    Public Function DevuelveGuiones(ByVal str As String) As Integer
        Dim cad As String = str
        Dim iGuiones As Integer = 0
        Dim iPosicion As Integer = 0
        Dim bExisteGuion As Boolean = True
        Dim bNumero As Boolean

        Try
            Do While bExisteGuion
                iPosicion = InStr(cad, "-")

                'If IsNumeric(Mid(cad, iPosicion + 1, 1)) Then
                'bNumero = True
                'Else
                'bNumero = False
                'End If

                If iPosicion <= 0 Then
                    bExisteGuion = False
                Else
                    'If bNumero Then
                    iGuiones += 1
                    'End If
                    cad = Mid(cad, iPosicion + 1)
                End If
            Loop
            Return iGuiones
        Catch
            Return iGuiones
        End Try
    End Function
    '02/09/2010 - Recupera el id de la ciudad (idunidad_agencia) a partir del id agencia
    Public Function fnGet_idCiudad(ByVal idAgencia As String) As Long
        '
        Dim id_ciudad As Long = 0
        '
        Dim db_bd As New BaseDatos
        '
        Try
            '
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select sf_get_idciudad(" & idAgencia & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            '
            id_ciudad = CType(db_bd.EjecutarEscalar, Long)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return id_ciudad
        '
    End Function

    Function NumeroRegistro(ByVal dgv As DataGridView) As Integer
        Return dgv.Rows.Count
    End Function

    Function Centrar(ByVal s As String, ByVal a As Integer) As Integer
        Return (a - s.Trim.Length) / 2
    End Function

    Function Derecha(ByVal s As String, ByVal a As Integer) As Integer
        Return a - s.Trim.Length
    End Function

    Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.-]" Then
            If Not Asc(e.KeyChar) = Keys.Back Then
                Return True
            End If
        End If

        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
    Sub CargarCondicionPago(ByVal cbo As ComboBox)
        Try
            Dim obj As New dtoCLIENTES
            Dim dt As DataTable = obj.CondicionPago
            CargarCombo(cbo, dt, "condicion", "idcondicion_plazo", -1)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Titán", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LlenarTreeView_3(ByVal MyDataTableA As System.Data.DataTable, ByVal ColumnaA As Integer, ByVal cTree As TreeView, ByVal NombreNodoSuperior As String, ByVal check As Boolean, ByVal expandido As Boolean)
        Try
            cTree.Nodes.Clear()
            If check Then
                cTree.CheckBoxes = True
            End If
            'Llenamos los Nodos Primarios
            cTree.Nodes.Add(NombreNodoSuperior)
            For i As Integer = 0 To MyDataTableA.Rows.Count - 1
                cTree.Nodes(0).Nodes.Add(MyDataTableA.Rows(i)(ColumnaA).ToString)
                cTree.Nodes(0).Nodes(i).Tag = MyDataTableA.Rows(i)("ID").ToString 'Tepsa 
                cTree.Nodes(0).Nodes(i).NodeFont = New Font("Arial", 8, FontStyle.Regular)
            Next
            If expandido Then
                cTree.ExpandAll()
            End If
        Catch Qex As Exception
            MessageBox.Show(Qex.Message, "Seguridad del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GenerarDataGridVolumetrico(ByVal grid As DataGridView, ByVal fila As Integer, _
                                       ByVal UltimaFila As Integer, ByVal tarifa_Peso As Double, ByVal Key As Integer)
        Try
            If Key = Keys.Down And IsNumeric(grid("tipo", fila).Value) Then   'hlamas 28-11-2013 Then
                If grid.Rows.Count > 0 Then
                    If Val(grid("Sub Neto", fila).Value) = 0 Then
                        If Val(grid("Sub Neto", UltimaFila).Value) = 0 Then Exit Sub
                        grid.Rows.Remove(grid.CurrentRow)
                    Else
                        If Val(grid("Sub Neto", UltimaFila).Value) = 0 Then Exit Sub
                        '***agregando un nuevo registro desde la ultima fila******
                        If fila = UltimaFila Then
                            Dim row0 As String() = {fila + 2, "", "0.00", "0.00", "0.00", "0.00", Format(tarifa_Peso, "0.00"), "0.00"}
                            grid.Rows().Add(row0)
                        End If
                    End If
                End If
            ElseIf Key = Keys.Up Then
                If UltimaFila = 0 Then Exit Sub
                If Val(grid("Sub Neto", UltimaFila).Value) = 0 And IsNumeric(grid("tipo", UltimaFila).Value) Then   'hlamas 28-11-2013 Then
                    Dim iCol As Integer = grid.CurrentCell.ColumnIndex
                    grid.Rows.RemoveAt(UltimaFila)
                    grid.CurrentCell = grid(iCol, UltimaFila - 1) 'grid.CurrentRow.Cells(fila)
                    If UltimaFila - 1 > 0 Then
                        SendKeys.Send("{DOWN}")
                    End If
                End If
            ElseIf Key = Keys.Delete And IsNumeric(grid("tipo", fila).Value) Then   'hlamas 28-11-2013
                'If grid.Rows.Count - 1 >= 2 Then
                '    grid.Rows.RemoveAt(fila)
                'ElseIf grid.Rows.Count - 1 > 0 And grid.Rows.Count - 1 < 2 Then
                '    If IsNumeric(grid("tipo", 0).Value) And IsNumeric(grid("tipo", 1).Value) Then
                '        grid.Rows.RemoveAt(fila)
                '    End If
                'End If
                If grid.Rows.Count > 0 Then
                    Dim intCuenta As Integer = 0
                    For Each row As DataGridViewRow In grid.Rows
                        If IsNumeric(row.Cells("tipo").Value) Then
                            intCuenta += 1
                        End If
                    Next
                    If intCuenta > 1 Then
                        grid.Rows.RemoveAt(fila)
                    End If
                End If
                'Reseteando la numeracion
                For i As Integer = fila To grid.Rows.Count - 1
                    If IsNumeric(grid("tipo", i).Value) Then
                        grid("Tipo", i).Value = i.ToString + 1
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Function ObtieneTipoDocumento(ByVal tipo As Integer)
        Dim valor As Integer
        Select Case tipo
            Case 1
                valor = 9
                'Case 2
                '    valor = 3
                'Case 3
                '    valor = 2
                'Case 4
                '    valor = 99
                'Case 5
                '    valor = 5
                'Case 6
                '    valor = 22
            Case 8
                valor = 1
                'Case 9
                'valor = 22
            Case Else
                valor = 3
        End Select
        Return valor
    End Function

    '17-10-2011
    Function ExisteValorGrid(ByVal dgv As DataGridView, ByVal columna As Integer, ByVal valor As String) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(columna).Value = valor Then 'row.Cells("estado").Value < 2 AndAlso row.Cells(columna).Value = valor Then
                Return True
            End If
        Next
        Return False
    End Function

    Function ValorGrid(ByVal dgv As DataGridView, ByVal columna As String, ByVal valor As String) As Integer
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(columna).Value = valor Then
                Return row.Index
            End If
        Next
        Return -1
    End Function

    Function SumaGrid(ByVal dgv As DataGridView, ByVal columna As String) As Integer
        Dim dblSuma As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsDBNull(row.Cells(columna).Value) Then
                dblSuma += row.Cells(columna).Value
            End If
        Next
        Return dblSuma
    End Function

    Function SumaGrid2(ByVal dgv As DataGridView, ByVal columna As String) As Double
        Dim dblSuma As Double = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsDBNull(row.Cells(columna).Value) Then
                dblSuma += row.Cells(columna).Value
            End If
        Next
        Return dblSuma
    End Function

    Function SumaHoras(ByVal dgv As DataGridView, ByVal columna As String) As String
        Dim fecha As Date
        Dim intHoras As Integer, intMinutos As Integer
        intHoras = 0
        intMinutos = 0
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsDBNull(row.Cells(columna).Value) And Not IsNothing(row.Cells(columna).Value) Then
                If row.Cells(columna).Value.ToString.Trim.Length > 0 Then
                    intHoras += CType(row.Cells(columna).Value.ToString.Substring(0, 2), Integer)
                    intMinutos += CType(row.Cells(columna).Value.ToString.Substring(3, 2), Integer)
                End If
            End If
        Next
        If intMinutos >= 60 Then
            Do While intMinutos >= 60
                intMinutos = intMinutos - 60
                intHoras = intHoras + 1
            Loop
        End If
        Return Format(intHoras, "00") & ":" & Format(intMinutos, "00")
    End Function

    Function SumaHoras(ByVal dt As DataTable, ByVal columna As String) As String
        Dim fecha As Date
        Dim intHoras As Integer, intMinutos As Integer
        intHoras = 0
        intMinutos = 0
        For Each row As DataRow In dt.Rows
            If Not IsDBNull(row.Item(columna)) And Not IsNothing(row.Item(columna)) Then
                If row.Item(columna).ToString.Trim <> "00:00" Then
                    intHoras += CType(row.Item(columna).ToString.Substring(0, 2), Integer)
                    intMinutos += CType(row.Item(columna).ToString.Substring(3, 2), Integer)
                End If
            End If
        Next
        If intMinutos >= 60 Then
            Do While intMinutos >= 60
                intMinutos = intMinutos - 60
                intHoras = intHoras + 1
            Loop
        End If
        Return Format(intHoras, "00") & ":" & Format(intMinutos, "00")
    End Function

    Sub EliminarCaracter(ByRef cadena As String, ByVal posicion As Integer)
        Try
            cadena = cadena.Substring(0, posicion - 1)
        Catch ex As Exception
        End Try
    End Sub

    'Agregado Liquidacion Oficina
    Public Function fnGet_OFICINAVENTA(ByVal idAgencia As Integer) As Integer
        Dim iOficinaVenta As String = "NINGUNO"
        Dim db_bd As New BaseDatos
        Try
            Dim ls_sql As String
            ls_sql = "select sf_get_OFICINAVENTA(" & idAgencia & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            iOficinaVenta = db_bd.EjecutarEscalar
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try
        Return iOficinaVenta
    End Function

    Sub ActualizaVersionIP(ip As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOUUTILS.sp_actualiza_version", CommandType.StoredProcedure)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable()
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0).Item(0)) Then
                    If dt.Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(dt.Rows(0).Item(1))
                    End If
                End If
            End If
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Sub

    Function TieneCargo(dgv As DataGridView, columna As Integer) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If Not IsNothing(row.Cells(columna).Value) Then
                If row.Cells(columna).Value.ToString.Trim.Length >= 1 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function

    Function RedondearMas(numero As Double) As Double
        Dim dblNumero As Double
        dblNumero = Math.Ceiling(numero)
        Return dblNumero
    End Function

    Function RedondearMas(ByVal Numero As Double, ByVal Decimales As Integer) As Double
        Dim a As Double, b As Double, c As Double, z As Integer, s As String
        a = Math.Round(Numero, 2)
        b = Int(Numero)
        c = Math.Round(a - b, 2)
        s = c.ToString
        s = s.Substring(s.Length - 1)
        z = Val(s)
        If z > 0 And z < 6 Then
            a = a + ((6 - z) / 100)
            a = Math.Round(a, 2)
        End If
        c = Math.Round(a, Decimales)
        Return c
    End Function

    Function ObtenerInfoIP(ip As String) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_UTILITARIOS.sp_listar_ip", CommandType.StoredProcedure)
            db.AsignarParametro("vi_ip", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            Dim dt As DataTable = db.EjecutarDataTable()
            Return dt
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function UltimoDiaMesAño(mes As Integer, año As Integer) As Integer
        Select Case mes
            Case 1, 3, 5, 7, 8, 10, 12
                Return 31
            Case 4, 6, 9, 11
                Return 30
            Case Else
                If año Mod 4 = 0 Then
                    Return 29
                Else
                    Return 28
                End If
        End Select
    End Function

    Function NombreMes(mes As Integer) As String
        Select Case mes
            Case 1
                Return "Ene"
            Case 2
                Return "Feb"
            Case 3
                Return "Mar"
            Case 4
                Return "Abr"
            Case 5
                Return "May"
            Case 6
                Return "Jun"
            Case 7
                Return "Jul"
            Case 8
                Return "Ago"
            Case 9
                Return "Set"
            Case 10
                Return "Oct"
            Case 11
                Return "Nov"
            Case 12
                Return "Dic"
        End Select
    End Function

    Sub LimpiarGrid(dgv As DataGridView, columna As Integer)
        For Each row As DataGridViewRow In dgv.Rows
            row.Cells(columna).Value = ""
        Next
    End Sub

    Function ListarTipoControl(ByVal tipo As Integer, ByVal opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("sp_tipo_control", CommandType.StoredProcedure)
            db.AsignarParametro("ni_tipo", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("co_lista", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            Dim ds As DataSet = db.EjecutarDataSet
            If ds.Tables(1).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(1).Rows(0).Item(0)) Then
                    If ds.Tables(1).Rows(0).Item(1).ToString.Trim.Length > 0 Then
                        Throw New Exception(ds.Tables(1).Rows(0).Item(1))
                    End If
                End If
            End If
            Return ds.Tables(0)
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Function TieneNumero(cadena As String) As Boolean
        For i As Integer = 0 To cadena.Length - 1
            If IsNumeric(cadena.Substring(i, 1)) Then
                Return True
            End If
        Next
        Return False
    End Function

    Function TipoPago(ByVal tipo As Integer) As String
        Dim db_bd As New BaseDatos
        Dim strTipo As String
        Try
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select sf_get_tipo_pago(" & tipo & ") from dual"
            db_bd.Conectar()
            '-- Invocando  al procedimiento almacenado 
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            ' No tiens 
            'Variables de salidas 
            'No existe parametros de salida 
            strTipo = (CType(db_bd.EjecutarEscalar(), String))
            '
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            'Desconectar 
            db_bd.Desconectar()
        End Try
        Return strTipo
    End Function

    Public Function fnGetPortavalor(ByVal idAgencia As Integer) As Integer
        Dim Agencia As String = "NINGUNO"
        Dim db_bd As New BaseDatos
        Try
            '
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select PKG_IVOLIQUIDACION_VALOR.sf_get_portavalor(" & idAgencia & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            '
            Agencia = db_bd.EjecutarEscalar
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try

        Return Agencia
    End Function

    Function CodigoBarra(ByVal codigo As String, ByVal path As String) As Byte()
        codigo = codigo.Replace("-", "")
        Dim barcode As BarcodeLib.Barcode = New BarcodeLib.Barcode()
        barcode.Alignment = BarcodeLib.AlignmentPositions.CENTER
        Dim type As BarcodeLib.TYPE = BarcodeLib.TYPE.CODE39
        barcode.IncludeLabel = True
        barcode.RotateFlipType = RotateFlipType.RotateNoneFlipNone
        barcode.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER
        'Encodificando
        'Bitmap bm = new Bitmap(barcode.Encode(type, _code, Color.Black, Color.White,400,150));
        Dim bm As Bitmap = New Bitmap(barcode.Encode(type, codigo, Color.Black, Color.White, 200, 70))
        bm.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg)

        'Combertimos la imagen a bytes*/
        'Declaramos fs para poder abrir la imagen.
        Dim fs As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open)
        'Declaramos un lector binario para pasar la imagen a bytes
        Dim br As System.IO.BinaryReader = New System.IO.BinaryReader(fs)
        Dim imagen(fs.Length) As Byte
        br.Read(imagen, 0, fs.Length)
        br.Close()
        fs.Close()
        Return imagen
    End Function

    Function ObtieneCantidadCA(ByVal comprobante As Integer, ByVal tipo As Integer) As Integer
        Dim cantidad As Integer = 0
        Dim db_bd As New BaseDatos
        Try
            '
            Dim ls_sql As String
            'conecta con la Bd
            ls_sql = "select sf_get_cantidad_ca(" & comprobante & "," & tipo & ") from dual"
            db_bd.Conectar()
            db_bd.CrearComando(ls_sql, CommandType.Text)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input 
            '
            'Variables de salidas 
            '
            cantidad = db_bd.EjecutarEscalar
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db_bd.Desconectar()
        End Try

        Return cantidad
    End Function
End Module
