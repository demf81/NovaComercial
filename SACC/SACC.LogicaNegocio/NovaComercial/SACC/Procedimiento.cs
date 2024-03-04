using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Procedimiento
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Procedimiento.DtoGridProcedimiento> ConsultarGrid(String pProcedimientoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Procedimiento.DtoGridProcedimiento> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Procedimiento.DtoGridProcedimiento>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ProcedimientoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ProcedimientoPM
                {
                    Opcion                   = (Int16)SqlOpciones.ConsultaGeneral,
                    ProcedimientoDescripcion = pProcedimientoDescripcion,
                    EstatusId                = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Procedimiento oBD = new AccesoDatos.NovaComercial.SACC.Procedimiento();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Procedimiento.DtoGridProcedimiento item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Procedimiento.DtoGridProcedimiento>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Procedimiento.DtoGridProcedimiento
                            {
                                ProcedimientoId          = Int16.Parse(dr["ProcedimientoId"].ToString()),
                                ProcedimientoDescripcion = dr["ProcedimientoDescripcion"].ToString(),
                                Costo                    = Decimal.Parse(dr["Costo"].ToString()),
                                PorcentajeAnticipo       = Decimal.Parse(dr["PorcentajeAnticipo"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Procedimiento.DtoProcedimiento> ConsultarPorId(Int32 pProcedimientoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Procedimiento.DtoProcedimiento> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Procedimiento.DtoProcedimiento>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ProcedimientoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ProcedimientoPM
                {
                    Opcion          = (Int16)SqlOpciones.ConsultaPorId,
                    ProcedimientoId = pProcedimientoId
                };

                AccesoDatos.NovaComercial.SACC.Procedimiento oBD = new AccesoDatos.NovaComercial.SACC.Procedimiento();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Procedimiento.DtoProcedimiento item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Procedimiento.DtoProcedimiento>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Procedimiento.DtoProcedimiento
                            {
                                ProcedimientoId          = Int32.Parse(dr["ProcedimientoId"].ToString()),
                                ProcedimientoDescripcion = dr["ProcedimientoDescripcion"].ToString(),
                                ServicioId               = Int32.Parse(dr["ServicioId"].ToString()),
                                Costo                    = Decimal.Parse(dr["Costo"].ToString()),
                                PorcentajeAnticipo       = Decimal.Parse(dr["PorcentajeAnticipo"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserArticuloConPrecioGrid(String pServicioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ProcedimientoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ProcedimientoPM()
                {
                    Opcion                   = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    ProcedimientoDescripcion = pServicioDescripcion,
                    EstatusId                = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Procedimiento oBD = new AccesoDatos.NovaComercial.SACC.Procedimiento();
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
                                ItemId              = Int32.Parse(dr["ProcedimientoId"].ToString()),
                                ItemDescripcion     = dr["ProcedimientoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Procedimiento obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Procedimiento oBD = new AccesoDatos.NovaComercial.SACC.Procedimiento();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ProcedimientoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ProcedimientoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pProcedimientoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.Procedimiento oE = new Entidades.NovaComercial.SACC.Procedimiento
                {
                    ProcedimientoId   = pProcedimientoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Procedimiento oBD = new AccesoDatos.NovaComercial.SACC.Procedimiento();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ProcedimientoId"].ToString());
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