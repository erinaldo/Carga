Imports AccesoDatos
Public Class dtoPRE_GUIAS
#Region "VARIABLES"
    Dim MyREMITENTE As String
    Dim MyDIRECCIO_REMITENTE As String
    Dim MyNUME_CONTAC_REMITENTE As String
    Dim MyDIREC_DESTINATARIO As String
    Dim MyFORMA_PAGO As String
    Dim MyTIPO_ENTREGA As String
    Dim MyRAZON_SOCIAL As String
    Dim MyORIGEN As String
    Dim MyDESTINO As String
    Dim MyCODIGO_CLIENTE As String
    Dim MyIDREMITENTE As Long
    Dim MyDESTINATARIO As String
    Dim MyNUME_CONTAC_DESTINATARIO As String
    '
    Dim MyCONTACTO_REMITENTE As String
    Dim MyCONTACTO_DESTINATARIO As String
    Dim MyDIRECCION_REMITENTE As String
    Dim MyDIRECCION_DESTINATARIO As String
    Dim MyFECHA_INI As String
    Dim MyFECHA_FINAL As String
    Dim MyIDDIRECCION_REMITENTE As Long
    Dim MyIDDIRECCION_DESTINATARIO As Long
    Dim Myidcomunicacion_remitente As Long
    Dim Myidcomunicacion_destinatario As Long

    Dim MyIDCENTRO_COSTO As Long
    Dim MyID_REMITENTE As Long
    Dim MyIDAGENCIAS As Long
    Dim MyIDPRE_GUIA As Long
    Dim MyIDUSUARIO_PERSONAL As Long
    Dim MyIDROL As Long
    Dim MyIDUSUARIO_PERSONALMOD As Long
    Dim MyIDPERSONA As Long
    Dim MyIDROLMOD As Long
    Dim MyIP As String
    Dim MyIPMOD As String
    Dim MyFECHA_REGISTRO As String
    Dim MyFECHA_REGISTROMOD As String
    Dim MyIDUNIDAD_AGENCIAS_ORI As Long
    Dim MyIDAGENCIAS_ORI As Long
    Dim MyIDUNIDAD_AGENCIAS_DESTI As Long
    Dim MyIDAGENCIAS_DESTI As Long
    Dim MyIDTIPO_ENTREGA_CARGA As Long
    Dim MyIDFORMA_PAGO As Long
    Dim MyIDCONTACTO_REMITENTE As Long
    Dim MyIDCONTACTO_DESTINATARIO As Long
    Dim MyNRO_GUIA_INI As String
    Dim MyNRO_GUIA As String
    Dim MyNRO_GUIA_FINAL As String
    Dim MyULTI_NRO_GUIA_IMPRESO As String

    Dim MyId_Consignado As String
    Dim MyNombres_Consignado As String
    Dim MyNombre_Consignado As String
    Dim MyApellido_Paterno_Consignado As String
    Dim MyApellido_Materno_Consignado As String
    Dim MyNumero_Documento_Consignado As String
    Dim MyIdTipo_Documento_Consignado As String
    Dim MyTelefono_Consignado As String
    Dim MyConsignado_Modificado As String

    Dim MyDireccionConsignado As Integer
    Dim MyIdDepartamentoConsignado As Integer
    Dim MyIdProvinciaConsignado As Integer
    Dim MyIdDistritoConsignado As Integer
    Dim MyIdViaConsignado As Integer
    Dim MyViaConsignado As String
    Dim MyNumeroConsignado As String
    Dim MyManzanaConsignado As String
    Dim MyLoteConsignado As String
    Dim MyIdNivelConsignado As Integer
    Dim MyNivelConsignado As String
    Dim MyIdZonaConsignado As Integer
    Dim MyZonaConsignado As String
    Dim MyIdClasificacionConsignado As Integer
    Dim MyClasificacionConsignado As String
    Dim MyReferenciaConsignado As String
    Dim MyDescuentoConsignado As Integer
    Dim MyAutorizaConsignado As String
    Dim MyusuarioRemotoConsignado As Integer

