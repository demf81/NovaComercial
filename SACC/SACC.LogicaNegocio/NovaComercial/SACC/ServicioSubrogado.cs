using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class ServicioSubrogado
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoGridServicioSubrogado> ConsultarGrid(String pServicioSubrogadoDescripcion, String pCodigo, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoGridServicioSubrogado> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoGridServicioSubrogado>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoPM
                {
                    Opcion                       = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ServicioSubrogadoDescripcion = pServicioSubrogadoDescripcion,
                    Codigo                       = pCodigo,
                    EstatusId                   = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.ServicioSubrogado oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogado();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ServicioSubrogado.DtoGridServicioSubrogado item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoGridServicioSubrogado>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ServicioSubrogado.DtoGridServicioSubrogado
                            {
                                ServicioSubrogadoId              = short.Parse(dr["ServicioSubrogadoId"].ToString()),
                                ServicioSubrogadoDescripcion     = dr["ServicioSubrogadoDescripcion"].ToString(),
                                Codigo                           = dr["Codigo"].ToString(),
                                ServicioSubrogadoTipoId          = Int16.Parse(dr["ServicioSubrogadoTipoId"].ToString()),
                                ServicioSubrogadoTipoDescripcion = dr["ServicioSubrogadoTipoDescripcion"].ToString(),
                                Costo                            = Decimal.Parse(dr["Costo"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado> ConsultarPorId(Int32 pServicioSubrogadoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoPM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaPorId,
                    ServicioSubrogadoId = pServicioSubrogadoId
                };

                AccesoDatos.NovaComercial.SACC.ServicioSubrogado oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogado();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.ServicioSubrogado.DtoServicioSubrogado
                            {
                                ServicioSubrogadoId          = short.Parse(dr["ServicioSubrogadoId"].ToString()),
                                ServicioSubrogadoDescripcion = dr["ServicioSubrogadoDescripcion"].ToString(),
                                Codigo                       = dr["Codigo"].ToString(),
                                ServicioSubrogadoTipoId      = Int16.Parse(dr["ServicioSubrogadoTipoId"].ToString()),
                                Costo                        = Decimal.Parse(dr["Costo"].ToString()),
                                EstatusId                    = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserArticuloConPrecioGrid(String pServicioDescripcion, Int16 pServicioTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioSubrogadoPM()
                {
                    Opcion                       = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    ServicioSubrogadoDescripcion = pServicioDescripcion,
                    ServicioSubrogadoTipoId      = pServicioTipoId,
                    EstatusId                    = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.ServicioSubrogado oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogado();
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
                                ItemId              = Int32.Parse(dr["ServicioSubrogadoId"].ToString()),
                                ItemDescripcion     = dr["ServicioSubrogadoDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ServicioSubrogadoTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ServicioSubrogadoTipoDescripcion"].ToString(),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                Anticipo            = Decimal.Parse(dr["Anticipo"].ToString()),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.ServicioSubrogado obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.ServicioSubrogado oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogado();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ServicioSubrogadoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioSubrogadoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pServicioSubrogadoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.ServicioSubrogado oE = new Entidades.NovaComercial.SACC.ServicioSubrogado
                {
                    ServicioSubrogadoId = pServicioSubrogadoId,
                    UsuarioBajaId       = pUsuarioId,
                    FechaModificacion   = DateTime.Now,
                    FechaBaja           = DateTime.Now,
                    Baja                = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.ServicioSubrogado oBD = new AccesoDatos.NovaComercial.SACC.ServicioSubrogado();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioSubrogadoId"].ToString());
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