using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class ServicioSubrogadoTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoGridServicioSubrogadoTipo> ConsultarGrid(String pServicioSubrogadoTipoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoGridServicioSubrogadoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoGridServicioSubrogadoTipo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoTipoPM
                {
                    Opcion                           = (Int16)SqlOpciones.ConsultaGeneral,
                    ServicioSubrogadoTipoDescripcion = pServicioSubrogadoTipoDescripcion,
                    EstatusId                        = pEstatusId
                };
                
                AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoGridServicioSubrogadoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoGridServicioSubrogadoTipo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoGridServicioSubrogadoTipo
                            {
                                ServicioSubrogadoTipoId          = Int16.Parse(dr["ServicioSubrogadoTipoId"].ToString()),
                                ServicioSubrogadoTipoDescripcion = dr["ServicioSubrogadoTipoDescripcion"].ToString(),
                                EstatusId                        = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo> ConsultarPorId(Int32 pServicioSubrogadoTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoTipoPM
                {
                    Opcion                  = (Int16)SqlOpciones.ConsultaPorId,
                    ServicioSubrogadoTipoId = pServicioSubrogadoTipoId
                };
                
                AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoServicioSubrogadoTipo
                            {
                                ServicioSubrogadoTipoId          = short.Parse(dr["ServicioSubrogadoTipoId"].ToString()),
                                ServicioSubrogadoTipoDescripcion = dr["ServicioSubrogadoTipoDescripcion"].ToString(),
                                EstatusId                        = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo> ConsultarCombo(String pServicioSubrogadoTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoTipoPM
                {
                    Opcion                           = (Int16)SqlOpciones.Lista,
                    ServicioSubrogadoTipoDescripcion = pServicioSubrogadoTipoDescripcion
                };
                
                AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ServicioSubrogadoTipo.DtoComboServicioSubrogadoTipo
                            {
                                ServicioSubrogadoTipoId          = short.Parse(dr["ServicioSubrogadoTipoId"].ToString()),
                                ServicioSubrogadoTipoDescripcion = dr["ServicioSubrogadoTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.ServicioSubrogadoTipo obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ServicioSubrogadoTipoId == 0)
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
                        res.TituloError  = response.TituloError;
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioSubrogadoTipoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pServicioSubrogadoTipoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.ServicioSubrogadoTipo oE = new Entidades.NovaComercial.SACC.ServicioSubrogadoTipo
                {
                    ServicioSubrogadoTipoId = pServicioSubrogadoTipoId,
                    UsuarioBajaId           = pUsuarioId,
                    FechaModificacion       = DateTime.Now,
                    FechaBaja               = DateTime.Now,
                    Baja                    = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogadoTipo();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioSubrogadoTipoId"].ToString());
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