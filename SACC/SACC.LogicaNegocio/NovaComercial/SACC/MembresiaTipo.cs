using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class MembresiaTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoGridMembresiaTipo> ConsultarGrid(String pMembresiaTipoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoGridMembresiaTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoGridMembresiaTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaTipoPM
                {
                    Opcion                   = (Int16)SqlOpciones.ConsultaGeneral,
                    MembresiaTipoDescripcion = pMembresiaTipoDescripcion,
                    EstatusId                = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaTipo oBD = new AccesoDatos.NovaComercial.SACC.MembresiaTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaTipo.DtoGridMembresiaTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaTipo.DtoGridMembresiaTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaTipo.DtoGridMembresiaTipo
                            {
                                MembresiaTipoId          = short.Parse(dr["MembresiaTipoId"].ToString()),
                                MembresiaTipoDescripcion = dr["MembresiaTipoDescripcion"].ToString(),
                                EstatusId                = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoMembresiaTipo> ConsultarPorId(Int32 pMembresiaTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoMembresiaTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoMembresiaTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaTipoPM
                {
                    Opcion          = (Int16)SqlOpciones.ConsultaPorId,
                    MembresiaTipoId = pMembresiaTipoId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaTipo oBD = new AccesoDatos.NovaComercial.SACC.MembresiaTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaTipo.DtoMembresiaTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaTipo.DtoMembresiaTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaTipo.DtoMembresiaTipo
                            {
                                MembresiaTipoId          = short.Parse(dr["MembresiaTipoId"].ToString()),
                                MembresiaTipoDescripcion = dr["MembresiaTipoDescripcion"].ToString(),
                                EstatusId                = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoComboMembresiaTipo> ConsultarCombo(String pMembresiaTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoComboMembresiaTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaTipo.DtoComboMembresiaTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaTipoPM
                {
                    Opcion                   = (Int16)SqlOpciones.Lista,
                    MembresiaTipoDescripcion = pMembresiaTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.MembresiaTipo oBD = new AccesoDatos.NovaComercial.SACC.MembresiaTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaTipo.DtoComboMembresiaTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaTipo.DtoComboMembresiaTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaTipo.DtoComboMembresiaTipo
                            {
                                MembresiaTipoId          = short.Parse(dr["MembresiaTipoId"].ToString()),
                                MembresiaTipoDescripcion = dr["MembresiaTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.MembresiaTipo obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                AccesoDatos.NovaComercial.SACC.MembresiaTipo oBD = new AccesoDatos.NovaComercial.SACC.MembresiaTipo();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();
                
                if (obj.MembresiaTipoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaTipoId"].ToString());
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pMembresiaTipoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.MembresiaTipo oE = new Entidades.NovaComercial.SACC.MembresiaTipo
                {
                    MembresiaTipoId   = pMembresiaTipoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.MembresiaTipo oBD = new AccesoDatos.NovaComercial.SACC.MembresiaTipo();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);
                
                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaTipoId"].ToString());
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