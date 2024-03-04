using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class MembresiaRenovacion
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoGridMembresiaRenovacion> ConsultarGrid(DateTime? pFechaInicio, DateTime? pFechaFin, DateTime? pVigenciaInicio, DateTime? pVigenciaFin, Int16 pMembresiaTipoId, String pNumSocio, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoGridMembresiaRenovacion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoGridMembresiaRenovacion>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaRenovacionPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaRenovacionPM
                {
                    Opcion          = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    FechaInicio     = pFechaInicio,
                    FechaFin        = pFechaFin,
                    VigenciaInicio  = pVigenciaInicio,
                    VigenciaFin     = pVigenciaFin,
                    NumSocio        = pNumSocio,
                    MembresiaTipoId = pMembresiaTipoId,
                    EstatusId       = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaRenovacion oBD = new AccesoDatos.NovaComercial.SACC.MembresiaRenovacion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoGridMembresiaRenovacion item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoGridMembresiaRenovacion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoGridMembresiaRenovacion
                            {
                                MembresiaId              = Int32.Parse(dr["MembresiaId"].ToString()),
                                Fecha                    = dr["Fecha"].ToString(),
                                Vigencia                 = dr["Vigencia"].ToString(),
                                MembresiaTipoDescripcion = dr["MembresiaTipoDescripcion"].ToString(),
                                NumSocio                 = dr["NumSocio"].ToString(),
                                NombreComplento          = dr["Paterno"].ToString() + " " + dr["Materno"] + ", " + dr["Nombre"].ToString(),
                                CantidadBeneficiarios    = Int32.Parse(dr["CantidadBeneficiarios"].ToString()),
                                CantidadAfiliados        = Int32.Parse(dr["CantidadAfiliados"].ToString()),
                                CantidadAdicionales      = Int32.Parse(dr["CantidadAdicionales"].ToString()),
                                MembresiaEstatusId       = Int16.Parse(dr["MembresiaEstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacionQ> ConsultarPorId(Int32 pMembresiaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacionQ> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacionQ>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaRenovacionPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaRenovacionPM
                {
                    Opcion      = (Int16)SqlOpciones.ConsultaPorIdConJoin,
                    MembresiaId = pMembresiaId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaRenovacion oBD = new AccesoDatos.NovaComercial.SACC.MembresiaRenovacion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacionQ item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacionQ>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaRenovacion.DtoMembresiaRenovacionQ
                            {
                                MembresiaId         = Int32.Parse(dr["MembresiaId"].ToString()),
                                MembresiaTipoId     = Int16.Parse(dr["MembresiaTipoId"].ToString()),
                                FechaContrato       = DateTime.Parse(dr["Fecha"].ToString()),
                                Contratante         = dr["Paterno"].ToString() + " " + dr["Materno"].ToString() + ", " + dr["Nombre"].ToString(),
                                FechaVigencia       = DateTime.Parse(dr["Vigencia"].ToString()),
                                CantidadAfiliados   = Int64.Parse(dr["CantidadAfiliados"].ToString()),
                                CantidadAdicionales = Int64.Parse(dr["CantidadAdicionales"].ToString()),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.MembresiaRenovacion obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.MembresiaRenovacion oBD = new AccesoDatos.NovaComercial.SACC.MembresiaRenovacion();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.MembresiaRenovacionId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaRenovacionId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pMembresiaRenovacionId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.MembresiaRenovacion oE = new Entidades.NovaComercial.SACC.MembresiaRenovacion
                {
                    MembresiaRenovacionId = pMembresiaRenovacionId,
                    UsuarioBajaId         = pUsuarioId,
                    FechaModificacion     = DateTime.Now,
                    FechaBaja             = DateTime.Now,
                    Baja                  = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.MembresiaRenovacion oBD = new AccesoDatos.NovaComercial.SACC.MembresiaRenovacion();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaRenovacionId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.Resultado.Tables[0].Rows[0]["Error"].ToString();
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}