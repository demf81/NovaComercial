const GetUrlPrincipal = $("#txtUrlPrincipal").val();


const URL = {
    AreaNegocio:                       GetUrlPrincipal + 'AreaNegocio/AreaNegocio/',
    Asociado:                          GetUrlPrincipal + 'Asociado/Asociado/',
    Cirugia:                           GetUrlPrincipal + 'Cirugia/Cirugia/',
    Cliente:                           GetUrlPrincipal + 'Cliente/Cliente/',
    ClienteTipo:                       GetUrlPrincipal + 'ClienteTipo/ClienteTipo/',
    CoberturaCantidadTipo:             GetUrlPrincipal + 'CoberturaCantidadTipo/CoberturaCantidadTipo/',
    CoberturaCondicionTipo:            GetUrlPrincipal + 'CoberturaCondicionTipo/CoberturaCondicionTipo/',
    CoberturaCopagoTipo:               GetUrlPrincipal + 'CoberturaCopagoTipo/CoberturaCopagoTipo/',
    CoberturaPeriodoTipo:              GetUrlPrincipal + 'CoberturaPeriodoTipo/CoberturaPeriodoTipo/',
    ContactoTipo:                      GetUrlPrincipal + 'ContactoTipo/ContactoTipo/',
    Contrato:                          GetUrlPrincipal + 'Contrato/Contrato/',
    ContratoCobertura:                 GetUrlPrincipal + 'ContratoCobertura/ContratoCobertura/',
    ContratoCoberturaPaquete:          GetUrlPrincipal + 'ContratoCoberturaPaquete/ContratoCoberturaPaquete/',
    ContratoCoberturaPaqueteCondicion: GetUrlPrincipal + 'ContratoCoberturaPaqueteCondicion/ContratoCoberturaPaqueteCondicion/',
    ContratoCoberturaPaqueteExclusion: GetUrlPrincipal + 'ContratoCoberturaPaqueteExclusion/ContratoCoberturaPaqueteExclusion/',
    ContratoProducto:                  GetUrlPrincipal + 'ContratoProducto/ContratoProducto/',
    ContratoProductoPaquete:           GetUrlPrincipal + 'ContratoProductoPaquete/ContratoProductoPaquete/',
    ContratoTipo:                      GetUrlPrincipal + 'ContratoTipo/ContratoTipo/',
    Cotizacion:                        GetUrlPrincipal + 'Cotizacion/Cotizacion/',
    CotizacionDetalle:                 GetUrlPrincipal + 'CotizacionDetalle/CotizacionDetalle/',
    CotizacionProcedimientoDetalle:    GetUrlPrincipal + 'CotizacionProcedimientoDetalle/CotizacionProcedimientoDetalle/',
    Empresa:                           GetUrlPrincipal + 'Empresa/Empresa/',
    EmpresaArchivoTipo:                GetUrlPrincipal + 'EmpresaArchivoTipo/EmpresaArchivoTipo/',
    EmpresaContacto:                   GetUrlPrincipal + 'EmpresaContacto/EmpresaContacto/',
    EmpresaContrato:                   GetUrlPrincipal + 'EmpresaContrato/EmpresaContrato/',
    EmpresaDatosFiscales:              GetUrlPrincipal + 'EmpresaDatosFiscales/EmpresaDatosFiscales/',
    EmpresaDocumento:                  GetUrlPrincipal + 'EmpresaDocumento/EmpresaDocumento/',
    EmpresaDocumentoTipo:              GetUrlPrincipal + 'EmpresaDocumentoTipo/EmpresaDocumentoTipo/',
    EmpresaPlanta:                     GetUrlPrincipal + 'EmpresaPlanta/EmpresaPlanta/',
    EmpresaTipo:                       GetUrlPrincipal + 'EmpresaTipo/EmpresaTipo/',
    Estado:                            GetUrlPrincipal + 'Estado/Estado/',
    Estudio:                           GetUrlPrincipal + 'Estudio/Estudio/',
    FormaPago:                         GetUrlPrincipal + 'FormaPago/FormaPago/',
    FrecuenciaPago:                    GetUrlPrincipal + 'FrecuenciaPago/FrecuenciaPago/',
    Genero:                            GetUrlPrincipal + 'Genero/Genero/',
    Material:                          GetUrlPrincipal + 'Material/Material/',
    Medicamento:                       GetUrlPrincipal + 'Medicamento/Medicamento/',
    MedicamentoCuadroTipo:             GetUrlPrincipal + 'MedicamentoCuadroTipo/MedicamentoCuadroTipo/',
    Membresia:                         GetUrlPrincipal + 'Membresia/Membresia/',
    MembresiaEstatus:                  GetUrlPrincipal + 'MembresiaEstatus/MembresiaEstatus/',
    MembresiaPersona:                  GetUrlPrincipal + 'MembresiaPersona/MembresiaPersona/',
    MembresiaRenovacion:               GetUrlPrincipal + 'MembresiaRenovacion/MembresiaRenovacion/',
    MembresiaTipo:                     GetUrlPrincipal + 'MembresiaTipo/MembresiaTipo/',
    MetodoPago:                        GetUrlPrincipal + 'MetodoPago/MetodoPago/',
    Municipio:                         GetUrlPrincipal + 'Municipio/Municipio/',
    Pais:                              GetUrlPrincipal + 'Pais/Pais/',
    Paquete:                           GetUrlPrincipal + 'Paquete/Paquete/',
    PaqueteCobertura:                  GetUrlPrincipal + 'PaqueteCobertura/PaqueteCobertura/',
    PaqueteCoberturaDetalle:           GetUrlPrincipal + 'PaqueteCoberturaDetalle/PaqueteCoberturaDetalle/',
    PaqueteConvenio:                   GetUrlPrincipal + 'PaqueteConvenio/PaqueteConvenio/',
    PaqueteConvenioDetalle:            GetUrlPrincipal + 'PaqueteConvenioDetalle/PaqueteConvenioDetalle/',
    PaqueteDetalle:                    GetUrlPrincipal + 'PaqueteDetalle/PaqueteDetalle/',
    PaqueteTipo:                       GetUrlPrincipal + 'PaqueteTipo/PaqueteTipo/',
    Parentesco:                        GetUrlPrincipal + 'Parentesco/Parentesco/',
    Persona:                           GetUrlPrincipal + 'Persona/Persona/',
    PersonaContrato:                   GetUrlPrincipal + 'PersonaContrato/PersonaContrato/',
    Procedimiento:                     GetUrlPrincipal + 'Procedimiento/Procedimiento/',
    ProcedimientoDetalle:              GetUrlPrincipal + 'ProcedimientoDetalle/ProcedimientoDetalle/',
    Servicio:                          GetUrlPrincipal + 'Servicio/Servicio/',
    ServicioAdministrativo:            GetUrlPrincipal + 'ServicioAdministrativo/ServicioAdministrativo/',
    ServicioMedico:                    GetUrlPrincipal + 'ServicioMedico/ServicioMedico/',
    ServicioMedicoTipo:                GetUrlPrincipal + 'ServicioMedicoTipo/ServicioMedicoTipo/',
    ServicioSubrogado:                 GetUrlPrincipal + 'ServicioSubrogado/ServicioSubrogado/',
    ServicioSubrogadoTipo:             GetUrlPrincipal + 'ServicioSubrogadoTipo/ServicioSubrogadoTipo/',
    Tarifa:                            GetUrlPrincipal + 'Tarifa/Tarifa/',
    TarifaDetalle:                     GetUrlPrincipal + 'TarifaDetalle/TarifaDetalle/',
    Venta:                             GetUrlPrincipal + 'Venta/Venta/',
    VentaDetalle:                      GetUrlPrincipal + 'VentaDetalle/VentaDetalle/',
    VentaMotivoCancelacionTipo:        GetUrlPrincipal + 'VentaMotivoCancelacionTipo/VentaMotivoCancelacionTipo/',
    VentaUnitaria:                     GetUrlPrincipal + 'VentaUnitaria/VentaUnitaria/',
    VentaUnitariaDetalle:              GetUrlPrincipal + 'VentaUnitariaDetalle/VentaUnitariaDetalle/',
    VentaUnitariaEspecial:             GetUrlPrincipal + 'VentaUnitariaEspecial/VentaUnitariaEspecial/',
    VentaUnitariaEspecialDetalle:      GetUrlPrincipal + 'VentaUnitariaEspecialDetalle/VentaUnitariaEspecialDetalle/'    
}

const ESTATUS_ENTIDAD = {
    ACTIVO:    1,
    INACTIVO:  2,
    PREACTIVO: 3
}

//const COTIZACION_TIPO = {
//    PERSONA_FISICA    = 1,
//    PERSONA_EXISTENTE = 2,
//    EMPRESARIAL       = 3,
//    CONVENIO          = 4
//}

//const COTIZACION_ESTATUS = {
//    ACTIVA    = 1,
//    INACTIVA  = 2,
//    PROCESADA = 3
//}

//const VENTA_TIPO = {
//    PERSONA_FISICA = 1,
//    CONVENIO       = 2
//}