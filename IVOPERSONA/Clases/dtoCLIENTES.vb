'Imports ADODB
Imports AccesoDatos

#Region " CAMPOS DE LA TABLA CLIENTES "
'iCONTROL                 IN INTEGER,         
'iITEMTIPO_PERSONA        IN INTEGER,           
'iIDPERSONA               IN T_PERSONA.IDPERSONA%TYPE,
'iCLIENTE_CORPORATIVO     IN T_PERSONA.CLIENTE_CORPORATIVO%TYPE,
'iREPRESENTANTE_LEGAL     IN T_PERSONA.REPRESENTANTE_LEGAL%TYPE,
'iGERENTE_GENERAL         IN T_PERSONA.GERENTE_GENERAL%TYPE,
'iRAZON_SOCIAL            IN T_PERSONA.RAZON_SOCIAL%TYPE,
'iCODIGO_CLIENTE          IN T_PERSONA.CODIGO_CLIENTE%TYPE,
'iFECHA_INGRESO           IN T_PERSONA.FECHA_INGRESO%TYPE,
'iPAGO_POST_FACTURACION   IN T_PERSONA.PAGO_POST_FACTURACION%TYPE,
'iEMAIL                   IN T_PERSONA.EMAIL%TYPE,
'iAPELLIDO_PATERNO        IN T_PERSONA.APELLIDO_PATERNO%TYPE,
'iAPELLIDO_MATERNO        IN T_PERSONA.APELLIDO_MATERNO%TYPE,
'iNOMPRE_PERSONA          IN T_PERSONA.NOMPRE_PERSONA%TYPE,
'iNOMPRE_PERSONA1         IN T_PERSONA.NOMPRE_PERSONA1%TYPE,
'iFECHA_NACIMIENTO        IN T_PERSONA.FECHA_NACIMIENTO%TYPE,
'iSEXO_PERSONA            IN T_PERSONA.SEXO_PERSONA%TYPE,
'iNU_DOCU_SUNA            IN T_PERSONA.NU_DOCU_SUNA%TYPE,
'iNU_RETE_SUNA            IN T_PERSONA.NU_RETE_SUNA%TYPE,
'iIDTIPO_DOC_IDENTIDAD    IN T_PERSONA.IDTIPO_DOC_IDENTIDAD%TYPE,
'iIDTIPO_PERSONA          IN T_PERSONA.IDTIPO_PERSONA%TYPE,
'iIDRUBRO                 IN T_PERSONA.IDRUBRO%TYPE,
'iIDESTADO_REGISTRO       IN T_PERSONA.IDESTADO_REGISTRO%TYPE,
'iIDCLASIFICACION_PERSONA IN T_PERSONA.IDCLASIFICACION_PERSONA%TYPE,
'iIP                      IN T_PERSONA.IP%TYPE,
'iIDUSUARIO_PERSONAL      IN T_PERSONA.IDUSUARIO_PERSONAL%TYPE,
'iIDROL_USUARIO           IN T_PERSONA.IDROL_USUARIO%TYPE,
'iIDDISTRITO              IN T_PERSONA.IDDISTRITO%TYPE,
'iIDPROVINCIA             IN T_PERSONA.IDPROVINCIA%TYPE,
'iIDDEPARTAMENTO          IN T_PERSONA.IDDEPARTAMENTO%TYPE,
'iIDPAIS                  IN T_PERSONA.IDPAIS%TYPE,
'iESMENOREDAD             IN T_PERSONA.ESMENOREDAD%TYPE,
'iAGENTE_RETENCION        IN T_PERSONA.AGENTE_RETENCION%TYPE,
'oERR                   OUT INTEGER,
'oERR_MSG               OUT VARCHAR2,
'oCONFIRMA              OUT VARCHAR2  
#End Region
''' <summary>
''' Data Transformation Object para el mantenimiento de Clientes.
''' </summary>
''' <remarks></remarks>
Public Class dtoCLIENTES

#Region " DECLARACION DE VARIABLES "
    Private MyControl As Integer
    Private MyIDPersona As Integer
    Private sMyIDPersona As String
    Private MyClienteCorporativo As Integer
    Private MyRepresentanteLegal As String
    Private MyGerenteGeneral As String
    Private MyRazonSocial As String
    Private MyCodigoCliente As String
    Private MyFechaIngreso As String
    Private MyPagoPostfacturacion As Integer
    Private MyEmail As String
    Private MyApellidoPaterno As String
    Private MyApellidoMaterno As String
    Private MyNombreP As String
    Private MyNombreS As String
    Private MyFechaNacimiento As String
    Private MySexoPersona As String
    Private MyNuDoctoSunat As String
    Private MyNuRetenSunat As String
    Private MyTipoDoctoIdentidad As Integer
    Private MyTipoPersona As Integer
    Private MyIDRubro As Integer
    Private MyEstadoRegistro As Integer
    Private MyClasificacionPersona As Integer
    Private MyIP As String
    Private MyUsuarioPersonal As Integer
    Private MyIDRolUsuario As Integer
    Private MyIDDistrito As Integer
    Private MyIDProvincia As Integer
    Private MyIDDepartamento As Integer
    Private MyIDPais As Integer
    Private MyEsMenorEdad As Integer
    Private MyAgenteRetencion As Integer
    'Por definir en un Recordset llenado desde oracle por un Cursor.
    Private MyErr As Integer
    Private MyErrMsg As String
    Private MyConfirma As String

    Private MyTipoFacturacion As Integer
    Private MyMontoBase As Integer
    Private Mytipocredito As Integer

#End Region