#End Region
#Region "PROPIEDADES"


    Public Property CONTACTO_DESTINATARIO() As String
        Get
            CONTACTO_DESTINATARIO = MyCONTACTO_DESTINATARIO
        End Get
        Set(ByVal value As String)
            MyCONTACTO_DESTINATARIO = value
        End Set
    End Property
    Public Property FECHA_INI() As String
        Get
            FECHA_INI = MyFECHA_INI
        End Get
        Set(ByVal value As String)
            MyFECHA_INI = value
        End Set
    End Property
    Public Property FECHA_FINAL() As String
        Get
            FECHA_FINAL = MyFECHA_FINAL
        End Get
        Set(ByVal value As String)
            MyFECHA_FINAL = value
        End Set
    End Property
    Public Property idcomunicacion_remitente() As Long
        Get
            idcomunicacion_remitente = Myidcomunicacion_remitente
        End Get
        Set(ByVal value As Long)
            Myidcomunicacion_remitente = value
        End Set
    End Property
    Public Property idcomunicacion_destinatario() As Long
        Get
            idcomunicacion_destinatario = Myidcomunicacion_destinatario
        End Get
        Set(ByVal value As Long)
            Myidcomunicacion_destinatario = value
        End Set
    End Property
    Public Property IDAGENCIAS() As Long
        Get
            IDAGENCIAS = MyIDAGENCIAS
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONAL() As Long
        Get
            IDUSUARIO_PERSONAL = MyIDUSUARIO_PERSONAL
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONAL = value
        End Set
    End Property
    Public Property IDROL() As Long
        Get
            IDROL = MyIDROL
        End Get
        Set(ByVal value As Long)
            MyIDROL = value
        End Set
    End Property
    Public Property IDUSUARIO_PERSONALMOD() As Long
        Get
            IDUSUARIO_PERSONALMOD = MyIDUSUARIO_PERSONALMOD
        End Get
        Set(ByVal value As Long)
            MyIDUSUARIO_PERSONALMOD = value
        End Set
    End Property
    Public Property IDROLMOD() As Long
        Get
            IDROLMOD = MyIDROLMOD
        End Get
        Set(ByVal value As Long)
            MyIDROLMOD = value
        End Set
    End Property
    Public Property IP() As String
        Get
            IP = MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property
    Public Property IPMOD() As String
        Get
            IPMOD = MyIPMOD
        End Get
        Set(ByVal value As String)
            MyIPMOD = value
        End Set
    End Property

    Public Property FECHA_REGISTROMOD() As String
        Get
            FECHA_REGISTROMOD = MyFECHA_REGISTROMOD
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTROMOD = value
        End Set
    End Property
    Public Property IDPRE_GUIA() As Long
        Get
            IDPRE_GUIA = MyIDPRE_GUIA
        End Get
        Set(ByVal value As Long)
            MyIDPRE_GUIA = value
        End Set
    End Property
    Public Property CODIGO_CLIENTE() As String
        Get
            CODIGO_CLIENTE = MyCODIGO_CLIENTE
        End Get
        Set(ByVal value As String)
            MyCODIGO_CLIENTE = value
        End Set
    End Property
    Public Property IDFORMA_PAGO() As Long
        Get
            IDFORMA_PAGO = MyIDFORMA_PAGO
        End Get
        Set(ByVal value As Long)
            MyIDFORMA_PAGO = value
        End Set
    End Property
    Public Property IDREMITENTE() As Long
        Get
            IDREMITENTE = MyIDREMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDREMITENTE = value
        End Set
    End Property
    Public Property DIRECCIO_REMITENTE() As String
        Get
            DIRECCIO_REMITENTE = MyDIRECCIO_REMITENTE
        End Get
        Set(ByVal value As String)
            MyDIRECCIO_REMITENTE = value
        End Set
    End Property
    Public Property DIREC_DESTINATARIO() As String
        Get
            DIREC_DESTINATARIO = MyDIREC_DESTINATARIO
        End Get
        Set(ByVal value As String)
            MyDIREC_DESTINATARIO = value
        End Set
    End Property
    Public Property NUME_CONTAC_DESTINATARIO() As String
        Get
            NUME_CONTAC_DESTINATARIO = MyNUME_CONTAC_DESTINATARIO
        End Get
        Set(ByVal value As String)
            MyNUME_CONTAC_DESTINATARIO = value
        End Set
    End Property
    Public Property FECHA_REGISTRO() As String
        Get
            FECHA_REGISTRO = MyFECHA_REGISTRO
        End Get
        Set(ByVal value As String)
            MyFECHA_REGISTRO = value
        End Set
    End Property
    Public Property NRO_GUIA() As String
        Get
            NRO_GUIA = MyNRO_GUIA
        End Get
        Set(ByVal value As String)
            MyNRO_GUIA = value
        End Set
    End Property
    Public Property RAZON_SOCIAL() As String
        Get
            RAZON_SOCIAL = MyRAZON_SOCIAL
        End Get
        Set(ByVal value As String)
            MyRAZON_SOCIAL = value
        End Set
    End Property
    Public Property ORIGEN() As String
        Get
            ORIGEN = MyORIGEN
        End Get
        Set(ByVal value As String)
            MyORIGEN = value
        End Set
    End Property
    Public Property DESTINO() As String
        Get
            DESTINO = MyDESTINO
        End Get
        Set(ByVal value As String)
            MyDESTINO = value
        End Set
    End Property
    Public Property REMITENTE() As String
        Get
            REMITENTE = MyREMITENTE
        End Get
        Set(ByVal value As String)
            MyREMITENTE = value
        End Set
    End Property
    Public Property NUME_CONTAC_REMITENTE() As String
        Get
            NUME_CONTAC_REMITENTE = MyNUME_CONTAC_REMITENTE
        End Get
        Set(ByVal value As String)
            MyNUME_CONTAC_REMITENTE = value
        End Set
    End Property
    Public Property DESTINATARIO() As String
        Get
            DESTINATARIO = MyDESTINATARIO
        End Get
        Set(ByVal value As String)
            MyDESTINATARIO = value
        End Set
    End Property
    Public Property TIPO_ENTREGA() As String
        Get
            TIPO_ENTREGA = MyTIPO_ENTREGA
        End Get
        Set(ByVal value As String)
            MyTIPO_ENTREGA = value
        End Set
    End Property

    '--------------------- Propiedades para insertar las guias pre-impresas ---------------------
    Public Property NRO_GUIA_INI() As String
        Get
            NRO_GUIA_INI = MyNRO_GUIA_INI
        End Get
        Set(ByVal value As String)
            MyNRO_GUIA_INI = value
        End Set
    End Property
    Public Property NRO_GUIA_FINAL() As String

        Get
            NRO_GUIA_FINAL = MyNRO_GUIA_FINAL
        End Get
        Set(ByVal value As String)
            MyNRO_GUIA_FINAL = value
        End Set
    End Property
    Public Property ULTI_NRO_GUIA_IMPRESO() As String
        Get
            ULTI_NRO_GUIA_IMPRESO = MyULTI_NRO_GUIA_IMPRESO
        End Get
        Set(ByVal value As String)
            MyULTI_NRO_GUIA_IMPRESO = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIAS_ORI() As Long
        Get
            IDUNIDAD_AGENCIAS_ORI = MyIDUNIDAD_AGENCIAS_ORI
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIAS_ORI = value
        End Set
    End Property
    Public Property IDAGENCIAS_ORI() As Long
        Get
            IDAGENCIAS_ORI = MyIDAGENCIAS_ORI
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_ORI = value
        End Set
    End Property
    Public Property IDUNIDAD_AGENCIAS_DESTI() As Long
        Get
            IDUNIDAD_AGENCIAS_DESTI = MyIDUNIDAD_AGENCIAS_DESTI
        End Get
        Set(ByVal value As Long)
            MyIDUNIDAD_AGENCIAS_DESTI = value
        End Set
    End Property
    Public Property IDAGENCIAS_DESTI() As Long
        Get
            IDAGENCIAS_DESTI = MyIDAGENCIAS_DESTI
        End Get
        Set(ByVal value As Long)
            MyIDAGENCIAS_DESTI = value
        End Set
    End Property
    Public Property IDTIPO_ENTREGA_CARGA() As Long
        Get
            IDTIPO_ENTREGA_CARGA = MyIDTIPO_ENTREGA_CARGA
        End Get
        Set(ByVal value As Long)
            MyIDTIPO_ENTREGA_CARGA = value
        End Set
    End Property
    Public Property FORMA_PAGO() As String
        Get
            FORMA_PAGO = MyFORMA_PAGO
        End Get
        Set(ByVal value As String)
            MyFORMA_PAGO = value
        End Set
    End Property
    Public Property IDCENTRO_COSTO() As Long
        Get
            IDCENTRO_COSTO = MyIDCENTRO_COSTO
        End Get
        Set(ByVal value As Long)
            MyIDCENTRO_COSTO = value
        End Set
    End Property
    Public Property IDPERSONA() As Long
        Get
            IDPERSONA = MyIDPERSONA
        End Get
        Set(ByVal value As Long)
            MyIDPERSONA = value
        End Set
    End Property
    Public Property ID_REMITENTE() As Long
        Get
            ID_REMITENTE = MyID_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyID_REMITENTE = value
        End Set
    End Property
    Public Property IDCONTACTO_REMITENTE() As Long
        Get
            IDCONTACTO_REMITENTE = MyIDCONTACTO_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_REMITENTE = value
        End Set
    End Property
    Public Property CONTACTO_REMITENTE() As String
        Get
            CONTACTO_REMITENTE = MyCONTACTO_REMITENTE
        End Get
        Set(ByVal value As String)
            MyCONTACTO_REMITENTE = value
        End Set
    End Property
    Public Property IDDIRECCION_REMITENTE() As Long
        Get
            IDDIRECCION_REMITENTE = MyIDDIRECCION_REMITENTE
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_REMITENTE = value
        End Set
    End Property
    Public Property DIRECCION_REMITENTE() As String
        Get
            DIRECCION_REMITENTE = MyDIRECCION_REMITENTE
        End Get
        Set(ByVal value As String)
            MyDIRECCION_REMITENTE = value
        End Set
    End Property
    Public Property IDCONTACTO_DESTINATARIO() As Long
        Get
            IDCONTACTO_DESTINATARIO = MyIDCONTACTO_DESTINATARIO
        End Get
        Set(ByVal value As Long)
            MyIDCONTACTO_DESTINATARIO = value
        End Set
    End Property
    Public Property IDDIRECCION_DESTINATARIO() As Long
        Get
            IDDIRECCION_DESTINATARIO = MyIDDIRECCION_DESTINATARIO
        End Get
        Set(ByVal value As Long)
            MyIDDIRECCION_DESTINATARIO = value
        End Set
    End Property
    Public Property DIRECCION_DESTINATARIO() As String
        Get
            DIRECCION_DESTINATARIO = MyDIRECCION_DESTINATARIO
        End Get
        Set(ByVal value As String)
            MyDIRECCION_DESTINATARIO = value
        End Set
    End Property

    Public Property ID_CONSIGNADO() As String
        Get
            ID_CONSIGNADO = MyId_Consignado
        End Get
        Set(ByVal value As String)
            MyId_Consignado = value
        End Set
    End Property
    Public Property NOMBRES_CONSIGNADO() As String
        Get
            NOMBRES_CONSIGNADO = MyNombres_Consignado
        End Get
        Set(ByVal value As String)
            MyNombres_Consignado = value
        End Set
    End Property
    Public Property NOMBRE_CONSIGNADO() As String
        Get
            NOMBRE_CONSIGNADO = MyNombre_Consignado
        End Get
        Set(ByVal value As String)
            MyNombre_Consignado = value
        End Set
    End Property
    Public Property APELLIDO_PATERNO_CONSIGNADO() As String
        Get
            APELLIDO_PATERNO_CONSIGNADO = MyApellido_Paterno_Consignado
        End Get
        Set(ByVal value As String)
            MyApellido_Paterno_Consignado = value
        End Set
    End Property
    Public Property APELLIDO_MATERNO_CONSIGNADO() As String
        Get
            APELLIDO_MATERNO_CONSIGNADO = MyApellido_Materno_Consignado
        End Get
        Set(ByVal value As String)
            MyApellido_Materno_Consignado = value
        End Set
    End Property
    Public Property NUMERO_DOCUMENTO_CONSIGNADO() As String
        Get
            NUMERO_DOCUMENTO_CONSIGNADO = MyNumero_Documento_Consignado
        End Get
        Set(ByVal value As String)
            MyNumero_Documento_Consignado = value
        End Set
    End Property
    Public Property IDTIPO_DOCUMENTO_CONSIGNADO() As String
        Get
            IDTIPO_DOCUMENTO_CONSIGNADO = MyIdTipo_Documento_Consignado
        End Get
        Set(ByVal value As String)
            MyIdTipo_Documento_Consignado = value
        End Set
    End Property
    Public Property TELEFONO_CONSIGNADO() As String
        Get
            TELEFONO_CONSIGNADO = MyTelefono_Consignado
        End Get
        Set(ByVal value As String)
            MyTelefono_Consignado = value
        End Set
    End Property
    Public Property CONSIGNADO_MODIFICADO() As String
        Get
            CONSIGNADO_MODIFICADO = MyConsignado_Modificado
        End Get
        Set(ByVal value As String)
            MyConsignado_Modificado = value
        End Set
    End Property

    Public Property DIRECCION_CONSIGNADO() As Integer
        Get
            DIRECCION_CONSIGNADO = MyDireccionConsignado
        End Get
        Set(ByVal value As Integer)
            MyDireccionConsignado = value
        End Set
    End Property
    Public Property IDDDEPARTAMENTO_CONSIGNADO() As Integer
        Get
            IDDDEPARTAMENTO_CONSIGNADO = MyIdDepartamentoConsignado
        End Get
        Set(ByVal value As Integer)
            MyIdDepartamentoConsignado = value
        End Set
    End Property
    Public Property IDPROVINCIA_CONSIGNADO() As Integer
        Get
            IDPROVINCIA_CONSIGNADO = MyIdProvinciaConsignado
        End Get
        Set(ByVal value As Integer)
            MyIdProvinciaConsignado = value
        End Set
    End Property
    Public Property IDDISTRITO_CONSIGNADO() As Integer
        Get
            IDDISTRITO_CONSIGNADO = MyIdDistritoConsignado
        End Get
        Set(ByVal value As Integer)
            MyIdDistritoConsignado = value
        End Set
    End Property
    Public Property IDVIA_CONSIGNADO() As Integer
        Get
            IDVIA_CONSIGNADO = MyIdViaConsignado
        End Get
        Set(ByVal value As Integer)
            MyIdViaConsignado = value
        End Set
    End Property
    Public Property VIA_CONSIGNADO() As String
        Get
            VIA_CONSIGNADO = MyViaConsignado
        End Get
        Set(ByVal value As String)
            MyViaConsignado = value
        End Set
    End Property
    Public Property NUMERO_CONSIGNADO() As String
        Get
            NUMERO_CONSIGNADO = MyNumeroConsignado
        End Get
        Set(ByVal value As String)
            MyNumeroConsignado = value
        End Set
    End Property
    Public Property MANZANA_CONSIGNADO() As String
        Get
            MANZANA_CONSIGNADO = MyManzanaConsignado
        End Get
        Set(ByVal value As String)
            MyManzanaConsignado = value
        End Set
    End Property
    Public Property LOTE_CONSIGNADO() As String
        Get
            LOTE_CONSIGNADO = MyLoteConsignado
        End Get
        Set(ByVal value As String)
            MyLoteConsignado = value
        End Set
    End Property
    Public Property IDNIVEL_CONSIGNADO() As Integer
        Get
            IDNIVEL_CONSIGNADO = MyIdNivelConsignado
        End Get
        Set(ByVal value As Integer)
            MyIdNivelConsignado = value
        End Set
    End Property
    Public Property NIVEL_CONSIGNADO() As String
        Get
            NIVEL_CONSIGNADO = MyNivelConsignado
        End Get
        Set(ByVal value As String)
            MyNivelConsignado = value
        End Set
    End Property
    Public Property IDZONA_CONSIGNADO() As Integer
        Get
            IDZONA_CONSIGNADO = MyIdZonaConsignado
        End Get
        Set(ByVal value As Integer)
            MyIdZonaConsignado = value
        End Set
    End Property
    Public Property ZONA_CONSIGNADO() As String
        Get
            ZONA_CONSIGNADO = MyZonaConsignado
        End Get
        Set(ByVal value As String)
            MyZonaConsignado = value
        End Set
    End Property
    Public Property IDCLASIFICACION_CONSIGNADO() As Integer
        Get
            IDCLASIFICACION_CONSIGNADO = MyIdClasificacionConsignado
        End Get
        Set(ByVal value As Integer)
            MyIdClasificacionConsignado = value
        End Set
    End Property
    Public Property CLASIFICACION_CONSIGNADO() As String
        Get
            CLASIFICACION_CONSIGNADO = MyClasificacionConsignado
        End Get
        Set(ByVal value As String)
            MyClasificacionConsignado = value
        End Set
    End Property
    Public Property REFERENCIA_CONSIGNADO() As String
        Get
            REFERENCIA_CONSIGNADO = MyReferenciaConsignado
        End Get
        Set(ByVal value As String)
            MyReferenciaConsignado = value
        End Set
    End Property
    Public Property DESCUENTO_CONSIGNADO() As Integer
        Get
            DESCUENTO_CONSIGNADO = MyDescuentoConsignado
        End Get
        Set(ByVal value As Integer)
            MyDescuentoConsignado = value
        End Set
    End Property
    Public Property AUTORIZA_CONSIGNADO() As String
        Get
            AUTORIZA_CONSIGNADO = MyAutorizaConsignado
        End Get
        Set(ByVal value As String)
            MyAutorizaConsignado = value
        End Set
    End Property
    Public Property USUARIO_REMOTO_CONSIGNADO() As Integer
        Get
            USUARIO_REMOTO_CONSIGNADO = MyusuarioRemotoConsignado
        End Get
        Set(ByVal value As Integer)
            MyusuarioRemotoConsignado = value
        End Set
    End Property

    '--------------------------------------------------------------------------------------------

