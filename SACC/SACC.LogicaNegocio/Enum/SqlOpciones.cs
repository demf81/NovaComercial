namespace SACC.LogicaNegocio
{
    public enum SqlOpciones
    {
        #region OPCIONES DEL SISTEMA QUE NUNCA CAMBIAN
        ConsultaPorId                          = 1, // CONSULTAR EL REGISTRO POR ID
        ConsultaPorIdConJoin                   = 2, // CONSULTAR EL REGISTRO POR ID CON JOIN
        ConsultaGeneral                        = 3, // CONSULTAR EL GRID
        ConsultaGeneralConJoin                 = 4, // CONSULTAR EL GRID CON JOIN
        Lista                                  = 5, // CONSULTAR UN COMBO
        ListaConJoin                           = 6, // CONSULTAR UN COMBO CON JOIN

        Insertar                               = 1, // INSERTRA UN REGISTRO
        InsertarEspecial                       = 2, // INSERTRA UN REGISTRO CON PROCESO

        Actualizar                             = 1, // ACTUALIZA UN REGISTRO
        BajaLogica                             = 2, // BAJA LOGICA DE UN REGISTRO
        CambioEstatus                          = 3, // CAMBIA ESTATUS DE UN REGISTRO
        #endregion




        #region OPCIONES DE USUARIO MEMBRESIA
        ActualizarVigenciaMembresia = 3,
        #endregion




        #region OPCIONES DE USUARIO PARA VENTA
        CancelaVenta = 4,
        #endregion




        #region OPCIONES DE USUARIO VENTA UNITARIA
        ListaContratoProductoPorPersona = 7,
        ListaContratoProductoPorProducto = 7,
        #endregion




        #region OPCIONES DE USUARIO PAQUETE
        #endregion


        ActualizaPersonaNumeroSocio = 4,

        #region OPCIONES DE USUARIO PAQUETE DETALLE
        ConsultaTodosItemsPaqueteDetalle = 13,
        #endregion
        //ConsultaPorIdConJoin = 5, // CONSULTAR EL GRID

        ConsultarAsociadosNexus = 100,

        #region OPCIONES DEL USUARIO
        ConsultaGeneralConJoinConPrecio  = 7,
        ContultarPersonaContratoContrato = 7,
        ActivaCoberturaDefault           = 4,
        InactivarCoberturaDefault        = 5,



        ConsultaGeneralCoberturaPorPersona = 8,
       












        ConsultaGeneralConJoinPrecio = 5,
        ConsultaGeneralConJoinTodo             = 9,
        AutenticaUsaurio                       = 4,
        ConsultaPoblacion                      = 4,
        ConsultaPersonaPorCURP                 = 5,
        ConsultaPaquetePersona                 = 4,
        ConsultaPoblacionPorId                 = 6,
        ConsultaContratosVigentes              = 5,
        ConsultaPersona                        = 7,
        ConsiltaGeneralContratoProductoPaquete = 5,
        ConsultaGeneralEmpresaContrato         = 5,
        ConsultaGeneralVentaUnitariaPersona    = 6,
        ConsultaGeneralVentaUnitariaAsociado   = 7,
        

        ConsultaPaqueteHeder                   = 5,
        ConsultaGeneralAsociado                = 8,
        ConsultaMedicamentoAmparado            = 5,
        ConsultaMaterialAmparado               = 6,
        ConsultaCirugiaAmparado                = 7,
        ConsultaEstudioAmparado                = 8,
        ConsultaServicioAmparado               = 9,
        ConsultaVentaUnitariaResumen           = 8,
        ConsultaIdNumeroSocio                  = 4,
        #endregion

        #region OPCIONES DE INSERTAR
        
        #endregion

        #region OPCIONES DE ACTUALIZAR
       
        CambioContrasena                       = 3,
        ActualizarEspecial                     = 3,
        #endregion

        #region OPCIONES PARA LA BUSQUEDA DE TIPO SE SERVICIOS EN PAQUETE DETALLE
        ConsultaServicios                      = 4,
        ConsultaMateriales                     = 5,
        ConsultaMedicamentos                   = 6,
        ConsultaEstudios                       = 7,
        ConsultaCirugias                       = 8,
        #endregion

        #region OPCIONES PARA WEB SERVICE VIGENCIA
        ValidacionBasicaAsociado               = 3,
        ActualizarAsociadoLog                  = 4,
        ValidacionesBajaAsociado               = 5,
        ErrorValidacionBasica                  = 2,
        ErrorValidacionIntegreidad             = 3,
        //ErrorInsertarVigencia = 4,
        //RegistroGeneradoVigencia = 5,

        EliminarRegistroPaso                   = 3,
        #endregion
        //ActualizarGeneralenTranDatosAfiliado = 3,
        //ActualizarGeneralenTranDatosEmpresa = 3,
        //BajaContratoCascada = 3,
        VentaUnitariaCambioVigencia = 3,
        //ReprocesaVentaUnitaria = 3,
        //ActivaAfiliado = 4,
        //CambioVigenciaNexus = 4,
        //ConsultaPoblacionPortalEmpresa = 8,
        //ConsultaAsociadoPorCURP = 9,
        //ConsultaAsociadoPorNumSocioCveFamiliar = 10

    }
}