#Region " DECLARACION DE LAS PROPIEDADES "
    Private iId As Integer
    Public Property Id() As Integer
        Get
            Return iid
        End Get
        Set(ByVal value As Integer)
            iid = value
        End Set
    End Property

    Private iCliente As Integer
    Public Property Cliente() As Integer
        Get
            Return iCliente
        End Get
        Set(ByVal value As Integer)
            iCliente = value
        End Set
    End Property

    Private sCodigo As String
    Public Property Codigo() As String
        Get
            Return sCodigo
        End Get
        Set(ByVal value As String)
            sCodigo = value
        End Set
    End Property

    Private sNombre As String
    Public Property Nombre() As String
        Get
            Return sNombre
        End Get
        Set(ByVal value As String)
            sNombre = value
        End Set
    End Property

    Private sTelefonoCliente As String
    Public Property TelefonoCliente() As String
        Get
            Return sTelefonoCliente
        End Get
        Set(ByVal value As String)
            sTelefonoCliente = value
        End Set
    End Property

    Private sFax As String
    Public Property Fax() As String
        Get
            Return sFax
        End Get
        Set(ByVal value As String)
            sFax = value
        End Set
    End Property

    Private sEmailRepresentante As String
    Public Property EmailRepresentante() As String
        Get
            Return sEmailRepresentante
        End Get
        Set(ByVal value As String)
            sEmailRepresentante = value
        End Set
    End Property

    Private sTelefonoRepresentante As String
    Public Property TelefonoRepresentante() As String
        Get
            Return sTelefonoRepresentante
        End Get
        Set(ByVal value As String)
            sTelefonoRepresentante = value
        End Set
    End Property

    Private sMovilRepresentante As String
    Public Property MovilRepresentante() As String
        Get
            Return sMovilRepresentante
        End Get
        Set(ByVal value As String)
            sMovilRepresentante = value
        End Set
    End Property

    Private sEncargado As String
    Public Property Encargado() As String
        Get
            Return sEncargado
        End Get
        Set(ByVal value As String)
            sEncargado = value
        End Set
    End Property

    Private sEmailEncargado As String
    Public Property EmailEncargado() As String
        Get
            Return sEmailEncargado
        End Get
        Set(ByVal value As String)
            sEmailEncargado = value
        End Set
    End Property


    Private sTelefonoEncargado As String
    Public Property TelefonoEncargado() As String
        Get
            Return sTelefonoEncargado
        End Get
        Set(ByVal value As String)
            sTelefonoEncargado = value
        End Set
    End Property

    Private sMovilEncargado As String
    Public Property MovilEncargado() As String
        Get
            Return sMovilEncargado
        End Get
        Set(ByVal value As String)
            sMovilEncargado = value
        End Set
    End Property

    Private iEstado As Integer
    Public Property Estado() As Integer
        Get
            Return iEstado
        End Get
        Set(ByVal value As Integer)
            iEstado = value
        End Set
    End Property
    Private iMontoSolicitado As Double
    Public Property MontoSolicitado() As Double
        Get
            Return iMontoSolicitado
        End Get
        Set(ByVal value As Double)
            iMontoSolicitado = value
        End Set
    End Property

    Private sFecha As String
    Public Property Fecha() As String
        Get
            Return sFecha
        End Get
        Set(ByVal value As String)
            sFecha = value
        End Set
    End Property

    Private iPeriodoPago As Integer
    Public Property PeriodoPago() As Integer
        Get
            Return iPeriodoPago
        End Get
        Set(ByVal value As Integer)
            iPeriodoPago = value
        End Set
    End Property
    Private sDiaPago As String
    Public Property DiaPago() As String
        Get
            Return sDiaPago
        End Get
        Set(ByVal value As String)
            sDiaPago = value
        End Set
    End Property
    Private sFecha1 As String
    Public Property Fecha1() As String
        Get
            Return sFecha1
        End Get
        Set(ByVal value As String)
            sFecha1 = value
        End Set
    End Property
    Private sFecha2 As String
    Public Property Fecha2() As String
        Get
            Return sFecha2
        End Get
        Set(ByVal value As String)
            sFecha2 = value
        End Set
    End Property
    Private sFecha3 As String
    Public Property Fecha3() As String
        Get
            Return sFecha3
        End Get
        Set(ByVal value As String)
            sFecha3 = value
        End Set
    End Property
    Private sFecha4 As String
    Public Property Fecha4() As String
        Get
            Return sFecha4
        End Get
        Set(ByVal value As String)
            sFecha4 = value
        End Set
    End Property
    Private sHorarioPagoInicio As String
    Public Property HorarioPagoInicio() As String
        Get
            Return sHorarioPagoInicio
        End Get
        Set(ByVal value As String)
            sHorarioPagoInicio = value
        End Set
    End Property
    Private sHorarioPagoFin As String
    Public Property HorarioPagoFin() As String
        Get
            Return sHorarioPagoFin
        End Get
        Set(ByVal value As String)
            sHorarioPagoFin = value
        End Set
    End Property
    Private iDia1 As Byte
    Public Property Dia1() As Byte
        Get
            Return iDia1
        End Get
        Set(ByVal value As Byte)
            iDia1 = value
        End Set
    End Property
    Private iDia2 As Byte
    Public Property Dia2() As Byte
        Get
            Return iDia2
        End Get
        Set(ByVal value As Byte)
            iDia2 = value
        End Set
    End Property
    Private iDia3 As Byte
    Public Property Dia3() As Byte
        Get
            Return iDia3
        End Get
        Set(ByVal value As Byte)
            iDia3 = value
        End Set
    End Property
    Private iDia4 As Byte
    Public Property Dia4() As Byte
        Get
            Return iDia4
        End Get
        Set(ByVal value As Byte)
            iDia4 = value
        End Set
    End Property
    Private iDia5 As Byte
    Public Property Dia5() As Byte
        Get
            Return iDia5
        End Get
        Set(ByVal value As Byte)
            iDia5 = value
        End Set
    End Property
    Private iDia6 As Byte
    Public Property Dia6() As Byte
        Get
            Return iDia6
        End Get
        Set(ByVal value As Byte)
            iDia6 = value
        End Set
    End Property
    Private iDia7 As Byte
    Public Property Dia7() As Byte
        Get
            Return iDia7
        End Get
        Set(ByVal value As Byte)
            iDia7 = value
        End Set
    End Property
    Private sEmailContacto As String
    Public Property EmailContacto() As String
        Get
            Return sEmailContacto
        End Get
        Set(ByVal value As String)
            sEmailContacto = value
        End Set
    End Property

    Private sTelefonoContacto As String
    Public Property TelefonoContacto() As String
        Get
            Return sTelefonoContacto
        End Get
        Set(ByVal value As String)
            sTelefonoContacto = value
        End Set
    End Property

    Private sMovilContacto As String
    Public Property MovilContacto() As String
        Get
            Return sMovilContacto
        End Get
        Set(ByVal value As String)
            sMovilContacto = value
        End Set
    End Property

    Private iContacto As Integer
    Public Property Contacto() As Integer
        Get
            Return iContacto
        End Get
        Set(ByVal value As Integer)
            iContacto = value
        End Set
    End Property

    Function Clientes() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_1", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

    Public Property _MyMontoBase() As Integer
        Get
            Return MyMontoBase
        End Get
        Set(ByVal value As Integer)
            MyMontoBase = value
        End Set
    End Property

    Public Property _MyControl() As Integer
        Get
            Return MyControl
        End Get
        Set(ByVal value As Integer)
            MyControl = value
        End Set
    End Property

    Public Property s_MyIDPersona() As String
        Get
            Return sMyIDPersona
        End Get
        Set(ByVal value As String)
            sMyIDPersona = value
        End Set
    End Property
    Public Property _MyIDPersona() As Integer
        Get
            Return MyIDPersona
        End Get
        Set(ByVal value As Integer)
            MyIDPersona = value
        End Set
    End Property

    Public Property _MyClienteCorporativo() As Integer
        Get
            Return MyClienteCorporativo
        End Get
        Set(ByVal value As Integer)
            MyClienteCorporativo = value
        End Set
    End Property

    Public Property _MyRepresentanteLegal() As String
        Get
            Return MyRepresentanteLegal
        End Get
        Set(ByVal value As String)
            MyRepresentanteLegal = value
        End Set
    End Property

    Public Property _MyGerenteGeneral() As String
        Get
            Return MyGerenteGeneral
        End Get
        Set(ByVal value As String)
            MyGerenteGeneral = value
        End Set
    End Property

    Public Property _MyRazonSocial() As String
        Get
            Return MyRazonSocial
        End Get
        Set(ByVal value As String)
            MyRazonSocial = value
        End Set
    End Property

    Public Property _MyCodigoCliente() As String
        Get
            Return MyCodigoCliente
        End Get
        Set(ByVal value As String)
            MyCodigoCliente = value
        End Set
    End Property

    Public Property _MyFechaIngreso() As String
        Get
            Return MyFechaIngreso
        End Get
        Set(ByVal value As String)
            MyFechaIngreso = value
        End Set
    End Property

    Public Property _MyPagoPostfacturacion() As Integer
        Get
            Return MyPagoPostfacturacion
        End Get
        Set(ByVal value As Integer)
            MyPagoPostfacturacion = value
        End Set
    End Property

    Public Property _MyEmail() As String
        Get
            Return MyEmail
        End Get
        Set(ByVal value As String)
            MyEmail = value
        End Set
    End Property

    Public Property _MyApellidoPaterno() As String
        Get
            Return MyApellidoPaterno
        End Get
        Set(ByVal value As String)
            MyApellidoPaterno = value
        End Set
    End Property

    Public Property _MyApellidoMaterno() As String
        Get
            Return MyApellidoMaterno
        End Get
        Set(ByVal value As String)
            MyApellidoMaterno = value
        End Set
    End Property

    Public Property _MyNombreP() As String
        Get
            Return MyNombreP
        End Get
        Set(ByVal value As String)
            MyNombreP = value
        End Set
    End Property

    Public Property _MyNombreS() As String
        Get
            Return MyNombreS
        End Get
        Set(ByVal value As String)
            MyNombreS = value
        End Set
    End Property

    Public Property _MyFechaNacimiento() As String
        Get
            Return MyFechaNacimiento
        End Get
        Set(ByVal value As String)
            MyFechaNacimiento = value
        End Set
    End Property

    Public Property _MySexoPersona() As String
        Get
            Return MySexoPersona
        End Get
        Set(ByVal value As String)
            MySexoPersona = value
        End Set
    End Property

    Public Property _MyNuDoctoSunat() As String
        Get
            Return MyNuDoctoSunat
        End Get
        Set(ByVal value As String)
            MyNuDoctoSunat = value
        End Set
    End Property

    Public Property _MyNuRetenSunat() As String
        Get
            Return MyNuRetenSunat
        End Get
        Set(ByVal value As String)
            MyNuRetenSunat = value
        End Set
    End Property

    Public Property _MyTipoDoctoIdentidad() As String
        Get
            Return MyTipoDoctoIdentidad
        End Get
        Set(ByVal value As String)
            MyTipoDoctoIdentidad = value
        End Set
    End Property

    Public Property _MyTipoPersona() As Integer
        Get
            Return MyTipoPersona
        End Get
        Set(ByVal value As Integer)
            MyTipoPersona = value
        End Set
    End Property

    Public Property _MyIDRubro() As Integer
        Get
            Return MyIDRubro
        End Get
        Set(ByVal value As Integer)
            MyIDRubro = value
        End Set
    End Property

    Public Property _MyEstadoRegistro() As Integer
        Get
            Return MyEstadoRegistro
        End Get
        Set(ByVal value As Integer)
            MyEstadoRegistro = value
        End Set
    End Property

    Public Property _MyClasificacionPersona() As Integer
        Get
            Return MyClasificacionPersona
        End Get
        Set(ByVal value As Integer)
            MyClasificacionPersona = value
        End Set
    End Property

    Public Property _MyIP() As String
        Get
            Return MyIP
        End Get
        Set(ByVal value As String)
            MyIP = value
        End Set
    End Property

    Public Property _MyUsuarioPersonal() As Integer
        Get
            Return MyUsuarioPersonal
        End Get
        Set(ByVal value As Integer)
            MyUsuarioPersonal = value
        End Set
    End Property

    Public Property _MyIDRolUsuario() As Integer
        Get
            Return MyIDRolUsuario
        End Get
        Set(ByVal value As Integer)
            MyIDRolUsuario = value
        End Set
    End Property

    Public Property _MyIDDistrito() As Integer
        Get
            Return MyIDDistrito
        End Get
        Set(ByVal value As Integer)
            MyIDDistrito = value
        End Set
    End Property

    Public Property _MyIDProvincia() As Integer
        Get
            Return MyIDProvincia
        End Get
        Set(ByVal value As Integer)
            MyIDProvincia = value
        End Set
    End Property

    Public Property _MyIDDepartamento() As Integer
        Get
            Return MyIDDepartamento
        End Get
        Set(ByVal value As Integer)
            MyIDDepartamento = value
        End Set
    End Property

    Public Property _MyIDPais() As Integer
        Get
            Return MyIDPais
        End Get
        Set(ByVal value As Integer)
            MyIDPais = value
        End Set
    End Property

    Public Property _MyEsMenorEdad() As Integer
        Get
            Return MyEsMenorEdad
        End Get
        Set(ByVal value As Integer)
            MyEsMenorEdad = value
        End Set
    End Property

    Public Property _MyAgenteRetencion() As Integer
        Get
            Return MyAgenteRetencion
        End Get
        Set(ByVal value As Integer)
            MyAgenteRetencion = value
        End Set
    End Property

    Public Property _MyTipoFacturacion() As Integer
        Get
            Return MyTipoFacturacion
        End Get
        Set(ByVal value As Integer)
            MyTipoFacturacion = value
        End Set
    End Property
    Public Property _Mytipocredito() As Integer
        Get
            Return Mytipocredito
        End Get
        Set(ByVal value As Integer)
            Mytipocredito = value
        End Set
    End Property