#End Region
#Region "METODOS"
    'Public RST_LISTA_PERSONAS As New ADODB.Recordset
    Public COLL_LISTA_PERSONAS As New Collection

    'Public Function fnLISTA_PERSONAS_2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Dim flat As Boolean = False
    '    Try
    '        Dim varSP_OBJECT() As Object = {"PKG_IVOIMPRE_PRE_GUIAS.SP_LISTA_PERSONAS", 2}
    '        RST_LISTA_PERSONAS = Nothing
    '        RST_LISTA_PERSONAS = VOCONTROLUSUARIO.fnSQLQuery(varSP_OBJECT)
    '        flat = True
    '    Catch ex As Exception
    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function

    'Public cur_lista_unidades As New ADODB.Recordset
    'Public cur_lista_agencias As New ADODB.Recordset
    'Public cur_lista_usuarios As New ADODB.Recordset
    'Public cur_lista_estados As New ADODB.Recordset
    'Public cur_lista_forma_pagos As New ADODB.Recordset
    'Public cur_lista_tipo_entrega As New ADODB.Recordset
    'Public cur_lista_unidades_visor As New ADODB.Recordset
    'Public cur_lista_remitentes As New ADODB.Recordset
    'Public cur_lista_origen As New ADODB.Recordset

    Public coll_lista_unidades As New Collection
    Public coll_lista_agencias As New Collection
    Public coll_lista_usuarios As New Collection
    Public coll_lista_estados As New Collection
    Public coll_lista_forma_pagos As New Collection
    Public coll_lista_tipo_entrega As New Collection
    Public coll_lista_unidades_visor As New Collection
    Public coll_lista_remitentes As New Collection
    Public coll_lista_origen As New Collection
    'Public Function fnlista_ini_impre_pre_guias_2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Dim flat As Boolean = True
    '    cur_lista_unidades = Nothing
    '    cur_lista_agencias = Nothing
    '    cur_lista_usuarios = Nothing
    '    cur_lista_estados = Nothing
    '    cur_lista_forma_pagos = Nothing
    '    cur_lista_tipo_entrega = Nothing
    '    cur_lista_unidades_visor = Nothing
    '    Try
    '        Dim VarSP_Object() As Object = {"pkg_ivoimpre_pre_guias.sp_lista_ini_impre_pre_guias", 6, Me.IDUSUARIO_PERSONAL, 1, Me.IDROL, 1}
    '        cur_lista_origen = VOCONTROLUSUARIO.fnsqlquery(VarSP_Object)
    '        If cur_lista_origen.EOF = False And cur_lista_origen.BOF = False Then
    '            cur_lista_agencias = cur_lista_origen.NextRecordset
    '            cur_lista_usuarios = cur_lista_origen.NextRecordset
    '            cur_lista_estados = cur_lista_origen.NextRecordset
    '            cur_lista_forma_pagos = cur_lista_origen.NextRecordset
    '            cur_lista_tipo_entrega = cur_lista_origen.NextRecordset
    '            cur_lista_unidades_visor = cur_lista_origen.NextRecordset
    '        End If
    '    Catch ex As Exception

    '        flat = False
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad Sistema")
    '    End Try
    '    Return flat
    'End Function
    'Public cur_listar_pre_guias As New ADODB.Recordset
    Public cur_listar_pre_guias As DataSet
    Public coll_listar_pre_guias As New Collection

    'Public Function fnlistar_Pre_guias2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Dim flat As Boolean = True
    '    Try

    '        cur_listar_pre_guias = Nothing

    '        Dim VarSP_Object() As Object = {"PKG_IVOIMPRE_PRE_GUIAS.sp_listar_Pre_guias", 8, CStr(Me.IDPERSONA), 2, FECHA_INI, 2, FECHA_FINAL, 2}
    '        cur_listar_pre_guias = VOCONTROLUSUARIO.fnsqlquery(VarSP_Object)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Segurdidad del sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    Public Function fnlistar_Pre_guias() As Boolean
        Dim flat As Boolean = True
        Try            'cur_listar_pre_guias = Nothing

            'Dim VarSP_Object() As Object = {"PKG_IVOIMPRE_PRE_GUIAS.sp_listar_Pre_guias", 8, CStr(Me.IDPERSONA), 2, FECHA_INI, 2, FECHA_FINAL, 2}
            'cur_listar_pre_guias = VOCONTROLUSUARIO.fnsqlquery(VarSP_Object)
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOIMPRE_PRE_GUIAS.sp_listar_Pre_guias", CommandType.StoredProcedure)
            db.AsignarParametro("p_idpersona", CStr(Me.IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_ini", FECHA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_fecha_final", FECHA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur_listar_pre_guias", OracleClient.OracleType.Cursor)
            db.AsignarParametro("curr_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            cur_listar_pre_guias = db.EjecutarDataSet

        Catch ex As Exception
            flat = False
        End Try
        Return flat
    End Function

    'Public cur_listar_pre_guias_deta As New ADODB.Recordset
    Public coll_listar_pre_guias_deta As New Collection
    'Public Function fnlistar_Pre_guias_deta_2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Dim flat As Boolean = True
    '    Try

    '        cur_listar_pre_guias_deta = Nothing

    '        Dim VarSP_Object() As Object = {"PKG_IVOIMPRE_PRE_GUIAS.sp_listar_Pre_guias_deta", 4, Me.IDPRE_GUIA, 1}
    '        cur_listar_pre_guias_deta = VOCONTROLUSUARIO.fnsqlquery(VarSP_Object)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Segurdidad del sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    '
    'Public CUR_Cliente As New ADODB.Recordset
    'Public CUR_Sub_Cuenta As New ADODB.Recordset
    'Public CUR_Nombres_Remitente As New ADODB.Recordset
    'Public CUR_Direccion_Remitente As New ADODB.Recordset
    'Public CUR_Telefono_Remitente As New ADODB.Recordset
    'Public CUR_Nombres_Destinatario As New ADODB.Recordset
    'Public CUR_Direccion_Destinatario As New ADODB.Recordset
    'Public CUR_Telefono_Destinatario As New ADODB.Recordset
    'Public CUR_Documentos_Adjuntos As New ADODB.Recordset
    'Public CUR_Pagos As New ADODB.Recordset
    '
    Public coll_Cliente As New Collection
    Public coll_Sub_Cuenta As New Collection
    Public coll_Nombres_Remitente As New Collection
    Public coll_Direccion_Remitente As New Collection
    Public coll_Telefono_Remitente As New Collection
    Public coll_Nombres_Destinatario As New Collection
    Public coll_Direccion_Destinatario As New Collection
    Public coll_Telefono_Destinatario As New Collection
    Public coll_Documentos_Adjuntos As New Collection
    Public coll_Pagos As New Collection
    'Public Function fncontrol_pre_guias_2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Dim flat As Boolean = True
    '    Try

    '        Dim VarSP_Object() As Object = {"PKG_IVOGENERAL.SP_CONTROL_GUIAS_ENVIO_DOC", 4, Me.IDPERSONA, 1}
    '        CUR_Cliente = Nothing
    '        CUR_Sub_Cuenta = Nothing
    '        CUR_Nombres_Remitente = Nothing
    '        CUR_Direccion_Remitente = Nothing
    '        CUR_Telefono_Remitente = Nothing
    '        CUR_Nombres_Destinatario = Nothing
    '        CUR_Direccion_Destinatario = Nothing
    '        CUR_Telefono_Destinatario = Nothing
    '        CUR_Documentos_Adjuntos = Nothing
    '        CUR_Pagos = Nothing

    '        CUR_Cliente = VOCONTROLUSUARIO.fnsqlquery(VarSP_Object)
    '        If CUR_Cliente.EOF = False And CUR_Cliente.BOF Then
    '            CUR_Sub_Cuenta = CUR_Cliente.NextRecordset
    '            CUR_Nombres_Remitente = CUR_Cliente.NextRecordset
    '            CUR_Direccion_Remitente = CUR_Cliente.NextRecordset
    '            CUR_Telefono_Remitente = CUR_Cliente.NextRecordset
    '            CUR_Nombres_Destinatario = CUR_Cliente.NextRecordset
    '            CUR_Direccion_Destinatario = CUR_Cliente.NextRecordset
    '            CUR_Telefono_Destinatario = CUR_Cliente.NextRecordset
    '            CUR_Documentos_Adjuntos = CUR_Cliente.NextRecordset
    '            CUR_Pagos = CUR_Cliente.NextRecordset
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Segurdidad del sistema")
    '        flat = False
    '    End Try
    '    Return flat
    'End Function
    'Public Function SP_SELEC_SELECIONAR_PRE_GUIA_2009(ByVal cnn As System.Data.OracleClient.OracleConnection) As Boolean
    '    Try
    '        Dim cmd As New System.Data.OracleClient.OracleCommand
    '        cmd.Connection = cnn
    '        cmd.CommandType = CommandType.StoredProcedure

    '        cmd.CommandText = "PKG_IVOIMPRE_PRE_GUIAS.SP_SELECIONAR_PRE_GUIA"
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("P_NRO_GUIA", OracleClient.OracleType.VarChar)).Value = Val(NRO_GUIA)
    '        cmd.Parameters.Add(New OracleClient.OracleParameter("CURR_SELECIONAR_PRE_GUIA", OracleClient.OracleType.Cursor)).Direction = ParameterDirection.Output
    '        '
    '        Dim daora As New System.Data.OracleClient.OracleDataAdapter(cmd)
    '        Dim ds As New DataSet
    '        daora.Fill(ds)
    '        Dim dv As New DataView
    '        dv = ds.Tables(0).DefaultView
    '        If dv.Count > 0 Then
    '            If Not dv.Table.Rows(0).IsNull("NRO_GUIA_INI") Then NRO_GUIA_INI = dv.Table.Rows(0)("NRO_GUIA_INI") Else NRO_GUIA_INI = ""
    '            If Not dv.Table.Rows(0).IsNull("NRO_GUIA_FINAL") Then NRO_GUIA_FINAL = dv.Table.Rows(0)("NRO_GUIA_FINAL") Else NRO_GUIA_FINAL = ""
    '            If Not dv.Table.Rows(0).IsNull("IDPRE_GUIA") Then IDPRE_GUIA = dv.Table.Rows(0)("IDPRE_GUIA") Else IDPRE_GUIA = 0
    '            If Not dv.Table.Rows(0).IsNull("RAZON_SOCIAL") Then RAZON_SOCIAL = dv.Table.Rows(0)("RAZON_SOCIAL") Else RAZON_SOCIAL = ""
    '            If Not dv.Table.Rows(0).IsNull("ORIGEN") Then ORIGEN = dv.Table.Rows(0)("ORIGEN") Else ORIGEN = ""
    '            If Not dv.Table.Rows(0).IsNull("DESTINO") Then DESTINO = dv.Table.Rows(0)("DESTINO") Else DESTINO = ""
    '            If Not dv.Table.Rows(0).IsNull("CODIGO_CLIENTE") Then CODIGO_CLIENTE = dv.Table.Rows(0)("CODIGO_CLIENTE") Else CODIGO_CLIENTE = ""
    '            If Not dv.Table.Rows(0).IsNull("IDFORMA_PAGO") Then IDFORMA_PAGO = dv.Table.Rows(0)("IDFORMA_PAGO") Else IDFORMA_PAGO = 0
    '            If Not dv.Table.Rows(0).IsNull("REMITENTE") Then REMITENTE = dv.Table.Rows(0)("REMITENTE") Else REMITENTE = ""
    '            If Not dv.Table.Rows(0).IsNull("IDREMITENTE") Then IDREMITENTE = dv.Table.Rows(0)("IDREMITENTE") Else IDREMITENTE = 0
    '            If Not dv.Table.Rows(0).IsNull("DIRECCIO_REMITENTE") Then DIRECCIO_REMITENTE = dv.Table.Rows(0)("DIRECCIO_REMITENTE") Else DIRECCIO_REMITENTE = ""
    '            If Not dv.Table.Rows(0).IsNull("NUME_CONTAC_REMITENTE") Then NUME_CONTAC_REMITENTE = dv.Table.Rows(0)("NUME_CONTAC_REMITENTE") Else NUME_CONTAC_REMITENTE = ""
    '            If Not dv.Table.Rows(0).IsNull("DESTINATARIO") Then DESTINATARIO = dv.Table.Rows(0)("DESTINATARIO") Else DESTINATARIO = ""
    '            If Not dv.Table.Rows(0).IsNull("DIREC_DESTINATARIO") Then DIREC_DESTINATARIO = dv.Table.Rows(0)("DIREC_DESTINATARIO") Else DIREC_DESTINATARIO = ""
    '            If Not dv.Table.Rows(0).IsNull("NUME_CONTAC_DESTINATARIO") Then NUME_CONTAC_DESTINATARIO = dv.Table.Rows(0)("NUME_CONTAC_DESTINATARIO") Else NUME_CONTAC_DESTINATARIO = ""
    '            If Not dv.Table.Rows(0).IsNull("FORMA_PAGO") Then FORMA_PAGO = dv.Table.Rows(0)("FORMA_PAGO") Else FORMA_PAGO = ""
    '            If Not dv.Table.Rows(0).IsNull("TIPO_ENTREGA") Then TIPO_ENTREGA = dv.Table.Rows(0)("TIPO_ENTREGA") Else TIPO_ENTREGA = ""
    '            If Not dv.Table.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = dv.Table.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
    '            If Not dv.Table.Rows(0).IsNull("NRO_GUIA") Then NRO_GUIA = dv.Table.Rows(0)("NRO_GUIA") Else NRO_GUIA = ""
    '            If Not dv.Table.Rows(0).IsNull("idtipo_entrega_carga") Then IDTIPO_ENTREGA_CARGA = dv.Table.Rows(0)("idtipo_entrega_carga") Else IDTIPO_ENTREGA_CARGA = 0
    '            Return True
    '        End If
    '        Return False
    '    Catch
    '        Throw
    '    End Try
    'End Function
    Public Function SP_SELEC_SELECIONAR_PRE_GUIA() As Boolean
        Try
            '
            Dim db_bd As New BaseDatos
            Dim ldt_tmp As New DataTable
            '
            'conecta con la Bd
            db_bd.Conectar()
            ' Invocando  al procedimiento almacenado 
            db_bd.CrearComando("PKG_IVOIMPRE_PRE_GUIAS.SP_SELECIONAR_PRE_GUIA", CommandType.StoredProcedure)
            'Adicionando variables para el uso de parámetros de acuerdo al proc. almacenado input             
            db_bd.AsignarParametro("P_Nro_Guia", NRO_GUIA, OracleClient.OracleType.Int32)
            'Variables de salidas 
            db_bd.AsignarParametro("CURR_SELECIONAR_PRE_GUIA", OracleClient.OracleType.Cursor)
            'Desconectar 
            db_bd.Desconectar()
            '
            ldt_tmp = db_bd.EjecutarDataTable()
            If ldt_tmp.Rows.Count > 0 Then
                If Not ldt_tmp.Rows(0).IsNull("NRO_GUIA_INI") Then NRO_GUIA_INI = ldt_tmp.Rows(0)("NRO_GUIA_INI") Else NRO_GUIA_INI = ""
                If Not ldt_tmp.Rows(0).IsNull("NRO_GUIA_FINAL") Then NRO_GUIA_FINAL = ldt_tmp.Rows(0)("NRO_GUIA_FINAL") Else NRO_GUIA_FINAL = ""
                If Not ldt_tmp.Rows(0).IsNull("IDPRE_GUIA") Then IDPRE_GUIA = ldt_tmp.Rows(0)("IDPRE_GUIA") Else IDPRE_GUIA = 0
                If Not ldt_tmp.Rows(0).IsNull("RAZON_SOCIAL") Then RAZON_SOCIAL = ldt_tmp.Rows(0)("RAZON_SOCIAL") Else RAZON_SOCIAL = ""
                If Not ldt_tmp.Rows(0).IsNull("ORIGEN") Then ORIGEN = ldt_tmp.Rows(0)("ORIGEN") Else ORIGEN = ""
                If Not ldt_tmp.Rows(0).IsNull("DESTINO") Then DESTINO = ldt_tmp.Rows(0)("DESTINO") Else DESTINO = ""
                If Not ldt_tmp.Rows(0).IsNull("CODIGO_CLIENTE") Then CODIGO_CLIENTE = ldt_tmp.Rows(0)("CODIGO_CLIENTE") Else CODIGO_CLIENTE = ""
                If Not ldt_tmp.Rows(0).IsNull("IDFORMA_PAGO") Then IDFORMA_PAGO = ldt_tmp.Rows(0)("IDFORMA_PAGO") Else IDFORMA_PAGO = 0
                If Not ldt_tmp.Rows(0).IsNull("REMITENTE") Then REMITENTE = ldt_tmp.Rows(0)("REMITENTE") Else REMITENTE = ""
                If Not ldt_tmp.Rows(0).IsNull("IDREMITENTE") Then IDREMITENTE = ldt_tmp.Rows(0)("IDREMITENTE") Else IDREMITENTE = 0
                If Not ldt_tmp.Rows(0).IsNull("DIRECCIO_REMITENTE") Then DIRECCIO_REMITENTE = ldt_tmp.Rows(0)("DIRECCIO_REMITENTE") Else DIRECCIO_REMITENTE = ""
                If Not ldt_tmp.Rows(0).IsNull("NUME_CONTAC_REMITENTE") Then NUME_CONTAC_REMITENTE = ldt_tmp.Rows(0)("NUME_CONTAC_REMITENTE") Else NUME_CONTAC_REMITENTE = ""
                If Not ldt_tmp.Rows(0).IsNull("DESTINATARIO") Then DESTINATARIO = ldt_tmp.Rows(0)("DESTINATARIO") Else DESTINATARIO = ""
                If Not ldt_tmp.Rows(0).IsNull("DIREC_DESTINATARIO") Then DIREC_DESTINATARIO = ldt_tmp.Rows(0)("DIREC_DESTINATARIO") Else DIREC_DESTINATARIO = ""
                If Not ldt_tmp.Rows(0).IsNull("NUME_CONTAC_DESTINATARIO") Then NUME_CONTAC_DESTINATARIO = ldt_tmp.Rows(0)("NUME_CONTAC_DESTINATARIO") Else NUME_CONTAC_DESTINATARIO = ""
                If Not ldt_tmp.Rows(0).IsNull("FORMA_PAGO") Then FORMA_PAGO = ldt_tmp.Rows(0)("FORMA_PAGO") Else FORMA_PAGO = ""
                If Not ldt_tmp.Rows(0).IsNull("TIPO_ENTREGA") Then TIPO_ENTREGA = ldt_tmp.Rows(0)("TIPO_ENTREGA") Else TIPO_ENTREGA = ""
                If Not ldt_tmp.Rows(0).IsNull("FECHA_REGISTRO") Then FECHA_REGISTRO = ldt_tmp.Rows(0)("FECHA_REGISTRO") Else FECHA_REGISTRO = ""
                If Not ldt_tmp.Rows(0).IsNull("NRO_GUIA") Then NRO_GUIA = ldt_tmp.Rows(0)("NRO_GUIA") Else NRO_GUIA = ""
                If Not ldt_tmp.Rows(0).IsNull("idtipo_entrega_carga") Then IDTIPO_ENTREGA_CARGA = ldt_tmp.Rows(0)("idtipo_entrega_carga") Else IDTIPO_ENTREGA_CARGA = 0
                Return True
            End If
            Return False
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    'Public Function fnINSERTAR_GUIAS_PRE_IMPRESAS2009(ByVal VOCONTROLUSUARIO As Object) As Boolean
    '    Dim rst As ADODB.Recordset
    '    Dim Dv As New DataView
    '    Dim DA As New OleDb.OleDbDataAdapter
    '    Dim Dt As New DataTable
    '    Dim a As Long = 0
    '    Dim m As Long
    '    Try
    '        Dim VarSP_OBJECT() As Object = {"PKG_IVOIMPRE_PRE_GUIAS.SP_INSERTAR_GUIAS_PRE_IMPRESAS", 50, _
    '        IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), 1, _
    '        IDUSUARIO_PERSONAL, 1, _
    '        IDROL, 1, _
    '        IP, 2, _
    '        CStr(IDPERSONA), 2, _
    '        IIf(IDAGENCIAS_ORI = 0, -666, IDAGENCIAS_ORI), 1, _
    '        IIf(IDAGENCIAS_DESTI = 0, -666, IDAGENCIAS_DESTI), 1, _
    '        IIf(IDTIPO_ENTREGA_CARGA = 0, -666, IDTIPO_ENTREGA_CARGA), 1, _
    '        IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), 1, _
    '        CStr(IIf(IDCONTACTO_REMITENTE = "0", "NULL", IDCONTACTO_REMITENTE)), 2, _
    '        IIf(CONTACTO_REMITENTE = "0", "NULL", CONTACTO_REMITENTE), 2, _
    '        CStr(IIf(IDCONTACTO_DESTINATARIO = "0", "NULL", IDCONTACTO_DESTINATARIO)), 2, _
    '        IIf(CONTACTO_DESTINATARIO = "0", "NULL", CONTACTO_DESTINATARIO), 2, _
    '        NRO_GUIA_INI, 2, _
    '        NRO_GUIA_FINAL, 2, _
    '        ULTI_NRO_GUIA_IMPRESO, 2, _
    '        CStr(IIf(IDDIRECCION_REMITENTE = "0", "NULL", IDDIRECCION_REMITENTE)), 2, _
    '        IIf(DIRECCION_REMITENTE = "0", "NULL", DIRECCION_REMITENTE), 2, _
    '        CStr(IIf(IDDIRECCION_DESTINATARIO = "0", "NULL", IDDIRECCION_DESTINATARIO)), 2, _
    '        IIf(DIRECCION_DESTINATARIO = "0", "NULL", DIRECCION_DESTINATARIO), 2, _
    '        CStr(IIf(idcomunicacion_remitente = "0", "NULL", idcomunicacion_remitente)), 2, _
    '        CStr(IIf(idcomunicacion_destinatario = "0", "NULL", idcomunicacion_destinatario)), 2, _
    '        CStr(IIf(ID_REMITENTE = "0", "NULL", ID_REMITENTE)), 2, _
    '        IIf(IDCENTRO_COSTO = 0, -666, IDCENTRO_COSTO), 1}

    '        rst = VOCONTROLUSUARIO.fnsqlquery(VarSP_OBJECT)

    '        DA.Fill(Dt, rst)
    '        Dv = Dt.DefaultView

    '        If Not Dv.Count = 0 Then
    '            If Not Dv.Table.Rows(0).IsNull(0) Then
    '                If Dv.Table.Rows(0)(0) = -666 Then
    '                    m = 1 / a
    '                End If
    '            End If
    '        End If

    '        Return True
    '    Catch ex As System.Exception
    '        MsgBox(ex.ToString, MsgBoxStyle.Information, "Seguridad del Sistema")
    '        'MsgBox(Dv.Table.Rows(0)(2), MsgBoxStyle.Information, "Seguridad del Sistema")
    '        Return False
    '    End Try

    'End Function

    Public Function fnINSERTAR_GUIAS_PRE_IMPRESAS() As Boolean
        Dim Dv As New DataView
        Dim Ds As New DataSet
        Dim Dt As New DataSet
        Dim a As Long = 0
        Dim m As Long
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'db.CrearComando("PKG_IVOIMPRE_PRE_GUIAS.SP_INSERTAR_GUIAS_PRE_IMPRESAS", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOIMPRE_PRE_GUIAS.SP_INSERT_GUIAS_PRE_IMPRESAS_2", CommandType.StoredProcedure)

            db.AsignarParametro("P_IDAGENCIAS", IIf(IDAGENCIAS = 0, -666, IDAGENCIAS), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDUSUARIO_PERSONAL", IDUSUARIO_PERSONAL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDROL", IDROL, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IP", IP, OracleClient.OracleType.VarChar)

            db.AsignarParametro("P_NRO_GUIA_INI", NRO_GUIA_INI, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NRO_GUIA_FINAL", NRO_GUIA_FINAL, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_ULTI_NRO_GUIA_IMPRESO", ULTI_NRO_GUIA_IMPRESO, OracleClient.OracleType.VarChar)

            db.AsignarParametro("P_IDPERSONA", CStr(IDPERSONA), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDAGENCIAS_ORI", IIf(IDUNIDAD_AGENCIAS_ORI = 0, -666, IDUNIDAD_AGENCIAS_ORI), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS_O", IIf(IDAGENCIAS_ORI = 0, -666, IDAGENCIAS_ORI), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS_DESTI", IIf(IDUNIDAD_AGENCIAS_DESTI = 0, -666, IDUNIDAD_AGENCIAS_DESTI), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDAGENCIAS_D", IIf(IDAGENCIAS_DESTI = 0, -666, IDAGENCIAS_DESTI), OracleClient.OracleType.Int32)

            db.AsignarParametro("P_IDTIPO_ENTREGA_CARGA", IIf(IDTIPO_ENTREGA_CARGA = 0, -666, IDTIPO_ENTREGA_CARGA), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDFORMA_PAGO", IIf(IDFORMA_PAGO = 0, -666, IDFORMA_PAGO), OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDCENTRO_COSTO", IIf(IDCENTRO_COSTO = 0, -666, IDCENTRO_COSTO), OracleClient.OracleType.Int32)

            db.AsignarParametro("P_ID_REMITENTE", CStr(IIf(ID_REMITENTE = "0", "NULL", ID_REMITENTE)), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDCONTACTO_REMITENTE", CStr(IIf(IDCONTACTO_REMITENTE = "0", "NULL", IDCONTACTO_REMITENTE)), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CONTACTO_REMITENTE", IIf(CONTACTO_REMITENTE = "0", "NULL", CONTACTO_REMITENTE), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDDIRECCION_REMITENTE", CStr(IIf(IDDIRECCION_REMITENTE = "0", "NULL", IDDIRECCION_REMITENTE)), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_DIRECCION_REMITENTE", IIf(DIRECCION_REMITENTE = "0", "NULL", DIRECCION_REMITENTE), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_idcomunicacion_remitente", CStr(IIf(idcomunicacion_remitente = "0", "NULL", idcomunicacion_remitente)), OracleClient.OracleType.VarChar)

            db.AsignarParametro("P_IDCONTACTO_DESTINATARIO", CStr(IIf(IDCONTACTO_DESTINATARIO = "0", "NULL", IDCONTACTO_DESTINATARIO)), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CONTACTO_DESTINATARIO", IIf(CONTACTO_DESTINATARIO = "0", "NULL", CONTACTO_DESTINATARIO), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDDIRECCION_DESTINATARIO", CStr(IIf(IDDIRECCION_DESTINATARIO = "0", "NULL", IDDIRECCION_DESTINATARIO)), OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_DIRECCION_DESTINATARIO", IIf(DIRECCION_DESTINATARIO = "0", "NULL", DIRECCION_DESTINATARIO), OracleClient.OracleType.VarChar)
            db.AsignarParametro("p_idcomunicacion_destinatario", CStr(IIf(idcomunicacion_destinatario = "0", "NULL", idcomunicacion_destinatario)), OracleClient.OracleType.VarChar)

            'CONSIGNADO
            'db.AsignarParametro("P_ID_CONSIGNADO", ID_CONSIGNADO, OracleClient.OracleType.VarChar)
            'db.AsignarParametro("P_NOMBRES_CONSIGNADO", NOMBRES_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NOMBRE_CONSIGNADO", NOMBRE_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_APELLIDO_PATERNO_CONSIGNADO", APELLIDO_PATERNO_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_APELLIDO_MATERNO_CONSIGNADO", APELLIDO_MATERNO_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NUMERO_DOCUMENTO_CONSIGNADO", NUMERO_DOCUMENTO_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDTIPO_DOCUMENTO_CONSIGNADO", IDTIPO_DOCUMENTO_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_TELEFONO_CONSIGNADO", TELEFONO_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_CONSIGNADO_MODIFICADO", CONSIGNADO_MODIFICADO, OracleClient.OracleType.VarChar)

            ''DIRECCION ESTRUCTURADA CONSIGNADO (DESTINATARIO)
            db.AsignarParametro("P_DIRECCION_CONSIGNADO", DIRECCION_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDDEPARTAMENTO_CONSIGNADO", IDDDEPARTAMENTO_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDPROVINCIA_CONSIGNADO", IDPROVINCIA_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDDISTRITO_CONSIGNADO", IDDISTRITO_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_IDVIA_CONSIGNADO", IDVIA_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_VIA_CONSIGNADO", VIA_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_NUMERO_CONSIGNADO", NUMERO_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_MANZANA_CONSIGANDO", MANZANA_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_LOTE_CONSIGNADO", LOTE_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDNIVEL_CONSIGNADO", IDNIVEL_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_NIVEL_CONSIGNADO", NIVEL_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDZONA_CONSIGNADO", IDZONA_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_ZONA_CONSIGNADO", ZONA_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_IDCLASIFICACION_CONSIGNADO", IDCLASIFICACION_CONSIGNADO, OracleClient.OracleType.Int32)
            db.AsignarParametro("P_CLASIFICACION_CONSIGNADO", CLASIFICACION_CONSIGNADO, OracleClient.OracleType.VarChar)
            db.AsignarParametro("P_REFERENCIA", REFERENCIA_CONSIGNADO, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            'db.AsignarParametro("P_DESCUENTO", DESCUENTO_CONSIGNADO, OracleClient.OracleType.Number) '07092011  Nuevo Parametro
            'db.AsignarParametro("P_AUTORIZA", AUTORIZA_CONSIGNADO, OracleClient.OracleType.VarChar) '07092011  Nuevo Parametro
            'db.AsignarParametro("P_IDUSUARIO_REMOTO", USUARIO_REMOTO_CONSIGNADO, OracleClient.OracleType.Int32)

            db.AsignarParametro("CURR_LISTA_GUIAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("co_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Ds = db.EjecutarDataSet
            Dv = Ds.Tables(0).DefaultView

            If Not Dv.Count = 0 Then
                If Not Dv.Table.Rows(0).IsNull(0) Then
                    If Dv.Table.Rows(0)(0) = -666 Then
                        m = 1 / a
                    End If
                End If
            End If
            Return True
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
#End Region
End Class