using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace wsSACC
{
    public class Vigencia : IVigencia
    {
        public Respuesta AltaAsociado(DatosAlta asociado, Token pToken)
        {
            int pServicioId    = 3;
            int pMetodoId      = 5;
            int AsociadoPasoId = 0;
            int AsociadoLogId  = 0;

            string resValidacionesBasicas    = string.Empty;
            string resValidacionesIntegridad = string.Empty;

            //string resInsertTitular             = string.Empty;
            //string resInsertUsuario             = string.Empty;
            //string resValidacionContrato        = string.Empty;
            //string resValidacionServicios       = string.Empty;
            //string resValidacionNumSocioUsuario = string.Empty;

            Respuesta resWS = new Respuesta();
            resWS.Error = "";

            #region VALIDACION DE USUARIO
            SAI.SAIClient wsSAI = new SAI.SAIClient();
            //SAI.Token     token = new SAI.Token();
            //SAI.Mensaje   res   = new SAI.Mensaje();
            SACC.LogicaNegocio.SAI.Token token = new SACC.LogicaNegocio.SAI.Token();
            SACC.LogicaNegocio.SAI.Mensaje res = new SACC.LogicaNegocio.SAI.Mensaje();

            token.UsuarioCuenta = pToken.Usuario;
            token.Contrasena    = pToken.Password;

            res = wsSAI.AutenticarExterno(token, pServicioId, pMetodoId);
            #endregion

            if (res.AutenticacionCorrecta == false)
            {
                resWS.Error = res.MensajeError;
            }
            else
            {
                resWS.TransaccionId = res.Token;
                SACC.Entidades.NovaComercial.WebService.AsociadoPaso oBE = new SACC.Entidades.NovaComercial.WebService.AsociadoPaso();

                #region ASIGNA PARAMETROS
                oBE.AsociadoId           = 0;
                oBE.ClaveMovimiento      = "AL";
                oBE.NumeroSocio          = asociado.NumeroSocio;
                oBE.ClaveFamiliar        = asociado.ClaveFamiliar;
                oBE.Nombre               = asociado.Nombre;
                oBE.Paterno              = asociado.Paterno;
                oBE.Materno              = asociado.Materno;
                oBE.Curp                 = asociado.Curp;
                oBE.TipoUsuario          = asociado.TipoUsuario;
                oBE.ClaveTipoSanguineo   = asociado.ClaveTipoSanguineo;
                oBE.ClaveEstadoCivil     = asociado.ClaveEstadoCivil;
                oBE.Sexo                 = asociado.Sexo;
                oBE.FechaNacimiento      = asociado.FechaNacimiento;
                oBE.FechaAltaContrato    = asociado.FechaAltaContrato;
                oBE.FechaMovimiento      = asociado.FechaMovimiento;
                oBE.FechaBajaContrato    = asociado.FechaBajaContrato;
                oBE.FechaIngresoGrupo    = asociado.FechaAltaContrato;
                oBE.ClaveEmpresaContrato = asociado.ClaveEmpresaContrato == null ? "" : asociado.ClaveEmpresaContrato;
                oBE.ClavePlantaContrato  = asociado.ClavePlantaContrato  == null ? "" : asociado.ClavePlantaContrato;
                oBE.RFCSocio             = asociado.RFCSocio;
                oBE.Calle                = asociado.Calle                == null ? "" : asociado.Calle;
                oBE.NumeroExterior       = asociado.NumeroExterior       == null ? "" : asociado.NumeroExterior;
                oBE.CodigoPostal         = asociado.CodigoPostal         == null ? "" : asociado.CodigoPostal;
                oBE.Colonia              = asociado.Colonia              == null ? "" : asociado.Colonia;
                oBE.Pais                 = asociado.Pais                 == null ? "" : asociado.Pais;
                oBE.Estado               = asociado.Estado               == null ? "" : asociado.Estado;
                oBE.Ciudad               = asociado.Ciudad               == null ? "" : asociado.Ciudad;
                oBE.TelefonoCasa         = asociado.TelefonoCasa;
                oBE.TelefonoOficina      = asociado.TelefonoOficina;
                oBE.Extension            = asociado.Extension;
                oBE.Fax                  = asociado.Fax;
                oBE.CorreoElectronico    = asociado.CorreoElectronico;
                oBE.NumeroAfiliacionIMSS = asociado.NumeroAfiliacionIMSS;
                oBE.ApellidoCasadaEsposa = asociado.ApellidoCasadaEsposa;
                oBE.NumeroPoliza         = asociado.NumeroPoliza;
                oBE.NumeroEndoso         = asociado.NumeroEndoso;
                oBE.TipoTrabajador       = asociado.TipoTrabajador;
                oBE.AseguradoraSocioId   = asociado.SocioId              == null ? "" : asociado.SocioId;
                oBE.EstatusId            = 1;
                oBE.Token                = res.Token;
                #endregion

                AsociadoPasoId = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.Insertar(SACC.LogicaNegocio.SqlOpciones.Insertar, oBE);

                if (AsociadoPasoId == 0)
                {
                    resWS.Error = "Alta Asociado - El registo no se pudo guardar";
                }
                else
                {
                    SACC.Entidades.NovaComercial.WebService.AsociadoLog oBElog = new SACC.Entidades.NovaComercial.WebService.AsociadoLog();

                    #region ASIGNA PARAMETROS
                    oBElog.AsociadoId           = 0;
                    oBElog.ClaveMovimiento      = "AL";
                    oBElog.NumeroSocio          = asociado.NumeroSocio;
                    oBElog.ClaveFamiliar        = asociado.ClaveFamiliar;
                    oBElog.Nombre               = asociado.Nombre;
                    oBElog.Paterno              = asociado.Paterno;
                    oBElog.Materno              = asociado.Materno;
                    oBElog.Curp                 = asociado.Curp;
                    oBElog.TipoUsuario          = asociado.TipoUsuario;
                    oBElog.ClaveTipoSanguineo   = asociado.ClaveTipoSanguineo;
                    oBElog.ClaveEstadoCivil     = asociado.ClaveEstadoCivil;
                    oBElog.Sexo                 = asociado.Sexo;
                    oBElog.FechaNacimiento      = asociado.FechaNacimiento;
                    oBElog.FechaAltaContrato    = asociado.FechaAltaContrato;
                    oBElog.FechaMovimiento      = asociado.FechaMovimiento;
                    oBElog.FechaBajaContrato    = asociado.FechaBajaContrato;
                    oBElog.ClaveEmpresaContrato = asociado.ClaveEmpresaContrato == null ? "" : asociado.ClaveEmpresaContrato;
                    oBElog.ClavePlantaContrato  = asociado.ClavePlantaContrato  == null ? "" : asociado.ClavePlantaContrato;
                    oBElog.RFCSocio             = asociado.RFCSocio;
                    oBElog.Calle                = asociado.Calle                == null ? "" : asociado.Calle;
                    oBElog.NumeroExterior       = asociado.NumeroExterior       == null ? "" : asociado.NumeroExterior;
                    oBElog.CodigoPostal         = asociado.CodigoPostal         == null ? "" : asociado.CodigoPostal;
                    oBElog.Colonia              = asociado.Colonia              == null ? "" : asociado.Colonia;
                    oBElog.Pais                 = asociado.Pais                 == null ? "" : asociado.Pais;
                    oBElog.Estado               = asociado.Estado               == null ? "" : asociado.Estado;
                    oBElog.Ciudad               = asociado.Ciudad               == null ? "" : asociado.Ciudad;
                    oBElog.TelefonoCasa         = asociado.TelefonoCasa;
                    oBElog.TelefonoOficina      = asociado.TelefonoOficina;
                    oBElog.Extension            = asociado.Extension;
                    oBElog.Fax                  = asociado.Fax;
                    oBElog.CorreoElectronico    = asociado.CorreoElectronico;
                    oBElog.NumeroAfiliacionIMSS = asociado.NumeroAfiliacionIMSS;
                    oBElog.ApellidoCasadaEsposa = asociado.ApellidoCasadaEsposa;
                    oBElog.NumeroPoliza         = asociado.NumeroPoliza;
                    oBElog.NumeroEndoso         = asociado.NumeroEndoso;
                    oBElog.TipoTrabajador       = asociado.TipoTrabajador;
                    oBElog.AseguradoraSocioId   = asociado.SocioId              == null ? "" : asociado.SocioId;
                    oBElog.EstatusId            = 1;
                    oBElog.Token                = res.Token;
                    #endregion

                    AsociadoLogId = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.Insertar(SACC.LogicaNegocio.SqlOpciones.Insertar, oBElog);
                    if (AsociadoLogId == 0)
                    {
                        resWS.Error = "Error al generar log del registro";
                    }
                    else
                    {
                        resValidacionesBasicas = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesBasica(resWS.TransaccionId);
                        if (resValidacionesBasicas == "")
                        {
                            resValidacionesIntegridad = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesIntegridad(oBElog);
                            if (resValidacionesIntegridad == "")
                            {
                                SACC.Modelo.NovaComercial.dbo.PersonaMoper.DtoPersonaMoper objPM = new SACC.Modelo.NovaComercial.dbo.PersonaMoper.DtoPersonaMoper
                                {
                                    PersonaMoperId      = 0,
                                    PersonaId           = 0,
                                    ProcesoId           = 2,
                                    ClaveMovimientoId   = "",
                                    NumeroSocio         = asociado.NumeroSocio.ToString(),
                                    ClaveFamiliar       = asociado.ClaveFamiliar.ToString(),
                                    Nombre              = asociado.Nombre,
                                    ApellidoPaterno     = asociado.Paterno,
                                    ApellidoMaterno     = asociado.Materno,
                                    FechaNacimiento     = asociado.FechaNacimiento.ToString(),
                                    CURP                = asociado.Curp,
                                    Genero              = asociado.Sexo,
                                    EstadoCivilId       = asociado.ClaveEstadoCivil,
                                    GrupoFamiliar       = "",
                                    EmpresaId           = asociado.ClaveEmpresaContrato,
                                    PlantaId            = asociado.ClavePlantaContrato,
                                    DepartamentoId      = "",
                                    TipoTrabajadorId    = asociado.TipoTrabajador,
                                    NumeroTernium       = "",
                                    RI                  = "",
                                    NR                  = "",
                                    FechaIngresoEmpresa = "",
                                    FechaIngresoGrupo   = "",
                                    EstatusActivo       = "",
                                    FechaAltaMovimiento = "",
                                    FechaBajaMovimiento = "",
                                    EmpresaAnteriorId   = "",
                                    PlantaAnteriorId    = ""
                                };

                                //resValidacionNumSocioUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.Buscarus_usuariosidSIASS(oBElog);
                                //if (resValidacionNumSocioUsuario == "")
                                //{
                                //    resValidacionServicios = string.Empty;// SACC.LogicaNegocio.VigenciaII.PUB.sc_servdecto.BuscarServiciosDelContrato(oBElog.ClaveEmpresaContrato, oBElog.ClavePlantaContrato);
                                //    if (resValidacionServicios == "")
                                //    {
                                //        if (oBElog.ClaveFamiliar == 0) // cuando es titular
                                //        {
                                //            resInsertTitular = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.ti_titulares.Guardarti_titulares(oBElog);
                                //            if (resInsertTitular == "")
                                //            {
                                //                resInsertUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.Guardarus_usuarios(oBElog);
                                //                if (resInsertUsuario != "")
                                //                    resWS.Error = resInsertUsuario;
                                //            }
                                //            else
                                //                resWS.Error = resInsertTitular;
                                //        }
                                //        else // cuando es dependiente
                                //        {
                                //            resInsertUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.Guardarus_usuarios(oBElog);
                                //            if (resInsertUsuario != "")
                                //                resWS.Error = resInsertUsuario;
                                //        }
                                //        if (resWS.Error == "")
                                //            resWS.Error = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.tmu_usuarios.Guardartmu_usuarios(oBElog);
                                //    }
                                //    else
                                //        resWS.Error = resValidacionServicios;
                                //}
                                //else
                                //    resWS.Error = resValidacionNumSocioUsuario;
                            }
                            else
                                resWS.Error = resValidacionesIntegridad;
                        }
                        else
                            resWS.Error = resValidacionesBasicas;
                    }
                }

            }


            // FALTA ACTUALIZAR EL REGISTRO EN LA TABOLA LOG CON LA DESCRIPCION DEL ERROR O CON EL MENSAGE SEGUN SEA EL CASO Y
            //CAMBIAR EL ESTATUS TAMBIEN SEA EL CASO

            if (resWS.Error == "")
                resWS.Mensaje = "El asociado se guardo satisfactoriamente.";

            return resWS;
        }


        public Respuesta CambioAsociado(DatosCambio asociado, Token pToken)
        {
            int pServicioId = 3;
            int pMetodoId   = 6;

            string resValidacionesBasicas       = string.Empty;
            string resValidacionesIntegridad    = string.Empty;
            string resCambiaTitular             = string.Empty;
            string resCambiaUsuario             = string.Empty;
            string resValidacionNumSocioUsuario = string.Empty;

            Respuesta resWS = new Respuesta();
            resWS.Error = "";

            #region VALIDACIÓN DE USUARIO
            SAI.SAIClient wsSAI = new SAI.SAIClient();
            //SAI.Token     token = new SAI.Token();
            //SAI.Mensaje   res   = new SAI.Mensaje();
            SACC.LogicaNegocio.SAI.Token token = new SACC.LogicaNegocio.SAI.Token();
            SACC.LogicaNegocio.SAI.Mensaje res = new SACC.LogicaNegocio.SAI.Mensaje();

            token.UsuarioCuenta = pToken.Usuario;
            token.Contrasena    = pToken.Password;

            res = wsSAI.AutenticarExterno(token, pServicioId, pMetodoId);
            #endregion

            if (res.AutenticacionCorrecta == false)
            {
                resWS.Error = res.MensajeError;
            }
            else
            {
                SACC.Entidades.NovaComercial.WebService.AsociadoPaso oBE = new SACC.Entidades.NovaComercial.WebService.AsociadoPaso();

                #region ASIGNA PARÁMETROS
                oBE.AsociadoId           = 0;
                oBE.ClaveMovimiento      = "CA";
                oBE.NumeroSocio          = asociado.NumeroSocio;
                oBE.ClaveFamiliar        = asociado.ClaveFamiliar;
                oBE.Nombre               = asociado.Nombre;
                oBE.Paterno              = asociado.Paterno;
                oBE.Materno              = asociado.Materno;
                oBE.Curp                 = asociado.Curp;
                oBE.TipoUsuario          = asociado.TipoUsuario;
                oBE.ClaveTipoSanguineo   = asociado.ClaveTipoSanguineo;
                oBE.ClaveEstadoCivil     = asociado.ClaveEstadoCivil;
                oBE.Sexo                 = asociado.Sexo;
                oBE.FechaNacimiento      = asociado.FechaNacimiento;
                oBE.FechaMovimiento      = asociado.FechaMovimiento;
                oBE.ClaveEmpresaContrato = asociado.ClaveEmpresaContrato == null ? "" : asociado.ClaveEmpresaContrato;
                oBE.ClavePlantaContrato  = asociado.ClavePlantaContrato == null ? "" : asociado.ClavePlantaContrato;
                oBE.RFCSocio             = asociado.RFCSocio;
                oBE.Calle                = asociado.Calle == null ? "" : asociado.Calle;
                oBE.NumeroExterior       = asociado.NumeroExterior == null ? "" : asociado.NumeroExterior;
                oBE.CodigoPostal         = asociado.CodigoPostal == null ? "" : asociado.CodigoPostal;
                oBE.ClaveColonia         = asociado.ClaveColonia;
                oBE.Colonia              = asociado.Colonia == null ? "" : asociado.Colonia;
                oBE.ClavePais            = asociado.ClavePais;
                oBE.Pais                 = asociado.Pais == null ? "" : asociado.Pais;
                oBE.ClaveEstado          = asociado.ClaveEstado;
                oBE.Estado               = asociado.Estado == null ? "" : asociado.Estado;
                oBE.ClaveCiudad          = asociado.ClaveCiudad;
                oBE.Ciudad               = asociado.Ciudad == null ? "" : asociado.Ciudad;
                oBE.TelefonoCasa         = asociado.TelefonoCasa;
                oBE.TelefonoOficina      = asociado.TelefonoOficina;
                oBE.Extension            = asociado.Extension;
                oBE.Fax                  = asociado.Fax;
                oBE.CorreoElectronico    = asociado.CorreoElectronico;
                oBE.NumeroAfiliacionIMSS = asociado.NumeroAfiliacionIMSS;
                oBE.ApellidoCasadaEsposa = asociado.ApellidoCasadaEsposa;
                oBE.NumeroPoliza         = asociado.NumeroPoliza;
                oBE.NumeroEndoso         = asociado.NumeroEndoso;
                oBE.TipoTrabajador       = asociado.TipoTrabajador;
                oBE.AseguradoraSocioId   = asociado.SocioId == null ? "" : asociado.SocioId;
                oBE.EstatusId            = 1;
                oBE.Token                = res.Token;
                #endregion

                int AsociadoId = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.Insertar(SACC.LogicaNegocio.SqlOpciones.Insertar, oBE);

                if (AsociadoId == 0)
                {
                    resWS.Error = "Cambio en Asociado - El registo no se pudo guardar";
                }
                else
                {
                    //    SACC.Entidades.NovaComercial.helper.RequestAsociado resValidacion = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.ValidacionBasicaAcosiado(resBL.AsociadoId);

                    //    if (resValidacion.EstatusId == 2)
                    //        resWS.Error = resValidacion.Mensaje;
                    //    else
                    //        resWS.Mensaje = resValidacion.Mensaje;

                    //    if (resValidacion.EstatusId == 1)
                    //    {
                    //        SACC.Entidades.NovaComercial.helper.RequestAsociado resVigenciaValidacion = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.ValidaVigenciaAsociado(oBE);
                    //    }
                    SACC.Entidades.NovaComercial.WebService.AsociadoLog oBElog = new SACC.Entidades.NovaComercial.WebService.AsociadoLog();

                    #region ASIGNA PARAMETROS
                    oBElog.AsociadoId           = 0;
                    oBElog.ClaveMovimiento      = "CA";
                    oBElog.NumeroSocio          = asociado.NumeroSocio;
                    oBElog.ClaveFamiliar        = asociado.ClaveFamiliar;
                    oBElog.Nombre               = asociado.Nombre;
                    oBElog.Paterno              = asociado.Paterno;
                    oBElog.Materno              = asociado.Materno;
                    oBElog.Curp                 = asociado.Curp;
                    oBElog.TipoUsuario          = asociado.TipoUsuario;
                    oBElog.ClaveTipoSanguineo   = asociado.ClaveTipoSanguineo;
                    oBElog.ClaveEstadoCivil     = asociado.ClaveEstadoCivil;
                    oBElog.Sexo                 = asociado.Sexo;
                    oBElog.FechaNacimiento      = asociado.FechaNacimiento;
                    //oBElog.FechaAltaContrato = asociado.FechaAltaContrato;
                    oBElog.FechaMovimiento      = asociado.FechaMovimiento;
                    //oBElog.FechaBajaContrato = asociado.FechaBajaContrato;
                    oBElog.ClaveEmpresaContrato = asociado.ClaveEmpresaContrato == null ? "" : asociado.ClaveEmpresaContrato;
                    oBElog.ClavePlantaContrato  = asociado.ClavePlantaContrato == null ? "" : asociado.ClavePlantaContrato;
                    oBElog.RFCSocio             = asociado.RFCSocio;
                    oBElog.Calle                = asociado.Calle == null ? "" : asociado.Calle;
                    oBElog.NumeroExterior       = asociado.NumeroExterior == null ? "" : asociado.NumeroExterior;
                    oBElog.CodigoPostal         = asociado.CodigoPostal == null ? "" : asociado.CodigoPostal;
                    oBElog.Colonia              = asociado.Colonia == null ? "" : asociado.Colonia;
                    oBElog.Pais                 = asociado.Pais == null ? "" : asociado.Pais;
                    oBElog.Estado               = asociado.Estado == null ? "" : asociado.Estado;
                    oBElog.Ciudad               = asociado.Ciudad == null ? "" : asociado.Ciudad;
                    oBElog.TelefonoCasa         = asociado.TelefonoCasa;
                    oBElog.TelefonoOficina      = asociado.TelefonoOficina;
                    oBElog.Extension            = asociado.Extension;
                    oBElog.Fax                  = asociado.Fax;
                    oBElog.CorreoElectronico    = asociado.CorreoElectronico;
                    oBElog.NumeroAfiliacionIMSS = asociado.NumeroAfiliacionIMSS;
                    oBElog.ApellidoCasadaEsposa = asociado.ApellidoCasadaEsposa;
                    oBElog.NumeroPoliza         = asociado.NumeroPoliza;
                    oBElog.NumeroEndoso         = asociado.NumeroEndoso;
                    oBElog.TipoTrabajador       = asociado.TipoTrabajador;
                    oBElog.AseguradoraSocioId   = asociado.SocioId == null ? "" : asociado.SocioId;
                    oBElog.EstatusId            = 1;
                    oBElog.Token                = res.Token;
                    #endregion

                    //resValidacionesBasicas = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesBasica(resWS.TransaccionId);
                    resValidacionesBasicas = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesBasica(res.Token);
                    if (resValidacionesBasicas == "")
                    {
                        resValidacionesIntegridad = string.Empty; // SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesIntegridad(oBElog);
                        if (resValidacionesIntegridad == "")
                        {
                            resValidacionNumSocioUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.Buscarus_usuariosidSIASS(oBElog);
                            if (resValidacionNumSocioUsuario == "")
                            {
                                if (oBElog.ClaveFamiliar == 0) // cuando es titular
                                {
                                    resCambiaTitular = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.ti_titulares.Guardarti_titulares(oBElog);
                                    if (resCambiaTitular == "")
                                    {
                                        resCambiaUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.Guardarus_usuarios(oBElog);
                                        if (resCambiaUsuario != "")
                                            resWS.Error = resCambiaUsuario;
                                    }
                                    else
                                        resWS.Error = resCambiaTitular;
                                }
                                else // cuando es dependiente
                                {
                                    resCambiaUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.Guardarus_usuarios(oBElog);
                                    if (resCambiaUsuario != "")
                                        resWS.Error = resCambiaUsuario;
                                }

                                if (resWS.Error == "")
                                    resWS.Error = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.tmu_usuarios.Guardartmu_usuarios(oBElog);
                            }
                            else
                                resWS.Error = resValidacionNumSocioUsuario;
                        }
                        else
                            resWS.Error = resValidacionesIntegridad;
                    }
                    else
                        resWS.Error = resValidacionesBasicas;
                }
            }

            resWS.TransaccionId = res.Token;

            return resWS;
        }


        public Respuesta BajaAsociado(DatosBaja asociado, Token pToken)
        {
            int pServicioId = 3;
            int pMetodoId   = 6;

            string resValidacionesBasicas    = string.Empty;
            string resValidacionesIntegridad = string.Empty;
            string resBajaTitular            = string.Empty;
            string resBajaUsuario            = string.Empty;
            string resBajaContrato           = string.Empty;
            string resBajaServicios          = string.Empty;
            string resBajaServiciosTitular   = string.Empty;
            string resBajaServiciosUsuario   = string.Empty;

            Respuesta resWS = new Respuesta();
            resWS.Error = "";

            #region VALIDACIÓN DE USUARIO
            SAI.SAIClient wsSAI = new SAI.SAIClient();
            //SAI.Token     token = new SAI.Token();
            //SAI.Mensaje   res   = new SAI.Mensaje();
            SACC.LogicaNegocio.SAI.Token token = new SACC.LogicaNegocio.SAI.Token();
            SACC.LogicaNegocio.SAI.Mensaje res = new SACC.LogicaNegocio.SAI.Mensaje();

            token.UsuarioCuenta = pToken.Usuario;
            token.Contrasena    = pToken.Password;

            res = wsSAI.AutenticarExterno(token, pServicioId, pMetodoId);
            #endregion

            if (res.AutenticacionCorrecta == false)
            {
                resWS.Error = res.MensajeError;
            }
            else
            {
                SACC.Entidades.NovaComercial.WebService.AsociadoPaso oBE = new SACC.Entidades.NovaComercial.WebService.AsociadoPaso();

                #region ASIGNA PARÁMETROS
                oBE.AsociadoId           = 0;
                oBE.ClaveMovimiento      = "BA";
                oBE.NumeroSocio          = asociado.NumeroSocio;
                oBE.ClaveFamiliar        = asociado.ClaveFamiliar;
                oBE.FechaBaja            = asociado.FechaMovimiento;
                oBE.FechaBajaContrato    = asociado.FechaBajaContrato;
                oBE.ClaveEmpresaContrato = asociado.ClaveEmpresaContrato;
                oBE.ClavePlantaContrato  = asociado.ClavePlantaContrato;
                oBE.FechaMovimiento      = asociado.FechaMovimiento;
                oBE.Nombre               = asociado.Nombre;
                oBE.Paterno              = asociado.Paterno;
                oBE.Materno              = asociado.Materno;

                oBE.Token = res.Token;
                #endregion

                int AsociadoId = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.Insertar(SACC.LogicaNegocio.SqlOpciones.Insertar, oBE);

                if (AsociadoId == 0)
                {
                    resWS.Error = "Baja Asociado - El registo no se pudo guardar";
                }
                else
                {
                    SACC.Entidades.NovaComercial.WebService.AsociadoLog oBElog = new SACC.Entidades.NovaComercial.WebService.AsociadoLog();

                    #region ASIGNA PARAMETROS
                    oBElog.AsociadoId           = 0;
                    oBElog.ClaveMovimiento      = "BA";
                    oBElog.NumeroSocio          = asociado.NumeroSocio;
                    oBElog.ClaveFamiliar        = asociado.ClaveFamiliar;
                    oBElog.FechaBaja            = asociado.FechaMovimiento;
                    oBElog.FechaBajaContrato    = asociado.FechaBajaContrato;
                    oBElog.ClaveEmpresaContrato = asociado.ClaveEmpresaContrato;
                    oBElog.ClavePlantaContrato  = asociado.ClavePlantaContrato;
                    oBElog.FechaMovimiento      = asociado.FechaMovimiento;
                    oBElog.Nombre               = asociado.Nombre;
                    oBElog.Paterno              = asociado.Paterno;
                    oBElog.Materno              = asociado.Materno;

                    oBElog.Token = res.Token;
                    #endregion

                    //resValidacionesBasicas = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesBasica(resWS.TransaccionId);
                    resValidacionesBasicas = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesBaja(res.Token);
                    if (resValidacionesBasicas == "")
                    {
                        resBajaContrato = SACC.LogicaNegocio.VigenciaII.PUB.co_contratos.BuscarContrato(oBElog.ClaveEmpresaContrato, oBElog.ClavePlantaContrato);
                        if (resBajaContrato == "")
                        {
                            resBajaServicios = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.sc_servdecto.BuscarServiciosDelContrato(oBElog.ClaveEmpresaContrato, oBElog.ClavePlantaContrato);
                            if (resBajaServicios == "")
                            {
                                if (oBElog.ClaveFamiliar == 0) // cuando es titular
                                {
                                    resBajaTitular = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.cct_titulares.Bajacct_titulares(oBElog);
                                    if (resBajaTitular == "")
                                    {
                                        resBajaServiciosTitular = string.Empty;// SACC.LogicaNegocio.VigenciaII.PUB.st_serdetit.Bajast_serdetit(oBElog);
                                        if (resBajaServiciosTitular == "")
                                        {
                                            resBajaUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.ccu_usuarios.Bajaccu_usuarios(oBElog);
                                            if (resBajaUsuario == "")
                                            {
                                                resBajaServiciosUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.su_serdeusu.Bajasu_serdeusu(oBElog);
                                                if (resBajaServiciosUsuario != "")
                                                    resWS.Error = resBajaServiciosUsuario;
                                            }
                                            else
                                                resWS.Error = resBajaUsuario;
                                        }
                                        else
                                            resWS.Error = resBajaServiciosTitular;
                                    }
                                    else
                                        resWS.Error = resBajaTitular;
                                }
                                else // cuando es dependiente
                                {
                                    resBajaUsuario = SACC.LogicaNegocio.VigenciaII.PUB.ccu_usuarios.Bajaccu_usuarios(oBElog);
                                    if (resBajaUsuario == "")
                                    {
                                        resBajaServiciosUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.su_serdeusu.Bajasu_serdeusu(oBElog);
                                        if (resBajaServiciosUsuario != "")
                                            resWS.Error = resBajaServiciosUsuario;
                                    }
                                    else
                                        resWS.Error = resBajaUsuario;
                                }

                                if (resWS.Error == "")
                                    resWS.Error = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.tmu_usuarios.Guardartmu_usuarios(oBElog);

                            }
                            else
                                resWS.Error = resBajaServicios;
                        }
                        else
                            resWS.Error = resBajaContrato;
                    }
                    else
                        resWS.Error = resValidacionesBasicas;
                }
            }

            resWS.TransaccionId = res.Token;

            return resWS;
        }


        public Respuesta ReactivaAsociado(DatosReactivacion asociado, Token pToken)
        {
            int pServicioId = 3;
            int pMetodoId   = 6;

            string resValidacionesBasicas    = string.Empty;
            string resValidacionesIntegridad = string.Empty;
            string resActivaTitular          = string.Empty;
            string resActivaUsuario          = string.Empty;
            string resValidacionContrato     = string.Empty;
            string resValidacionServicios    = string.Empty;
            string resActivaContratoTitular  = string.Empty;
            string resActivaContratoUsuario  = string.Empty;
            string resActivaServiciosTitular = string.Empty;
            string resActivaServiciosUsuario = string.Empty;

            Respuesta resWS = new Respuesta();
            resWS.Error = "";

            #region VALIDACIÓN DE USUARIO
            SAI.SAIClient wsSAI = new SAI.SAIClient();
            //SAI.Token     token = new SAI.Token();
            //SAI.Mensaje   res   = new SAI.Mensaje();
            SACC.LogicaNegocio.SAI.Token token = new SACC.LogicaNegocio.SAI.Token();
            SACC.LogicaNegocio.SAI.Mensaje res = new SACC.LogicaNegocio.SAI.Mensaje();

            token.UsuarioCuenta = pToken.Usuario;
            token.Contrasena    = pToken.Password;

            res = wsSAI.AutenticarExterno(token, pServicioId, pMetodoId);
            #endregion

            if (res.AutenticacionCorrecta == false)
            {
                resWS.Error = res.MensajeError;
            }
            else
            {
                SACC.Entidades.NovaComercial.WebService.AsociadoPaso oBE = new SACC.Entidades.NovaComercial.WebService.AsociadoPaso();

                #region ASIGNA PARÁMETROS
                oBE.AsociadoId                = 0;
                oBE.ClaveMovimiento           = "RE";
                oBE.NumeroSocio               = asociado.NumeroSocio;
                oBE.ClaveFamiliar             = asociado.ClaveFamiliar;
                oBE.Nombre                    = asociado.Nombre;
                oBE.Paterno                   = asociado.Paterno;
                oBE.Materno                   = asociado.Materno;
                oBE.Curp                      = asociado.Curp;
                oBE.TipoUsuario               = asociado.TipoUsuario;
                oBE.ClaveTipoSanguineo        = asociado.ClaveTipoSanguineo;
                oBE.ClaveEstadoCivil          = asociado.ClaveEstadoCivil;
                oBE.Sexo                      = asociado.Sexo;
                oBE.FechaNacimiento           = asociado.FechaNacimiento;
                oBE.FechaMovimiento           = asociado.FechaMovimiento;
                oBE.FechaReactivacionContrato = asociado.FechaReactivacion;
                oBE.ClaveEmpresaContrato      = asociado.ClaveEmpresaContrato == null ? "" : asociado.ClaveEmpresaContrato;
                oBE.ClavePlantaContrato       = asociado.ClavePlantaContrato == null ? "" : asociado.ClavePlantaContrato;
                oBE.RFCSocio                  = asociado.RFCSocio;
                oBE.Calle                     = asociado.Calle == null ? "" : asociado.Calle;
                oBE.NumeroExterior            = asociado.NumeroExterior == null ? "" : asociado.NumeroExterior;
                oBE.CodigoPostal              = asociado.CodigoPostal == null ? "" : asociado.CodigoPostal;
                oBE.ClaveColonia              = asociado.ClaveColonia;
                oBE.Colonia                   = asociado.Colonia == null ? "" : asociado.Colonia;
                oBE.ClavePais                 = asociado.ClavePais;
                oBE.Pais                      = asociado.Pais == null ? "" : asociado.Pais;
                oBE.ClaveEstado               = asociado.ClaveEstado;
                oBE.Estado                    = asociado.Estado == null ? "" : asociado.Estado;
                oBE.ClaveCiudad               = asociado.ClaveCiudad;
                oBE.Ciudad                    = asociado.Ciudad == null ? "" : asociado.Ciudad;
                oBE.TelefonoCasa              = asociado.TelefonoCasa;
                oBE.TelefonoOficina           = asociado.TelefonoOficina;
                oBE.Extension                 = asociado.Extension;
                oBE.Fax                       = asociado.Fax;
                oBE.CorreoElectronico         = asociado.CorreoElectronico;
                oBE.NumeroAfiliacionIMSS      = asociado.NumeroAfiliacionIMSS;
                oBE.ApellidoCasadaEsposa      = asociado.ApellidoCasadaEsposa;
                oBE.NumeroPoliza              = asociado.NumeroPoliza;
                oBE.NumeroEndoso              = asociado.NumeroEndoso;
                oBE.TipoTrabajador            = asociado.TipoTrabajador;
                oBE.AseguradoraSocioId        = asociado.SocioId == null ? "" : asociado.SocioId;
                oBE.EstatusId                 = 1;
                oBE.Token                     = res.Token;
                #endregion

                int AsociadoId = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.Insertar(SACC.LogicaNegocio.SqlOpciones.Insertar, oBE);

                if (AsociadoId == 0)
                {
                    resWS.Error = "Reactiva Asociado - El registo no se pudo guardar";
                }
                else
                {
                    //    SACC.Entidades.NovaComercial.helper.RequestAsociado resValidacion = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.ValidacionBasicaAcosiado(resBL.AsociadoId);

                    //    if (resValidacion.EstatusId == 2)
                    //        resWS.Error = resValidacion.Mensaje;
                    //    else
                    //        resWS.Mensaje = resValidacion.Mensaje;

                    //    if (resValidacion.EstatusId == 1)
                    //    {
                    //        SACC.Entidades.NovaComercial.helper.RequestAsociado resVigenciaValidacion = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoPaso.ValidaVigenciaAsociado(oBE);
                    //    }
                    SACC.Entidades.NovaComercial.WebService.AsociadoLog oBElog = new SACC.Entidades.NovaComercial.WebService.AsociadoLog();

                    #region ASIGNA PARAMETROS
                    oBElog.AsociadoId = 0;
                    oBElog.ClaveMovimiento = "RE";
                    oBElog.NumeroSocio = asociado.NumeroSocio;
                    oBElog.ClaveFamiliar = asociado.ClaveFamiliar;
                    oBElog.Nombre = asociado.Nombre;
                    oBElog.Paterno = asociado.Paterno;
                    oBElog.Materno = asociado.Materno;
                    oBElog.Curp = asociado.Curp;
                    oBElog.TipoUsuario = asociado.TipoUsuario;
                    oBElog.ClaveTipoSanguineo = asociado.ClaveTipoSanguineo;
                    oBElog.ClaveEstadoCivil = asociado.ClaveEstadoCivil;
                    oBElog.Sexo = asociado.Sexo;
                    oBElog.FechaNacimiento = asociado.FechaNacimiento;
                    //oBElog.FechaAltaContrato = asociado.FechaAltaContrato;
                    oBElog.FechaMovimiento = asociado.FechaMovimiento;
                    oBElog.FechaReactivacionContrato = asociado.FechaReactivacion;
                    oBElog.ClaveEmpresaContrato = asociado.ClaveEmpresaContrato == null ? "" : asociado.ClaveEmpresaContrato;
                    oBElog.ClavePlantaContrato = asociado.ClavePlantaContrato == null ? "" : asociado.ClavePlantaContrato;
                    oBElog.RFCSocio = asociado.RFCSocio;
                    oBElog.Calle = asociado.Calle == null ? "" : asociado.Calle;
                    oBElog.NumeroExterior = asociado.NumeroExterior == null ? "" : asociado.NumeroExterior;
                    oBElog.CodigoPostal = asociado.CodigoPostal == null ? "" : asociado.CodigoPostal;
                    oBElog.Colonia = asociado.Colonia == null ? "" : asociado.Colonia;
                    oBElog.Pais = asociado.Pais == null ? "" : asociado.Pais;
                    oBElog.Estado = asociado.Estado == null ? "" : asociado.Estado;
                    oBElog.Ciudad = asociado.Ciudad == null ? "" : asociado.Ciudad;
                    oBElog.TelefonoCasa = asociado.TelefonoCasa;
                    oBElog.TelefonoOficina = asociado.TelefonoOficina;
                    oBElog.Extension = asociado.Extension;
                    oBElog.Fax = asociado.Fax;
                    oBElog.CorreoElectronico = asociado.CorreoElectronico;
                    oBElog.NumeroAfiliacionIMSS = asociado.NumeroAfiliacionIMSS;
                    oBElog.ApellidoCasadaEsposa = asociado.ApellidoCasadaEsposa;
                    oBElog.NumeroPoliza = asociado.NumeroPoliza;
                    oBElog.NumeroEndoso = asociado.NumeroEndoso;
                    oBElog.TipoTrabajador = asociado.TipoTrabajador;
                    oBElog.AseguradoraSocioId = asociado.SocioId == null ? "" : asociado.SocioId;
                    oBElog.EstatusId = 1;
                    oBElog.Token = res.Token;
                    #endregion

                    //resValidacionesBasicas = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesBasica(resWS.TransaccionId);
                    resValidacionesBasicas = SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesBasica(res.Token);
                    if (resValidacionesBasicas == "")
                    {
                        resValidacionesIntegridad = string.Empty; // SACC.LogicaNegocio.NovaComercial.WebService.AsociadoLog.ValidacionesIntegridad(oBElog);
                        if (resValidacionesIntegridad == "")
                        {
                            resValidacionContrato = SACC.LogicaNegocio.VigenciaII.PUB.co_contratos.BuscarContrato(oBElog.ClaveEmpresaContrato, oBElog.ClavePlantaContrato);
                            if (resValidacionContrato == "")
                            {
                                resValidacionServicios = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.sc_servdecto.BuscarServiciosDelContrato(oBElog.ClaveEmpresaContrato, oBElog.ClavePlantaContrato);
                                if (resValidacionServicios == "")
                                {
                                    if (oBElog.ClaveFamiliar == 0) // cuando es titular
                                    {
                                        resActivaTitular = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.ti_titulares.Guardarti_titulares(oBElog);
                                        if (resActivaTitular == "")
                                        {
                                            resActivaContratoTitular = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.cct_titulares.Reactivacct_titulares(oBElog);
                                            if (resActivaContratoTitular == "")
                                            {
                                                resActivaServiciosTitular = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.st_serdetit.Reactivast_serdetit(oBElog);
                                                if (resActivaServiciosTitular == "")
                                                {
                                                    resActivaContratoUsuario = SACC.LogicaNegocio.VigenciaII.PUB.ccu_usuarios.Reactivaccu_usuarios(oBElog);
                                                    if (resActivaContratoUsuario == "")
                                                    {
                                                        resActivaServiciosUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.su_serdeusu.Reactivasu_serdeusu(oBElog);
                                                        if (resActivaServiciosUsuario != "")
                                                            resWS.Error = resActivaServiciosUsuario;
                                                    }
                                                    else
                                                        resWS.Error = resActivaContratoUsuario;
                                                }
                                                else
                                                    resWS.Error = resActivaServiciosTitular;
                                            }
                                            else
                                                resWS.Error = resActivaContratoTitular;
                                        }
                                        else
                                            resWS.Error = resActivaTitular;
                                    }
                                    else // cuando es dependiente
                                    {
                                        resActivaUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.us_usuarios.Guardarus_usuarios(oBElog);
                                        if (resActivaUsuario == "")
                                        {
                                            resActivaContratoUsuario = SACC.LogicaNegocio.VigenciaII.PUB.ccu_usuarios.Reactivaccu_usuarios(oBElog);
                                            if (resActivaContratoUsuario == "")
                                            {
                                                resActivaServiciosUsuario = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.su_serdeusu.Reactivasu_serdeusu(oBElog);
                                                if (resActivaServiciosUsuario != "")
                                                    resWS.Error = resActivaServiciosUsuario;
                                            }
                                            else
                                                resWS.Error = resActivaContratoUsuario;
                                        }
                                        else
                                            resWS.Error = resActivaUsuario;
                                    }

                                    if (resWS.Error == "")
                                        resWS.Error = string.Empty; // SACC.LogicaNegocio.VigenciaII.PUB.tmu_usuarios.Guardartmu_usuarios(oBElog);
                                }
                                else
                                    resWS.Error = resValidacionServicios;

                            }
                            else
                                resWS.Error = resValidacionContrato;
                        }
                        else
                            resWS.Error = resValidacionesIntegridad;
                    }
                    else
                        resWS.Error = resValidacionesBasicas;
                }
            }

            resWS.TransaccionId = res.Token;

            return resWS;
        }
    }
}