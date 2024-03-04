using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class ServicioAdministrativo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoGridServicioAdministrativo> ConsultarGrid(String pServicioAdministrativoDescripcion, String pCodigo, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoGridServicioAdministrativo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoGridServicioAdministrativo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioAdministrativoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioAdministrativoPM
                {
                    Opcion                            = (Int16)SqlOpciones.ConsultaGeneral,
                    ServicioAdministrativoDescripcion = pServicioAdministrativoDescripcion,
                    Codigo                            = pCodigo,
                    EstatusId                         = pEstatusId
                };
                
                AccesoDatos.NovaComercial.SACC.ServicioAdministrativo oBD = new AccesoDatos.NovaComercial.SACC.ServicioAdministrativo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoGridServicioAdministrativo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoGridServicioAdministrativo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoGridServicioAdministrativo
                            {
                                ServicioAdministrativoId          = short.Parse(dr["ServicioAdministrativoId"].ToString()),
                                ServicioAdministrativoDescripcion = dr["ServicioAdministrativoDescripcion"].ToString(),
                                Codigo                            = dr["Codigo"].ToString(),
                                Costo                             = Decimal.Parse(dr["Costo"].ToString()),
                                EstatusId                         = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo> ConsultarPorId(Int32 pServicioAdministrativoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioAdministrativoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioAdministrativoPM
                {
                    Opcion                   = (Int16)SqlOpciones.ConsultaPorId,
                    ServicioAdministrativoId = pServicioAdministrativoId
                };
                
                AccesoDatos.NovaComercial.SACC.ServicioAdministrativo oBD = new AccesoDatos.NovaComercial.SACC.ServicioAdministrativo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ServicioAdministrativo.DtoServicioAdministrativo
                            {
                                ServicioAdministrativoId          = short.Parse(dr["ServicioAdministrativoId"].ToString()),
                                ServicioAdministrativoDescripcion = dr["ServicioAdministrativoDescripcion"].ToString(),
                                Codigo                            = dr["Codigo"].ToString(),
                                Costo                             = Decimal.Parse(dr["Costo"].ToString()),
                                EstatusId                         = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserArticuloConPrecioGrid(String pServicioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioAdministrativoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioAdministrativoPM()
                {
                    Opcion                            = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    ServicioAdministrativoDescripcion = pServicioDescripcion,
                    EstatusId                         = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.ServicioAdministrativo oBD = new AccesoDatos.NovaComercial.SACC.ServicioAdministrativo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio
                            {
                                AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId          = Int32.Parse(dr["ServicioId"].ToString()),
                                ItemId              = Int32.Parse(dr["ServicioAdministrativoId"].ToString()),
                                ItemDescripcion     = dr["ServicioAdministrativoDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ServicioTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                PrecioConIva        = Decimal.Parse(dr["PrecioConIva"].ToString()),
                                Anticipo            = Decimal.Parse(dr["Anticipo"].ToString()),
                                Iva                 = Decimal.Parse(dr["Iva"].ToString()),
                                TarifaId            = Int32.Parse(dr["TarifaId"].ToString()),
                                CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString())
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.ServicioAdministrativo obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.ServicioAdministrativo oBD = new AccesoDatos.NovaComercial.SACC.ServicioAdministrativo();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ServicioAdministrativoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioAdministrativoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pServicioAdministrativoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.ServicioAdministrativo oE = new Entidades.NovaComercial.SACC.ServicioAdministrativo
                {
                    ServicioAdministrativoId = pServicioAdministrativoId,
                    UsuarioBajaId            = pUsuarioId,
                    FechaModificacion        = DateTime.Now,
                    FechaBaja                = DateTime.Now,
                    Baja                     = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.ServicioAdministrativo oBD = new AccesoDatos.NovaComercial.SACC.ServicioAdministrativo();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioAdministrativoId"].ToString());
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