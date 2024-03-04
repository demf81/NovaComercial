using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class ServicioTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoGridServicioTipo> ConsultarGrid(String pServicioTipoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoGridServicioTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoGridServicioTipo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.ServicioTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ServicioTipoPM
                {
                    Opcion                  = (Int16)SqlOpciones.ConsultaGeneral,
                    ServicioTipoDescripcion = pServicioTipoDescripcion,
                    //Baja                    = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };
                
                AccesoDatos.NovaComercial.dbo.ServicioTipo oBD = new AccesoDatos.NovaComercial.dbo.ServicioTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ServicioTipo.DtoGridServicioTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ServicioTipo.DtoGridServicioTipo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ServicioTipo.DtoGridServicioTipo
                            {
                                ServicioTipoId          = short.Parse(dr["ServicioTipoId"].ToString()),
                                ServicioTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
                                Baja                    = bool.Parse(dr["Baja"].ToString())
                            };
                            
                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }
            
            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoServicioTipo> ConsultarPorId(Int32 pServicioTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoServicioTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoServicioTipo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.ServicioTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ServicioTipoPM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaPorId,
                    ServicioTipoId = pServicioTipoId
                };
                
                AccesoDatos.NovaComercial.dbo.ServicioTipo oBD = new AccesoDatos.NovaComercial.dbo.ServicioTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ServicioTipo.DtoServicioTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ServicioTipo.DtoServicioTipo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ServicioTipo.DtoServicioTipo
                            {
                                ServicioTipoId          = short.Parse(dr["ServicioTipoId"].ToString()),
                                ServicioTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
                                Baja                    = bool.Parse(dr["Baja"].ToString())
                            };
                            
                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }
            
            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo> ConsultarCombo(String pServicioTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.ServicioTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ServicioTipoPM
                {
                    Opcion                  = (Int16)SqlOpciones.Lista,
                    ServicioTipoDescripcion = pServicioTipoDescripcion
                };
                
                AccesoDatos.NovaComercial.dbo.ServicioTipo oBD = new AccesoDatos.NovaComercial.dbo.ServicioTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ServicioTipo.DtoComboServicioTipo
                            {
                                ServicioTipoId          = short.Parse(dr["ServicioTipoId"].ToString()),
                                ServicioTipoDescripcion = dr["ServicioTipoDescripcion"].ToString()
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}