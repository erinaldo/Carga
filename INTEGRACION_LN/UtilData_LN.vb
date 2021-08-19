Imports System.Windows.Forms
Imports INTEGRACION_AD
Public Class UtilData_LN
    Dim getUtilData As New UtilData_AD

    ''' <summary>
    ''' CARGA LOS OBJETOS COMBOBOX
    ''' </summary>
    ''' <param name="table">Opcional,Nombre de la tabla</param>
    ''' <param name="comboBox">Opcional,Objeto comboBox</param>
    ''' <param name="todos">Opcional,true se muestra al inicio del como "TODOS"; false "SELECCIONE"</param>
    ''' <param name="dataTable">Opcional, Objeto con el que se deben cargar los datos</param>
    ''' <remarks>jabanto</remarks>
    Public Sub cargarCombos(Optional ByVal table As String = "", Optional ByVal comboBox As ComboBox = Nothing, Optional ByVal todos As Boolean = False, Optional ByVal dataTable As DataTable = Nothing, _
                            Optional ByVal parametro As Integer = 0, Optional opcion As String = "", Optional idopcion As Integer = -2, Optional fila As Integer = 0)
        getUtilData.cargarCombos(table, comboBox, todos, dataTable, parametro, opcion, idopcion, fila)
    End Sub
    ''' <summary>
    ''' BUSCA EL MAESTRO DE ARTICULOS
    ''' </summary>
    ''' <returns>Lista de articulos</returns>
    Public Function buscarArticulos() As DataTable
        Return getUtilData.buscarArticulos()
    End Function
    ''' <summary>
    ''' Determina si la tarifa publica creada es para atencion al publico en general (1) o para clientes corporativos (2).
    ''' </summary>
    Public Sub cargarTipoVisibilidad(ByVal ComboBox As ComboBox, ByVal todos As Boolean, Optional fila As Integer = 0)
        getUtilData.cargarTipoVisibilidad(ComboBox, todos, fila)
    End Sub

    Public Sub cargarTipoEntrega(ByVal ComboBox As ComboBox, ByVal todos As Boolean, Optional fila As Integer = 0)
        getUtilData.cargarTipoEntrega(ComboBox, todos, fila)
    End Sub
    Public Function ListarSubcuenta(cliente As Integer) As DataTable
        Return getUtilData.ListarSubcuenta(cliente)
    End Function

    Public Function ListarCiudad(Optional opcion As Integer = 0) As DataTable
        Return getUtilData.ListarCiudad(opcion)
    End Function

    Public Function ListarProducto(Optional opcion As Integer = 0) As DataTable
        Return getUtilData.ListarProducto(opcion)
    End Function

    Public Function ListarTipoFacturacion() As DataTable
        Return getUtilData.ListarTipoFacturacion
    End Function

    Public Function ListarDireccion(cliente As Integer, Optional tipo As Integer = 0) As DataTable
        Return getUtilData.ListarDireccion(cliente, tipo)
    End Function

    Function ListarCliente(documento As String) As DataTable
        Return getUtilData.ListarCliente(documento)
    End Function

    Function ListarCliente(id As Integer) As DataTable
        Return getUtilData.ListarCliente(id)
    End Function

    Function TipoControl(ByVal tipo As Integer, ByVal opcion As Integer) As DataTable
        Return getUtilData.TipoControl(tipo, opcion)
    End Function
End Class
