using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Cirugia
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoGridCirugia> ConsultarGrid(String pCirugiaDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoGridCirugia> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoGridCirugia>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.CirugiaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.CirugiaPM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneral,
                    CirugiaDescripcion = pCirugiaDescripcion,
                    //Baja               = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };
                
                AccesoDatos.NovaComercial.dbo.Cirugia oBD = new AccesoDatos.NovaComercial.dbo.Cirugia();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Cirugia.DtoGridCirugia item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Cirugia.DtoGridCirugia>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Cirugia.DtoGridCirugia
                            {
                                CirugiaId          = int.Parse(dr["CirugiaId"].ToString()),
                                CirugiaDescripcion = dr["CirugiaDescripcion"].ToString(),
                                Duracion           = int.Parse(dr["DuracionMin"].ToString()),
                                Costo              = decimal.Parse(dr["Precio"].ToString()),
                                Baja               = bool.Parse(dr["Baja"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoCirugia> ConsultarPorId(Int32 pCirugiaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoCirugia> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Cirugia.DtoCirugia>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.CirugiaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.CirugiaPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaPorId,
                    CirugiaId = pCirugiaId
                };

                AccesoDatos.NovaComercial.dbo.Cirugia oBD = new AccesoDatos.NovaComercial.dbo.Cirugia();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Cirugia.DtoCirugia item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Cirugia.DtoCirugia>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Cirugia.DtoCirugia
                            {
                                CirugiaId          = short.Parse(dr["CirugiaId"].ToString()),
                                CirugiaDescripcion = dr["CirugiaDescripcion"].ToString(),
                                Baja               = bool.Parse(dr["Baja"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserCirugiaConPrecioGrid(String pServicioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.CirugiaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.CirugiaPM()
                {
                    Opcion             = 1, //(Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    CirugiaDescripcion = pServicioDescripcion,
                    //Baja               = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };

                AccesoDatos.NovaComercial.dbo.Cirugia oBD = new AccesoDatos.NovaComercial.dbo.Cirugia();
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
                                ItemId              = Int32.Parse(dr["CirugiaId"].ToString()),
                                ItemDescripcion     = dr["CirugiaDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ServicioTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.Cirugia obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.Cirugia oE = new Entidades.NovaComercial.dbo.Cirugia
                {
                    CirugiaId             = obj.CirugiaId,
                    CirugiaDescripcion    = obj.CirugiaDescripcion,
                    UsuarioCreacionId     = obj.UsuarioCreacionId,
                    UsuarioModificacionId = obj.UsuarioModificacionId,
                    FechaModificacion     = DateTime.Now,
                    Baja                  = Convert.ToBoolean(Convert.ToInt16(obj.Baja))
                };

                AccesoDatos.NovaComercial.dbo.Cirugia oBD = new AccesoDatos.NovaComercial.dbo.Cirugia();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (oE.CirugiaId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.Insertar, oE);
                }
                else
                {
                    if (obj.Baja == true)
                    {
                        oE.UsuarioBajaId = obj.UsuarioBajaId;
                    }

                    response = oBD.Actualizar((short)SqlOpciones.Actualizar, oE);
                }

                res.Id           = int.Parse(response.Resultado.Tables[0].Rows[0]["CirugiaId"].ToString());
                res.Mensaje      = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                res.MensajeError = (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True" ? response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString() : "");
                res.Error        = (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True" ? true : false);
                res.TipoMensaje  = (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True" ? "error" : "success");
            }
            catch (Exception exc)
            {
                res.Id           = -1;
                res.Mensaje      = "";
                res.MensajeError = exc.Message.ToString();
                res.Error        = true;
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pCirugiaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.Cirugia oE = new Entidades.NovaComercial.dbo.Cirugia
                {
                    CirugiaId         = pCirugiaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.Cirugia oBD = new AccesoDatos.NovaComercial.dbo.Cirugia();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                res.Id           = int.Parse(response.Resultado.Tables[0].Rows[0]["CirugiaId"].ToString());
                res.Mensaje      = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                res.MensajeError = (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True" ? response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString() : "");
                res.Error        = (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True" ? true : false);
                res.TipoMensaje  = (response.Resultado.Tables[0].Rows[0]["Error"].ToString() == "True" ? "error" : "success");
            }
            catch (Exception exc)
            {
                res.Id           = -1;
                res.Mensaje      = "";
                res.MensajeError = exc.Message.ToString();
                res.Error        = true;
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}