#End Region

#Region " FUNCIONES UTILIZADAS "

#Region " Comparacion de Valores "
    'MessageBox.Show(Me.MyControl, "MyControl")
    'MessageBox.Show(Me.MyIDPersona, "MyIDPersona")
    'MessageBox.Show(Me.MyTipoPersona, "MyTipoPersona")
    'MessageBox.Show(Me.MyCodigoCliente, "MyCodigoCliente")
    'MessageBox.Show(Me.MyClienteCorporativo, "MyClienteCorporativo")
    'MessageBox.Show(Me.MyRazonSocial, "MyRazonSocial")
    'MessageBox.Show(Me.MyGerenteGeneral, "MyGerenteGeneral")
    'MessageBox.Show(Me.MyRepresentanteLegal, "MyRepresentanteLegal")
    'MessageBox.Show(Me.MyFechaIngreso, "MyFechaIngreso")
    'MessageBox.Show(Me.MyPagoPostfacturacion, "MyPagoPostfacturacion")
    'MessageBox.Show(Me.MyEmail, "MyEmail")
    'MessageBox.Show(Me.MyAgenteRetencion, "MyAgenteRetencion")
    'MessageBox.Show(Me.MyTipoDoctoIdentidad, "MyTipoDoctoIdentidad")
    'MessageBox.Show(Me.MyNuDoctoSunat, "MyNuDoctoSunat")
    'MessageBox.Show(Me.MyNuRetenSunat, "MyNuRetenSunat")
    'MessageBox.Show(Me.MyIDRubro, "MyIDRubro")
    'MessageBox.Show(Me.MyClasificacionPersona, "MyClasificacionPersona")
    'MessageBox.Show(Me.MyEstadoRegistro, "MyEstadoRegistro")
    'MessageBox.Show(Me.MyUsuarioPersonal, "MyUsuarioPersonal")
    'MessageBox.Show(Me.MyIDRolUsuario, "MyIDRolUsuario")
    'MessageBox.Show(Me.MyIP, "MyIP")
    'MessageBox.Show(Me.MyIDPais, "MyIDPais")
    'MessageBox.Show(Me.MyIDDepartamento, "MyIDDepartamento")
    'MessageBox.Show(Me.MyIDProvincia, "MyIDProvincia")
    'MessageBox.Show(Me.MyIDDistrito, "MyIDDistrito")

    'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_JURIDICA", 60, _
    '2, 1, _
    '69, 1, _
    '1, 1, _
    '"A12121", 2, _
    '1, 1, _
    '"BIZSOLUTIONS II", 2, _
    '"richard", 2, _
    '"EDUARDO", 2, _
    '"24/05/2006", 2, _
    '1, 1, _
    '"www", 2, _
    '1, 1, _
    '1, 1, _
    '"20101333940", 2, _
    '"212121", 2, _
    '2, 1, _
    '1, 1, _
    '1, 1, _
    '6, 1, _
    '2, 1, _
    '"192.168.50.47", 2, _
    '4, 1, _
    '15, 1, _
    '17, 1, _
    '5, 1}


    'MessageBox.Show(Me.MyControl, "MyControl")
    'MessageBox.Show(Me.MyIDPersona, "MyIDPersona")
    'MessageBox.Show(Me.MyTipoPersona, "MyTipoPersona")
    'MessageBox.Show(Me.MyCodigoCliente, "MyCodigoCliente")
    'MessageBox.Show(Me.MyFechaIngreso, "MyFechaIngreso")
    'MessageBox.Show(Me.MyPagoPostfacturacion, "MyPagoPostfacturacion")
    'MessageBox.Show(Me.MyEmail, "MyEmail")
    'MessageBox.Show(Me.MyApellidoPaterno, "MyApellidoPaterno")
    'MessageBox.Show(Me.MyApellidoMaterno, "MyApellidoMaterno")
    'MessageBox.Show(Me.MyNombreP, "MyNombreP")
    'MessageBox.Show(Me.MyNombreS, "MyNombreS")
    'MessageBox.Show(Me.MyFechaNacimiento, "MyFechaNacimiento")
    'MessageBox.Show(Me.MySexoPersona, "MySexoPersona")
    'MessageBox.Show(Me.MyEsMenorEdad, "MyEsMenorEdad")
    'MessageBox.Show(Me.MyAgenteRetencion, "MyAgenteRetencion")
    'MessageBox.Show(Me.MyTipoDoctoIdentidad, "MyTipoDoctoIdentidad")
    'MessageBox.Show(Me.MyNuDoctoSunat, "MyNuDoctoSunat")
    'MessageBox.Show(Me.MyNuRetenSunat, "MyNuRetenSunat")
    'MessageBox.Show(Me.MyIDRubro, "MyIDRubro")
    'MessageBox.Show(Me.MyClasificacionPersona, "MyClasificacionPersona")
    'MessageBox.Show(Me.MyEstadoRegistro, "MyEstadoRegistro")
    'MessageBox.Show(Me.MyUsuarioPersonal, "MyUsuarioPersonal")
    'MessageBox.Show(Me.MyIDRolUsuario, "MyIDRolUsuario")
    'MessageBox.Show(Me.MyIP, "MyIP")
    'MessageBox.Show(Me.MyIDPais, "MyIDPais")
    'MessageBox.Show(Me.MyIDDepartamento, "MyIDDepartamento")
    'MessageBox.Show(Me.MyIDProvincia, "MyIDProvincia")
    'MessageBox.Show(Me.MyIDDistrito, "MyIDDistrito")

