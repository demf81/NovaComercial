using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Persona
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoGridPersona> ConsultarGrid(Int32 pPersonaId, Int32 pNumSocio, String pClaveFamiliar, String pNombre, String pCURP, Boolean? pGeneroId, Int32 pContratoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoGridPersona> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoGridPersona>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PersonaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaPM
                {
                    Opcion        = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    PersonaId     = pPersonaId,
                    NumSocio      = pNumSocio,
                    ClaveFamiliar = pClaveFamiliar,
                    Nombre        = pNombre,
                    CURP          = pCURP,
                    Genero        = pGeneroId,
                    EstatusId     = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Persona oBD = new AccesoDatos.NovaComercial.dbo.Persona();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Persona.DtoGridPersona item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Persona.DtoGridPersona>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Persona.DtoGridPersona
                            {
                                PersonaId         = Int32.Parse(dr["PersonaId"].ToString()),
                                NombreCompleto    = dr["Paterno"].ToString() + " " + dr["Materno"].ToString() + ", " + dr["Nombre"].ToString(),
                                CURP              = dr["Curp"].ToString(),
                                GeneroDescripcion = dr["GeneroDescripcion"].ToString(),
                                Edad              = Int32.Parse(dr["Edad"].ToString()),
                                NumSocio          = dr["NumSocio"].ToString(),
                                CoberturaDefault  = dr["CoberturaDefault"].ToString(),
                                EstatusId         = Int16.Parse(dr["EstatusId"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoPersona> ConsultarPorId(Int32 pPersonaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoPersona> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoPersona>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PersonaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaPorId,
                    PersonaId = pPersonaId
                };

                AccesoDatos.NovaComercial.dbo.Persona oBD = new AccesoDatos.NovaComercial.dbo.Persona();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Persona.DtoPersona item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Persona.DtoPersona>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Persona.DtoPersona
                            {
                                PersonaId       = Int32.Parse(dr["PersonaId"].ToString()),
                                Nombre          = dr["Nombre"].ToString(),
                                Paterno         = dr["Paterno"].ToString(),
                                Materno         = dr["Materno"].ToString(),
                                Genero          = Boolean.Parse(dr["Genero"].ToString()),
                                FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString()),
                                RN              = Boolean.Parse(dr["RN"].ToString()),
                                Extranjero      = Boolean.Parse(dr["Extranjero"].ToString()),
                                CURP            = dr["CURP"].ToString(),
                                EstatusId       = Int16.Parse(dr["EstatusId"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoCtrlUserBusquedaPersonaGrid> CtrlUserBuscarPersona(String pNombre, Int32 pNumSocio, String pClaveFamiliar, Boolean? pBaja, Boolean? pBajaAsociado)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoCtrlUserBusquedaPersonaGrid> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoCtrlUserBusquedaPersonaGrid>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PersonaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaPM()
                {
                    Opcion        = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    Nombre        = pNombre,
                    NumSocio      = pNumSocio,
                    ClaveFamiliar = pClaveFamiliar,
                    Baja          = pBaja,
                    BajaAsociado  = pBajaAsociado
                };

                AccesoDatos.NovaComercial.dbo.Persona oBD = new AccesoDatos.NovaComercial.dbo.Persona();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Persona.DtoCtrlUserBusquedaPersonaGrid item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Persona.DtoCtrlUserBusquedaPersonaGrid>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Persona.DtoCtrlUserBusquedaPersonaGrid
                            {
                                PersonaId      = Int32.Parse(dr["PersonaId"].ToString()),
                                NombreCompleto = dr["Paterno"].ToString() + " " + dr["Materno"].ToString() + ", " + dr["Nombre"].ToString(),
                                NumSocio       = dr["NumSocio"].ToString(),
                                Genero         = dr["GeneroDescripcion"].ToString(),
                                CURP           = dr["CURP"].ToString(),
                                Edad           = Int16.Parse(dr["Edad"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        //public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoComboPersona> ConsultarCombo(String pPersonaDescripcion)
        //{
        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoComboPersona> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Persona.DtoComboPersona>();

        //    try
        //    {
        //        Modelo.Parametro.NovaComercial.dbo.PersonaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PersonaPM
        //        {
        //            Opcion = (Int16)SqlOpciones.Lista,
        //            //PersonaDescripcion = pPersonaDescripcion
        //        };

        //        AccesoDatos.NovaComercial.dbo.Persona oBD = new AccesoDatos.NovaComercial.dbo.Persona();
        //        Modelo.ModeloResponse response = oBD.Consultar(oParametros);

        //        if (!response.Error)
        //        {
        //            Modelo.NovaComercial.dbo.Persona.DtoComboPersona item = null;
        //            res.Datos = new List<Modelo.NovaComercial.dbo.Persona.DtoComboPersona>();

        //            foreach (DataTable table in response.Resultado.Tables)
        //            {
        //                foreach (DataRow dr in table.Rows)
        //                {
        //                    item = new Modelo.NovaComercial.SACC.Persona.DtoComboPersona
        //                    {
        //                        PersonaId = short.Parse(dr["PersonaId"].ToString()),
        //                        //PersonaDescripcion = dr["PersonaDescripcion"].ToString(),
        //                    };

        //                    res.Datos.Add(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            res.Error = true;
        //            res.TituloError = response.TituloError;
        //            res.MensajeError = response.MensajeError;
        //            res.TipoMensaje = "error";
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        res.Error = true;
        //        res.TituloError = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
        //        res.MensajeError = exc.Message.ToString();
        //        res.TipoMensaje = "error";
        //    }

        //    return res;
        //}


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.Persona obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.Persona oBD = new AccesoDatos.NovaComercial.dbo.Persona();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PersonaId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.Insertar, obj);
                }
                else
                {
                    if (obj.Baja == true)
                    {
                        obj.UsuarioBajaId = obj.UsuarioBajaId;
                    }

                    response = oBD.Actualizar((short)SqlOpciones.Actualizar, obj);
                }

                if (!response.Error)
                {
                    if (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True")
                    {
                        res.Error        = true;
                        res.TituloError  = "(LogicaLegocio) - El registro no se pudo guardar/actualizar.";
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaId"].ToString());

                        //if(response.Resultado.Tables[1].Rows > 0)
                        //{

                        //}
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pPersonaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.Persona oE = new Entidades.NovaComercial.dbo.Persona
                {
                    PersonaId         = pPersonaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.Persona oBD = new AccesoDatos.NovaComercial.dbo.Persona();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PersonaId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }




        public static Modelo.ModeloJsonResponse ProcesaGuion80()
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.DUtil oBD = new AccesoDatos.DUtil();
                oBD.ExecuteNoQuery("MANTENIMIENTO");

                res.Id          = 1;
                res.Error       = false;
                res.Mensaje     = "Proceso terminado exitosamente";
                res.TipoMensaje = "Success";
            }
            catch (Exception ex)
            {
                res.Id           = 0;
                res.Error        = true;
                res.MensajeError = ex.Message.ToString();
                res.TipoMensaje  = "Error";
            }

            return res;
        }




        //public static List<Entidades.NovaComercial.dbo.Persona> Consultar(SqlOpciones pOpcion, int pPersonaId, int pNumSocio, int pCveFamiliar, string pNombre, string pCURP, Boolean? pGenero, int pContratoId, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.Persona oE = new Entidades.NovaComercial.dbo.Persona();

        //    oE.PersonaId          = pPersonaId;
        //    oE.Nombre             = pNombre;
        //    oE.CURP               = pCURP;
        //    oE.Genero             = pGenero;
        //    oE.Filtro_ContratoId  = pContratoId;
        //    oE.Filtro_ServicioId  = new int?(pNumSocio);
        //    //oE.Filtro_CveFamiliar = new int?(pCveFamiliar);

        //    switch (pBaja)
        //    {
        //        case 0:
        //            oE.Baja = false;
        //            break;
        //        case 1:
        //            oE.Baja = true;
        //            break;
        //        default:
        //            oE.Baja = null;
        //            break;
        //    }

        //    DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

        //    List<Entidades.NovaComercial.dbo.Persona> res = new List<Entidades.NovaComercial.dbo.Persona>();
        //    Entidades.NovaComercial.dbo.Persona item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.Persona();

        //            item.PersonaId       = int.Parse(dr["PersonaId"].ToString());
        //            item.Nombre          = dr["Nombre"].ToString();
        //            item.Paterno         = dr["Paterno"].ToString();
        //            item.Materno         = dr["Materno"].ToString();
        //            item.Genero          = Boolean.Parse(dr["Genero"].ToString());
        //            item.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());

        //            if (dr.Table.Columns.Contains("RN"))
        //                item.RN = new bool?(bool.Parse(dr["RN"].ToString()));

        //            if (dr.Table.Columns.Contains("Extranjero"))
        //                item.Extranjero = new bool?(bool.Parse(dr["Extranjero"].ToString()));

        //            item.CampoComplemento_NombreCompleto = dr["Paterno"].ToString() + " " + dr["Materno"].ToString() + ", " + dr["Nombre"].ToString();

        //            //if (dr.Table.Columns.Contains("Edad"))
        //                //item.CampoComplemento_Edad = decimal.Parse(dr["Edad"].ToString());

        //            if (dr.Table.Columns.Contains("NumSocio"))
        //                item.CampoComplemento_SocioId = dr["NumSocio"].ToString();

        //            item.CURP            = dr["CURP"].ToString();

        //            if (dr.Table.Columns.Contains("ContratoId"))
        //                item.CampoComplemento_ContratoId = int.Parse(dr["ContratoId"].ToString());

        //            if (dr.Table.Columns.Contains("CoberturaDefault"))
        //                item.CampoComplemento_ContratoCoberturaDescripcion = dr["CoberturaDefault"].ToString();

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Persona obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.Persona oE = new Entidades.NovaComercial.dbo.Persona();
        //    DataSet ds = new DataSet();

        //    oE.PersonaId                = obj.PersonaId;
        //    oE.Nombre                   = obj.Nombre;
        //    oE.Paterno                  = obj.Paterno;
        //    oE.Materno                  = obj.Materno;
        //    oE.Genero                   = obj.Genero;
        //    oE.FechaNacimiento          = obj.FechaNacimiento;
        //    oE.RN                       = obj.RN;
        //    oE.Extranjero               = obj.Extranjero;
        //    oE.CURP                     = obj.CURP;
        //    oE.CampoComplemento_SocioId = obj.CampoComplemento_SocioId;
        //    oE.UsuarioCreacionId        = obj.UsuarioCreacionId;
        //    oE.UsuarioModificacionId    = obj.UsuarioModificacionId;
        //    oE.Baja                     = Convert.ToBoolean(Convert.ToInt16(0));

        //    if (obj.PersonaId == 0)
        //    {
        //         ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;

        //        res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaId"].ToString());
        //        res.Mensaje      = (res.Id > 0) ? "El registro se actualizo satisfactoriamente." : "";
        //        res.MensajeError = (res.Id < 0) ? ds.Tables[0].Rows[0]["Mensaje"].ToString() : "";
        //        res.Error        = (res.Id > 0) ? false : true;
        //        res.TipoMensaje  = (res.Id > 0) ? "success" : "error";

        //        if (res.Id > 0)
        //        {
        //            List<Entidades.NovaComercial.dbo.Asociado> resAsociado = Asociado.Consultar(SqlOpciones.ConsultaGeneral, 0, oE.CURP, "", "", "", 0);

        //            if (resAsociado.Count > 0)
        //            {
        //                Entidades.EntidadJsonResponse resPersonaAsociado = new Entidades.EntidadJsonResponse();

        //                Entidades.NovaComercial.dbo.PersonaAsociado oE_PersonaAsociado = new Entidades.NovaComercial.dbo.PersonaAsociado();
        //                DataSet dsPersonaAsociado = new DataSet();

        //                oE_PersonaAsociado.PersonaAsociadoId = 0;
        //                oE_PersonaAsociado.PersonaId         = int.Parse(ds.Tables[0].Rows[0]["PersonaId"].ToString());
        //                oE_PersonaAsociado.AsociadoId        = resAsociado[0].AsociadoId;

        //                dsPersonaAsociado = Util.Insertar(SqlOpciones.Insertar, oE_PersonaAsociado).Resultado;
        //            }
        //            else
        //            {
        //                #region SE INSERTA EN TEMPORTAL DE NEXUS
        //                char pad = '0';

        //                Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado objAfiliado = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();
        //                objAfiliado.vchIdAfiliado        = (ds.Tables[0].Rows[0]["PersonaId"].ToString() + "-80").PadLeft(9, pad);
        //                objAfiliado.vchIdentidad         = (ds.Tables[0].Rows[0]["PersonaId"].ToString() + "-80").PadLeft(9, pad);
        //                objAfiliado.vchNombre            = obj.Nombre;
        //                objAfiliado.vchPaterno           = obj.Paterno;
        //                objAfiliado.vchMaterno           = obj.Materno;
        //                objAfiliado.tiEstatus            = 1;
        //                objAfiliado.vchContratante       = "NOVA";
        //                objAfiliado.iNumPoliza           = 1;
        //                objAfiliado.iNumCerti            = 0;
        //                objAfiliado.dtFecIni             = DateTime.Now;
        //                objAfiliado.dtFecFin             = DateTime.Now;
        //                objAfiliado.vchDomicilio         = "POR DEFINIR 0";
        //                objAfiliado.vchColonia           = "";
        //                objAfiliado.vchCiudad            = "";
        //                objAfiliado.vchEstado            = "";
        //                objAfiliado.dtFecNaci            = obj.FechaNacimiento.Value;

        //                if (obj.Genero.HasValue)
        //                {
        //                    if (obj.Genero.Value)
        //                        objAfiliado.siSexo = 651;
        //                    else
        //                        objAfiliado.siSexo = 650;
        //                }

        //                objAfiliado.chCodContrato        = "1";
        //                objAfiliado.chCodEmpresa         = "0400SAC000";
        //                objAfiliado.vchDirEmp            = "";
        //                objAfiliado.vchColEmp            = "";
        //                objAfiliado.vchCPEmp             = "";
        //                objAfiliado.vchTelfEmp           = "";
        //                objAfiliado.siTipoSangre         = 459;
        //                objAfiliado.siEstadoCivil        = 1;
        //                objAfiliado.vchCPAfiliado        = "";
        //                objAfiliado.vchtelfAfiliado      = "";
        //                objAfiliado.vchCiudadEmp         = "";
        //                objAfiliado.vchEstadoEmp         = "";
        //                objAfiliado.vchIdHospitaliza     = "0";
        //                objAfiliado.vchCodMedicoFam      = "AAA";
        //                objAfiliado.siTipoAfiliado       = 0;
        //                objAfiliado.siConfidencial       = 0;
        //                objAfiliado.chrCURP              = obj.CURP.ToString();
        //                objAfiliado.vchReferencia        = "";
        //                objAfiliado.iMunicipio           = -1;
        //                objAfiliado.iMedicoSecundario    = 0;
        //                objAfiliado.tiRequiereEmpresa    = 1;
        //                objAfiliado.tiRequiereExpediente = 1;
        //                objAfiliado.siRelacionTitular    = 0;
        //                objAfiliado.vchIdAfiliadoTitular = (res.Id.ToString() + "-80").PadLeft(9, pad);
        //                objAfiliado.iFechaInduccion      = 0;
        //                objAfiliado.dtFechaCreacion      = DateTime.Now;
        //                objAfiliado.dtFechaActualizacion = DateTime.Now;
        //                objAfiliado.chrCurpp             = null;
        //                objAfiliado.bProceso             = false;
        //                objAfiliado.IdEstadoNacimiento   = 1;
        //                objAfiliado.bCurpTemporal        = false;
        //                objAfiliado.IdMovimiento         = 1; // hacer funcion para calcular el max + 1 de la tabla
        //                objAfiliado.IdColonia            = 3331;
        //                objAfiliado.vcTelefono2          = "";
        //                objAfiliado.vcTelefonoMovil      = "";

        //                Entidades.EntidadJsonResponse resTranDatosAfiliado = new Entidades.EntidadJsonResponse();
        //                resTranDatosAfiliado = Nova_ServiciosMedicos.dbo.TranDatosAfiliado.Guardar(objAfiliado);
        //                #endregion
        //            }
        //        }
        //    }
        //    else
        //    {
        //        ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;

        //        if (ds != null || ds.Tables.Count > 0)
        //        {
        //            Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado tranDatosAfiliado = new Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado();

        //            char paddingChar = '0';
        //            tranDatosAfiliado.vchIdAfiliado = obj.CampoComplemento_SocioId == null ? (obj.PersonaId.ToString() + "-80").PadLeft(9, paddingChar) : obj.CampoComplemento_SocioId;
        //            tranDatosAfiliado.vchNombre     = obj.Nombre;
        //            tranDatosAfiliado.vchPaterno    = obj.Paterno;
        //            tranDatosAfiliado.vchMaterno    = obj.Materno;
        //            tranDatosAfiliado.dtFecNaci     = obj.FechaNacimiento.Value;

        //            if (obj.Genero.HasValue)
        //            {
        //                if (obj.Genero.Value)
        //                    tranDatosAfiliado.siSexo = 651;
        //                else
        //                    tranDatosAfiliado.siSexo = 650;
        //            }

        //            tranDatosAfiliado.chrCURP = obj.CURP.ToString();
        //            tranDatosAfiliado.bProceso = false;
        //            Entidades.EntidadJsonResponse res2 = new Entidades.EntidadJsonResponse();
        //            Nova_ServiciosMedicos.dbo.TranDatosAfiliado.ActualizaDatos(tranDatosAfiliado);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(int pPersonaId, int pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.Persona oE = new Entidades.NovaComercial.dbo.Persona();
        //    DataSet ds = new DataSet();

        //    oE.PersonaId     = pPersonaId;
        //    oE.UsuarioBajaId = pUsuarioId;
        //    oE.Baja          = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["PersonaId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}