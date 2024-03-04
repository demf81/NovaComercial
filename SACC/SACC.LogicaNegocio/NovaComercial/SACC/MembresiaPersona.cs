using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class MembresiaPersona
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona> ConsultarGrid(Int32 pMembresiaId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaPersonaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaPersonaPM
                {
                    Opcion       = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    MembresiaId  = pMembresiaId,
                    PersonaId    = -1,
                    ParentescoId = -1,
                    EstatusId    = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaPersona oBD = new AccesoDatos.NovaComercial.SACC.MembresiaPersona();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaPersona.DtoGridMembresiaPersona
                            {
                                MembresiaPersonaId    = Int32.Parse(dr["MembresiaPersonaId"].ToString()),
                                MembresiaId           = Int32.Parse(dr["MembresiaId"].ToString()),
                                PersonaId             = Int32.Parse(dr["PersonaId"].ToString()),
                                NumSocio              = dr["NumSocio"].ToString(),
                                NombreCompleto        = dr["NombreCompleto"].ToString(),
                                Edad                  = Int16.Parse(dr["Edad"].ToString()),
                                ParentescoId          = Int32.Parse(dr["ParentescoId"].ToString()),
                                ParentescoDescripcion = dr["ParentescoDescripcion"].ToString(),
                                EstatusId             = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona> ConsultarPorId(Int32 pMembresiaPersonaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaPersonaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaPersonaPM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaPorId,
                    //MembresiaPersonaId = pMembresiaPersonaId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaPersona oBD = new AccesoDatos.NovaComercial.SACC.MembresiaPersona();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaPersona.DtoMembresiaPersona
                            {
                                MembresiaPersonaId = short.Parse(dr["MembresiaPersonaId"].ToString()),
                                //MembresiaPersonaDescripcion = dr["MembresiaPersonaDescripcion"].ToString(),
                                EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.MembresiaPersona obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.MembresiaPersona oBD = new AccesoDatos.NovaComercial.SACC.MembresiaPersona();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.MembresiaPersonaId == 0)
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
                        res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaPersonaId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pMembresiaPersonaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.MembresiaPersona oE = new Entidades.NovaComercial.SACC.MembresiaPersona
                {
                    MembresiaPersonaId = pMembresiaPersonaId,
                    UsuarioBajaId      = pUsuarioId,
                    FechaModificacion  = DateTime.Now,
                    FechaBaja          = DateTime.Now,
                    Baja               = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.MembresiaPersona oBD = new AccesoDatos.NovaComercial.SACC.MembresiaPersona();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaPersonaId"].ToString());
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}