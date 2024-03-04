using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Paquete
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoGridPaquete> ConsultarGrid(String pPaqueteDescripcion, Int16 pPaqueteTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoGridPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoGridPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaquetePM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    PaqueteDescripcion = pPaqueteDescripcion,
                    PaqueteTipoId      = pPaqueteTipoId,
                    EstatusId          = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Paquete oBD = new AccesoDatos.NovaComercial.dbo.Paquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Paquete.DtoGridPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Paquete.DtoGridPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Paquete.DtoGridPaquete
                            {
                                PaqueteId              = Int32.Parse(dr["PaqueteId"].ToString()),
                                Codigo                 = dr["Codigo"].ToString(),
                                PaqueteDescripcion     = dr["PaqueteDescripcion"].ToString(),
                                Genero                 = dr["Genero"].ToString(),
                                RangoEdad              = dr["RangoEdad"].ToString(),
                                PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString(),
                                PrecioLista            = Decimal.Parse(dr["PrecioLista"].ToString()),
                                EstatusId              = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoGridCtrlUserBusquedaPaquete> ConsultarGridCtrlUSerBusqueda(String pPaqueteDescripcion, Int16 pPaqueteTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoGridCtrlUserBusquedaPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoGridCtrlUserBusquedaPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaquetePM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    PaqueteDescripcion = pPaqueteDescripcion,
                    PaqueteTipoId      = pPaqueteTipoId,
                    EstatusId          = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Paquete oBD = new AccesoDatos.NovaComercial.dbo.Paquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Paquete.DtoGridCtrlUserBusquedaPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Paquete.DtoGridCtrlUserBusquedaPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Paquete.DtoGridCtrlUserBusquedaPaquete
                            {
                                PaqueteId              = Int32.Parse(dr["PaqueteId"].ToString()),
                                PaqueteDescripcion     = dr["PaqueteDescripcion"].ToString(),
                                PaqueteTipoId          = Int32.Parse(dr["PaqueteTipoId"].ToString()),
                                PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString(),
                                EstatusId              = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoPaquete> ConsultarPorId(Int32 pPaqueteId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaquetePM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaPorId,
                    PaqueteId = pPaqueteId
                };

                AccesoDatos.NovaComercial.dbo.Paquete oBD = new AccesoDatos.NovaComercial.dbo.Paquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Paquete.DtoPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Paquete.DtoPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Paquete.DtoPaquete
                            {
                                PaqueteId          = Int32.Parse(dr["PaqueteId"].ToString()),
                                Codigo             = dr["Codigo"].ToString(),
                                PaqueteDescripcion = dr["PaqueteDescripcion"].ToString(),
                                PaqueteTipoId      = Int16.Parse(dr["PaqueteTipoId"].ToString()),
                                GeneroId           = Int16.Parse(dr["GeneroId"].ToString()),
                                EdadDesde          = Int16.Parse(dr["EdadDesde"].ToString()),
                                EdadHasta          = Int16.Parse(dr["EdadHasta"].ToString()),
                                PrecioLista        = Decimal.Parse(dr["PrecioLista"].ToString()),
                                PrecioVenta        = Decimal.Parse(dr["PrecioVenta"].ToString()),
                                EstatusId          = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoComboPaquete> ConsultarCombo(String pPaqueteDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoComboPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Paquete.DtoComboPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaquetePM
                {
                    Opcion             = (Int16)SqlOpciones.Lista,
                    PaqueteDescripcion = pPaqueteDescripcion
                };

                AccesoDatos.NovaComercial.dbo.Paquete oBD = new AccesoDatos.NovaComercial.dbo.Paquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Paquete.DtoComboPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Paquete.DtoComboPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Paquete.DtoComboPaquete
                            {
                                PaqueteId          = Int32.Parse(dr["PaqueteId"].ToString()),
                                PaqueteDescripcion = dr["PaqueteDescripcion"].ToString()
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
                Modelo.Parametro.NovaComercial.dbo.PaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaquetePM()
                {
                    Opcion = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    PaqueteDescripcion = pServicioDescripcion,
                    PaqueteTipoId = pServicioTipoId,
                    EstatusId = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Paquete oBD = new AccesoDatos.NovaComercial.dbo.Paquete();
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
                                AreaNegocioId = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId = Int32.Parse(dr["ServicioId"].ToString()),
                                ItemId = Int32.Parse(dr["PaqueteId"].ToString()),
                                ItemDescripcion = dr["PaqueteDescripcion"].ToString(),
                                ItemTipoId = Int16.Parse(dr["ServicioTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
                                Costo = Decimal.Parse(dr["Costo"].ToString()),
                                Precio = Decimal.Parse(dr["Precio"].ToString()),
                                Anticipo = Decimal.Parse(dr["Anticipo"].ToString()),
                                TarifaId = Int32.Parse(dr["TarifaId"].ToString()),
                                CampaniaId = Int32.Parse(dr["CampaniaId"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error = true;
                    res.TituloError = response.TituloError;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error = true;
                res.TituloError = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.Paquete obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.Paquete oBD = new AccesoDatos.NovaComercial.dbo.Paquete();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PaqueteId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PaqueteId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pPaqueteId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.Paquete oE = new Entidades.NovaComercial.dbo.Paquete
                {
                    PaqueteId         = pPaqueteId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.Paquete oBD = new AccesoDatos.NovaComercial.dbo.Paquete();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PaqueteId"].ToString());
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



        //public static List<Entidades.NovaComercial.dbo.Paquete> Consultar(SqlOpciones pOpcion, Int32 pPaqueteId, String pPaqueteDescripcion, Int16 pPaqueteTipoId, Int16 pBaja)
        //{
        //    Entidades.NovaComercial.dbo.Paquete oE = new Entidades.NovaComercial.dbo.Paquete();

        //    oE.PaqueteId     = pPaqueteId;
        //    oE.PaqueteTipoId = pPaqueteTipoId;

        //    if (pPaqueteDescripcion != "")
        //        oE.PaqueteDescripcion = pPaqueteDescripcion;

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

        //    List<Entidades.NovaComercial.dbo.Paquete> res = new List<Entidades.NovaComercial.dbo.Paquete>();
        //    Entidades.NovaComercial.dbo.Paquete item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.Paquete();

        //            item.PaqueteId          = short.Parse(dr["PaqueteId"].ToString());
        //            item.PaqueteDescripcion = dr["PaqueteDescripcion"].ToString();
        //            item.PaqueteTipoId      = short.Parse(dr["PaqueteTipoId"].ToString());

        //            if (dr.Table.Columns.Contains("PaqueteTipoDescripcion"))
        //                item.CampoComplemento_PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("GeneroId"))
        //                item.GeneroId       = short.Parse(dr["GeneroId"].ToString());

        //            //if (dr.Table.Columns.Contains("Genero"))
        //            //    item.CampoComplemento_Genero = dr["Genero"].ToString();

        //            //if (dr.Table.Columns.Contains("RangoEdad"))
        //            //    item.CampoComplemento_RangoEdad = dr["RangoEdad"].ToString();

        //            if (dr.Table.Columns.Contains("EdadDesde"))
        //                item.EdadDesde      = short.Parse(dr["EdadDesde"].ToString());

        //            if (dr.Table.Columns.Contains("EdadHasta"))
        //                item.EdadHasta      = short.Parse(dr["EdadHasta"].ToString());

        //            item.Codigo             = dr["Codigo"].ToString();
        //            item.PrecioLista        = decimal.Parse(dr["PrecioLista"].ToString());
        //            item.PrecioVenta        = decimal.Parse(dr["PrecioVenta"].ToString());

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Paquete obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.Paquete oE = new Entidades.NovaComercial.dbo.Paquete();
        //    DataSet ds = new DataSet();

        //    oE.PaqueteId             = obj.PaqueteId;
        //    oE.PaqueteDescripcion    = obj.PaqueteDescripcion;
        //    oE.AreaNegocioId         = 1;
        //    oE.PaqueteTipoId         = obj.PaqueteTipoId;
        //    oE.GeneroId              = obj.GeneroId;
        //    oE.EdadDesde             = obj.EdadDesde;
        //    oE.EdadHasta             = obj.EdadHasta;
        //    oE.Codigo                = obj.Codigo;
        //    oE.PrecioLista           = obj.PrecioLista;
        //    oE.PrecioVenta           = obj.PrecioVenta;
        //    oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
        //    oE.UsuarioModificacionId = obj.UsuarioModificacionId;
        //    oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

        //    if (oE.PaqueteId == 0)
        //    {
        //        ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
        //    }
        //    else
        //    {
        //        if (obj.Baja == true)
        //        {
        //            oE.UsuarioBajaId = obj.UsuarioBajaId;
        //        }

        //        ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;
        //    }

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["PaqueteId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(Int32 pPaqueteId, Int32 pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.Paquete oE = new Entidades.NovaComercial.dbo.Paquete();
        //    DataSet ds = new DataSet();

        //    oE.PaqueteId     = pPaqueteId;
        //    oE.UsuarioBajaId = pUsuarioId;
        //    oE.Baja          = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;
                
        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["PaqueteId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}