#End Region
    ''' <summary>
    ''' Esta funcion graba nuevos registros de Personas Juridicas en la Base de datos a partir 
    ''' de los valores de la clase.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function GrabaClienteJuridico2009() As ADODB.Recordset
    '    'MessageBox.Show(MyControl, "MyControl")
    '    ' Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_JURIDICA", 54, _        
    '    ' MyIDPersona, 1, _ modificado 14/03/2008 ->  Pasando el parametro del ado 
    '    'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_JURIDICA_3", 54, _
    '    'hlamas
    '    'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_JURIDICA_3", 54, _
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_JURIDICA_4", 56, _
    '    MyControl, 1, _
    '    CType(MyIDPersona, String), 2, _
    '    MyTipoPersona, 1, _
    '    MyCodigoCliente, 2, _
    '    MyClienteCorporativo, 1, _
    '    MyRazonSocial, 2, _
    '    MyGerenteGeneral, 2, _
    '    MyRepresentanteLegal, 2, _
    '    MyFechaIngreso, 2, _
    '    MyPagoPostfacturacion, 1, _
    '    MyEmail, 2, _
    '    MyAgenteRetencion, 1, _
    '    MyTipoDoctoIdentidad, 1, _
    '    MyNuDoctoSunat, 2, _
    '    MyNuRetenSunat, 2, _
    '    MyIDRubro, 1, _
    '    MyClasificacionPersona, 1, _
    '    MyEstadoRegistro, 1, _
    '    MyUsuarioPersonal, 1, _
    '    MyIDRolUsuario, 1, _
    '    MyIP, 2, _
    '    MyIDPais, 1, _
    '    MyIDDepartamento, 1, _
    '    MyIDProvincia, 1, _
    '    MyIDDistrito, 1, _
    '    MyTipoFacturacion, 1, _
    '    MyMontoBase, 1}
    '    '
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    '    '
    'End Function
    ''' <summary>
    ''' Esta funcion graba nuevos registros de Personas Naturales en la Base de datos 
    ''' a partir de valores de la clase.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Function GrabaClienteNatural2009() As ADODB.Recordset
    '    Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_NATURAL_2", 62, _
    '    MyControl, 1, _
    '    CType(MyIDPersona, String), 2, _
    '    MyTipoPersona, 1, _
    '    MyCodigoCliente, 2, _
    '    MyFechaIngreso, 2, _
    '    MyPagoPostfacturacion, 1, _
    '    MyEmail, 2, _
    '    MyApellidoPaterno, 2, _
    '    MyApellidoMaterno, 2, _
    '    MyNombreP, 2, _
    '    MyNombreS, 2, _
    '    MyFechaNacimiento, 2, _
    '    MySexoPersona, 2, _
    '    MyEsMenorEdad, 1, _
    '    MyAgenteRetencion, 1, _
    '    MyTipoDoctoIdentidad, 1, _
    '    MyNuDoctoSunat, 2, _
    '    MyNuRetenSunat, 2, _
    '    MyIDRubro, 1, _
    '    MyClasificacionPersona, 1, _
    '    MyEstadoRegistro, 1, _
    '    MyUsuarioPersonal, 1, _
    '    MyIDRolUsuario, 1, _
    '    MyIP, 2, _
    '    MyIDPais, 1, _
    '    MyIDDepartamento, 1, _
    '    MyIDProvincia, 1, _
    '    MyIDDistrito, 1, _
    '    MyTipoFacturacion, 1, _
    '    MyMontoBase, 1}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    'End Function
    'Public Function fn_grabadatos_adicional2009()
    '    Dim MyObj_act_datosadicional As Object() = {"PKG_IVOPERSONA.sp_act_datos_adicionales", 36, _
    '                                                                        sMyIDPersona, 2, _
    '                                                                        MyCodigoCliente, 2, _
    '                                                                        MyRazonSocial, 2, _
    '                                                                        MyGerenteGeneral, 2, _
    '                                                                        MyRepresentanteLegal, 2, _
    '                                                                        MyPagoPostfacturacion, 1, _
    '                                                                        MyAgenteRetencion, 1, _
    '                                                                        MyIDRubro, 1, _
    '                                                                        MyClienteCorporativo, 1, _
    '                                                                        MyClasificacionPersona, 1, _
    '                                                                        MyIDPais, 1, _
    '                                                                        MyIDDepartamento, 1, _
    '                                                                        MyIDProvincia, 1, _
    '                                                                        MyIDDistrito, 1, _
    '                                                                        MyTipoFacturacion, 1, _
    '                                                                        MyUsuarioPersonal, 1, _
    '                                                                        MyIP, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObj_act_datosadicional)
    'End Function

    Public Function fn_grabadatos_adicional() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.sp_act_datos_adicionales", CommandType.StoredProcedure)
        db.AsignarParametro("vi_idpersona", sMyIDPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("vi_codigo_cliente", MyCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("vi_razon_social", MyRazonSocial, OracleClient.OracleType.VarChar)
        db.AsignarParametro("vi_gerente_general", MyGerenteGeneral, OracleClient.OracleType.VarChar)
        db.AsignarParametro("vi_representante_legal", MyRepresentanteLegal, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_pago_post_facturacion", MyPagoPostfacturacion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_agente_retencion", MyAgenteRetencion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_idrubro", MyIDRubro, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_cliente_corporativo", MyClienteCorporativo, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_idclasificacion_persona", MyClasificacionPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_idpais", MyIDPais, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_iddepartamento", MyIDDepartamento, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_idprovincia", MyIDProvincia, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_iddistrito", MyIDDistrito, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_idtipo_facturacion", MyTipoFacturacion, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ni_idusuario_personal", MyUsuarioPersonal, OracleClient.OracleType.VarChar)
        db.AsignarParametro("vi_ip", MyIP, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ocur_mensaje", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable
    End Function

#End Region
    Public Function GrabaClienteJuridico() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_JURIDICA_4", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_JURIDICA_5", CommandType.StoredProcedure)

            db.AsignarParametro("iCONTROL", MyControl, OracleClient.OracleType.Number)
            db.AsignarParametro("iIDPERSONA", MyIDPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_PERSONA", MyTipoPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCODIGO_CLIENTE", MyCodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCLIENTE_CORPORATIVO", MyClienteCorporativo, OracleClient.OracleType.Int32)
            db.AsignarParametro("iRAZON_SOCIAL", MyRazonSocial, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iGERENTE_GENERAL", MyGerenteGeneral, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iREPRESENTANTE_LEGAL", MyRepresentanteLegal, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iFECHA_INGRESO", MyFechaIngreso, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iPAGO_POST_FACTURACION", MyPagoPostfacturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iEMAIL", MyEmail, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iAGENTE_RETENCION", MyAgenteRetencion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_DOC_IDENTIDAD", MyTipoDoctoIdentidad, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNU_DOCU_SUNA", MyNuDoctoSunat, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iNU_RETE_SUNA", MyNuRetenSunat, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDRUBRO", MyIDRubro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCLASIFICACION_PERSONA", MyClasificacionPersona, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDESTADO_REGISTRO", MyEstadoRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", MyUsuarioPersonal, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", MyIDRolUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", MyIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDPAIS", MyIDPais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", MyIDDepartamento, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPROVINCIA", MyIDProvincia, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDISTRITO", MyIDDistrito, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDTIPO_FACTURACION", MyTipoFacturacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iMONTO_BASE", MyMontoBase, OracleClient.OracleType.Int32)
            '
            db.AsignarParametro("ni_tipo_credito", Mytipocredito, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
            '

            'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_JURIDICA_4", 56, _
            'MyControl, 1, _
            'CType(MyIDPersona, String), 2, _
            'MyTipoPersona, 1, _
            'MyCodigoCliente, 2, _
            'MyClienteCorporativo, 1, _
            'MyRazonSocial, 2, _
            'MyGerenteGeneral, 2, _
            'MyRepresentanteLegal, 2, _
            'MyFechaIngreso, 2, _
            'MyPagoPostfacturacion, 1, _
            'MyEmail, 2, _
            'MyAgenteRetencion, 1, _
            'MyTipoDoctoIdentidad, 1, _
            'MyNuDoctoSunat, 2, _
            'MyNuRetenSunat, 2, _
            'MyIDRubro, 1, _
            'MyClasificacionPersona, 1, _
            'MyEstadoRegistro, 1, _
            'MyUsuarioPersonal, 1, _
            'MyIDRolUsuario, 1, _
            'MyIP, 2, _
            'MyIDPais, 1, _
            'MyIDDepartamento, 1, _
            'MyIDProvincia, 1, _
            'MyIDDistrito, 1, _
            'MyTipoFacturacion, 1, _
            'MyMontoBase, 1}
            ''
            'Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
            ''
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function GrabaClienteNatural() As DataTable
        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_NATURAL_2", CommandType.StoredProcedure)

        db.AsignarParametro("iCONTROL", MyControl, OracleClient.OracleType.Number)
        db.AsignarParametro("viIDPERSONA", CType(MyIDPersona, String), OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDTIPO_PERSONA", MyTipoPersona, OracleClient.OracleType.Int32)
        db.AsignarParametro("iCODIGO_CLIENTE", MyCodigoCliente, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iFECHA_INGRESO", MyFechaIngreso, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iPAGO_POST_FACTURACION", MyPagoPostfacturacion, OracleClient.OracleType.Int32)
        db.AsignarParametro("iEMAIL", MyEmail, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iAPELLIDO_PATERNO", MyApellidoPaterno, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iAPELLIDO_MATERNO", MyApellidoMaterno, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iNOMPRE_PERSONA", MyNombreP, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iNOMPRE_PERSONA1", MyNombreS, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iFECHA_NACIMIENTO", MyFechaNacimiento, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iSEXO_PERSONA", MySexoPersona, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iESMENOREDAD", MyEsMenorEdad, OracleClient.OracleType.Int32)
        db.AsignarParametro("iAGENTE_RETENCION", MyAgenteRetencion, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDTIPO_DOC_IDENTIDAD", MyTipoDoctoIdentidad, OracleClient.OracleType.Int32)
        db.AsignarParametro("iNU_DOCU_SUNA", MyNuDoctoSunat, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iNU_RETE_SUNA", MyNuRetenSunat, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDRUBRO", MyIDRubro, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDCLASIFICACION_PERSONA", MyClasificacionPersona, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDESTADO_REGISTRO", MyEstadoRegistro, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDUSUARIO_PERSONAL", MyUsuarioPersonal, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDROL_USUARIO", MyIDRolUsuario, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIP", MyIP, OracleClient.OracleType.VarChar)
        db.AsignarParametro("iIDPAIS", MyIDPais, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDEPARTAMENTO", MyIDDepartamento, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDPROVINCIA", MyIDProvincia, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDDISTRITO", MyIDDistrito, OracleClient.OracleType.Int32)
        db.AsignarParametro("iIDTIPO_FACTURACION", MyTipoFacturacion, OracleClient.OracleType.Int32)
        db.AsignarParametro("iMONTO_BASE", MyMontoBase, OracleClient.OracleType.Int32)
        db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)

        db.Desconectar()
        Return db.EjecutarDataTable

        'Dim MyObjeGrabar As Object() = {"PKG_IVOPERSONA.SP_INSUPD_NATURAL_2", 62, _
        'MyControl, 1, _
        'CType(MyIDPersona, String), 2, _
        'MyTipoPersona, 1, _
        'MyCodigoCliente, 2, _
        'MyFechaIngreso, 2, _
        'MyPagoPostfacturacion, 1, _
        'MyEmail, 2, _
        'MyApellidoPaterno, 2, _
        'MyApellidoMaterno, 2, _
        'MyNombreP, 2, _
        'MyNombreS, 2, _
        'MyFechaNacimiento, 2, _
        'MySexoPersona, 2, _
        'MyEsMenorEdad, 1, _
        'MyAgenteRetencion, 1, _
        'MyTipoDoctoIdentidad, 1, _
        'MyNuDoctoSunat, 2, _
        'MyNuRetenSunat, 2, _
        'MyIDRubro, 1, _
        'MyClasificacionPersona, 1, _
        'MyEstadoRegistro, 1, _
        'MyUsuarioPersonal, 1, _
        'MyIDRolUsuario, 1, _
        'MyIP, 2, _
        'MyIDPais, 1, _
        'MyIDDepartamento, 1, _
        'MyIDProvincia, 1, _
        'MyIDDistrito, 1, _
        'MyTipoFacturacion, 1, _
        'MyMontoBase, 1}
        'Return VOCONTROLUSUARIO.fnSQLQuery(MyObjeGrabar)
    End Function
    'Public Function fn_getdatos_adicional2009() As ADODB.Recordset
    '    '
    '    Dim MyObjdatosadicional As Object() = {"PKG_IVOPERSONA.sp_get_datos_adicional", 4, _
    '                                                                       MyNuDoctoSunat, 2}
    '    Return VOCONTROLUSUARIO.fnSQLQuery(MyObjdatosadicional)
    '    '
    'End Function

    Public Function fn_getdatos_adicional() As DataTable

        Dim db As New BaseDatos

        db.Conectar()
        db.CrearComando("PKG_IVOPERSONA.sp_get_datos_adicional", CommandType.StoredProcedure)
        db.AsignarParametro("vi_nu_docu_suna", MyNuDoctoSunat, OracleClient.OracleType.VarChar)
        db.AsignarParametro("ocur_datos_adicional", OracleClient.OracleType.Cursor)
        db.Desconectar()
        Return db.EjecutarDataTable

        'Dim MyObjdatosadicional As Object() = {"PKG_IVOPERSONA.sp_get_datos_adicional", 4, _
        '                                                                   MyNuDoctoSunat, 2}
        'Return VOCONTROLUSUARIO.fnSQLQuery(MyObjdatosadicional)

    End Function

    Public Function fn_clientes_funcionario(ByVal myFuncionario As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLIENTES_FUNCIONARIO_", CommandType.StoredProcedure)
            db.AsignarParametro("iNOMBRE_FUNCIONARIO", myFuncionario, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_LISTA_CLIENTES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_upd_monto_base(ByVal iId As String, ByVal iMontoBase As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_upd_monto_base", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", iId, OracleClient.OracleType.VarChar)
            db.AsignarParametro("base", iMontoBase, OracleClient.OracleType.Int32)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function
    Public Function fn_lista_funcionarios() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'db.CrearComando("PKG_IVOPERSONA.SP_LISTAFUNCIONARIO", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.SP_LISTAFUNCIONARIO_1", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_lista_funcionarios_pasa() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTAFUNCIONARIO_PASA", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_LISTA_CLASIFICACION_PERSONA() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CLASIFICACION_PERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_CLAS_PERSONA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_ISNUPD_CLASFPERSONA(ByVal vAccionRegistro As Integer, ByVal clasificacion As Integer, ByVal rubro As String, ByVal MyUsuario As Integer, ByVal MyRol As Integer, ByVal MyIP As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_ISNUPD_CLASFPERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDCLASIFICACION_PERSONA", clasificacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("iCLASIFICACION_PERSONA", rubro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", MyUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", MyRol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", MyIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_RUBRO", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_carga_direcciones(ByVal MyCodigoCliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CARGA_DIRECCIONES", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGO_CLIENTE", MyCodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_DIRECCIONES", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_LISTA_CONTACTOS_1(ByVal codigo As String, ByVal direccion As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CONTACTOS_1", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGO_CLIENTE", codigo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDDIRECCION_CONSIGNADO", direccion, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCUR_LISTACONTACTOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_Excel() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            'hlamas 06-01-2014
            'db.CrearComando("PKG_IVOPERSONA.sp_get_cliente_x_funcionario", CommandType.StoredProcedure)
            db.CrearComando("PKG_IVOPERSONA.sp_get_cliente_x_fun_car", CommandType.StoredProcedure)
            db.AsignarParametro("ocur_cliente", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_COMBOSPERSONA() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_COMBOSPERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_TIPOPERSONA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPODOCTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_RUBRO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_CLASPERSONA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PAIS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DEPTOS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_PROVINCIA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_DISTRITO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPOCONTACTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_AREAEMPRESA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPOCOMUNICACION", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_COMUNICACIONCONTAC", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_ROLESCARGA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_USUARIOSCARGA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_LISTAPERSONAS", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_IDPERSONA", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPODIRECCION", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function fn_GRILLA_TELEFONOS() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_GRILLA_TELEFONOS", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_COMUNICACIONCONTAC", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPOCOMUNICACION", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_LISTACONTACTO(ByVal scodigo_cliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTACONTACTO", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOCLIENTE", scodigo_cliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTACTOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_LISTATELEFONOCONTACTO(ByVal idcontacto As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTATELEFONOCONTACTO", CommandType.StoredProcedure)
            db.AsignarParametro("iIDCONTACTO_PERSONA", idcontacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oTIPOCOMUNICACION", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_COMUNICACION", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_existe_rol(ByVal MyUsuario As Integer, ByVal rol As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_existe_rol", CommandType.StoredProcedure)
            db.AsignarParametro("usuario", MyUsuario, OracleClient.OracleType.Number)
            db.AsignarParametro("rol", rol, OracleClient.OracleType.Number)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function fn_linea_credito(ByVal iId As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_linea_credito", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", iId, OracleClient.OracleType.VarChar)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function LISTA_CONTACTOS(ByVal MyCodigoCliente As String) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_CONTACTOS", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGO_CLIENTE", MyCodigoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iCUR_LISTACONTACTOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function CANCELA_INS_PERSONA(ByVal CodigoCliente As String)
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CANCELA_INS_PERSONA", CommandType.StoredProcedure)
            db.AsignarParametro("iMY_CODIGO_PERSONA", CodigoCliente, OracleClient.OracleType.VarChar)
            db.EjecutarComando()
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        Finally
            db.Desconectar()
        End Try
    End Function

    Public Function INACTIVA_CTACTE(ByVal codigo As String, ByVal usuario As Integer, ByVal rol As Integer, ByVal ip As String, ByVal aprobacion As Integer) As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INACTIVA_CTACTE", CommandType.StoredProcedure)
            db.AsignarParametro("iCODIGOPERSONA", codigo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", usuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", MyRol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", ip, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDCONFIG_CTACTE", aprobacion, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCURSOR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function upd_descuento(ByVal iId As String, ByVal iDescuento As String)
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("sp_upd_descuento", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", iId, OracleClient.OracleType.Number)
            db.AsignarParametro("descuento", iDescuento, OracleClient.OracleType.Number)
            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function INSUPD_DEPARTAMENTO(ByVal fact As Integer, ByVal dep1 As String, ByVal pais As Integer, ByVal dep2 As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DEPARTAMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", Fact, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", CType(dep1, Integer), OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPAIS", pais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iDEPARTAMENTO", dep2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function INSUPD_PROVINCIA(ByVal fact As Integer, ByVal pro1 As String, ByVal dep As Integer, ByVal pais As Integer, ByVal pro2 As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_PROVINCIA", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", fact, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPROVINCIA", CType(pro1, Integer), OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", dep, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPAIS", pais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iPROVINCIA", pro2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function INSUPD_DISTRITO(ByVal fact As Integer, ByVal dis1 As String, ByVal prov As Integer, ByVal dep As Integer, ByVal pais As Integer, ByVal dis2 As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_DISTRITO", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", fact, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDISTRITO", CType(dis1, Integer), OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPROVINCIA", prov, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDDEPARTAMENTO", dep, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDPAIS", pais, OracleClient.OracleType.Int32)
            db.AsignarParametro("iDISTRITO", dis2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function LISTA_TIPO_DIRECCION() As DataTable
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_TIPO_DIRECCION", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_TIPO_DIRECCION", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function INSUPD_TIPO_DIRECCION(ByVal vAccionRegistro As Integer, ByVal rubro As String) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_TIPO_DIRECCION", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iTIPO_DIRECCION", rubro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_LISTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function LISTA_TIPO_DOCUMENTO() As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_LISTA_TIPO_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_TIPO_DOCUMENTO", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_TIPO_PERSONA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Public Function INSUPD_TIPO_DOCUMENTO(ByVal vAccionRegistro As Integer, ByVal rubro As String, ByVal MyUsuario As Integer, ByVal MyRol As Integer, ByVal MyIP As String, ByVal tipo As Integer) As DataSet
        Try
            Dim db As New BaseDatos
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_TIPO_DOCUMENTO", CommandType.StoredProcedure)
            db.AsignarParametro("iCONTROL", vAccionRegistro, OracleClient.OracleType.Int32)
            db.AsignarParametro("iNOMBRE_DOCUMENTO", rubro, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDUSUARIO_PERSONAL", MyUsuario, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIDROL_USUARIO", MyRol, OracleClient.OracleType.Int32)
            db.AsignarParametro("iIP", MyIP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("iIDTIPO_PERSONA", tipo, OracleClient.OracleType.Int32)
            db.AsignarParametro("oCUR_CONTROL", OracleClient.OracleType.Cursor)
            db.AsignarParametro("oCUR_LISTA", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet
        Catch ex As Excepcion
            Throw New Exception(ex.Excepcion)
        End Try
    End Function

    Function Funcionarios() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_FUNCIONARIOS_1", CommandType.StoredProcedure)
            db.AsignarParametro("oCUR_FUNCIONARIOS", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function
    Function CondicionPago() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CONDICION_PAGO", CommandType.StoredProcedure)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

    Function Solicitud(ByVal cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_SOLICITUD_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("NI_IDPERSONA", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

    Function VerificaSolicitud(ByVal cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_VALIDA_SOLICITUD_CREDITO", CommandType.StoredProcedure)
            db.AsignarParametro("P_IdPersona", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

    Function ContactoComercial() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CONTACTO_COMERCIAL", CommandType.StoredProcedure)
            db.AsignarParametro("ni_idpersona", iCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

    Function Grabar(ByVal opcion As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_INSUPD_SOLICITUD_CREDITO_1", CommandType.StoredProcedure)
            db.AsignarParametro("ni_opcion", opcion, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDSOLICITUD_CREDITO", Id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_idpersona", iCliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_CODIGO_PERSONA", sCodigo, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_NOMBRE_PERSONA", sNombre, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_TELEFONO_DIRECCION", sTelefonoCliente, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_FAX_DIRECCION", sFax, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_EMAIL_REP_LEGAL", sEmailRepresentante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_TELEFONO_REP_LEGAL", sTelefonoRepresentante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_MOVIL_REP_LEGAL", sMovilRepresentante, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_ENCARGADO_PAGOS", sEncargado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_EMAIL_ENCARGADO_PAGOS", sEmailEncargado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_TELEFONO_ENCARGADO_PAGOS", sTelefonoEncargado, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_MOVIL_ENCARGADO_PAGOS", sMovilEncargado, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_periodo_pago", iPeriodoPago, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_dia_pago", sDiaPago, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha1", sFecha1, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha2", sFecha2, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha3", sFecha3, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_fecha4", sFecha4, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_horario_pago_ini", sHorarioPagoInicio, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_horario_pago_fin", sHorarioPagoFin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_tipo_pago", 3, OracleClient.OracleType.Int32)

            db.AsignarParametro("vi_IDUSUARIO_PERSONAL", dtoUSUARIOS.IdLogin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_IDROL_USUARIO", dtoUSUARIOS.IdRol, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_IP", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_MONTO_SOLICITADO", iMontoSolicitado, OracleClient.OracleType.Number)
            db.AsignarParametro("vi_fecha", sFecha, OracleClient.OracleType.VarChar)

            db.AsignarParametro("ni_dia1", iDia1, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia2", iDia2, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia3", iDia3, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia4", iDia4, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia5", iDia5, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia6", iDia6, OracleClient.OracleType.Int16)
            db.AsignarParametro("ni_dia7", iDia7, OracleClient.OracleType.Int16)

            db.AsignarParametro("vi_EMAIL_CONTACTO", sEmailContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_TELEFONO_CONTACTO", sTelefonoContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_MOVIL_CONTACTO", sMovilContacto, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_contacto", iContacto, OracleClient.OracleType.Int32)

            db.AsignarParametro("cur", OracleClient.OracleType.Cursor)
            db.AsignarParametro("cur_error", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataSet.Tables(0)
        Catch ex As Excepcion
            Throw New Excepcion(ex.Excepcion)
        End Try
    End Function

    Function ContactoDatos() As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_CONTACTO_DATOS", CommandType.StoredProcedure)
            db.AsignarParametro("id", iContacto, OracleClient.OracleType.Int32)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

    Function Desactivar(ByVal id As Integer, ByVal cliente As Integer) As DataTable
        Dim db As New BaseDatos
        Try
            db.Conectar()
            db.CrearComando("PKG_IVOPERSONA.SP_DESACTIVAR", CommandType.StoredProcedure)
            db.AsignarParametro("ni_IDSOLICITUD_CREDITO", id, OracleClient.OracleType.Int32)
            db.AsignarParametro("ni_IDPERSONA", cliente, OracleClient.OracleType.Int32)
            db.AsignarParametro("vi_FECHA_DESACTIVACION", Date.Now.ToShortDateString, OracleClient.OracleType.VarChar)
            db.AsignarParametro("ni_USUARIO_DESACTIVACION", dtoUSUARIOS.IdLogin, OracleClient.OracleType.VarChar)
            db.AsignarParametro("vi_IP_DESACTIVACION", dtoUSUARIOS.IP, OracleClient.OracleType.VarChar)
            db.AsignarParametro("CUR", OracleClient.OracleType.Cursor)
            db.Desconectar()
            Return db.EjecutarDataTable
        Catch ex As Excepcion
            db.Desconectar()
            Throw New Exception(ex.Message)
        Finally
            db = Nothing
        End Try
    End Function

End Class
