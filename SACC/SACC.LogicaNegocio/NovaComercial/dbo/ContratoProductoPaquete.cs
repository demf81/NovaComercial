using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class ContratoProductoPaquete
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaquete> ConsultarGrid(Int32 pContratoProductoId, Int32 pPaqueteId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ContratoProductoId = pContratoProductoId,
                    PaqueteId = pPaqueteId,
                    EstatusId = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaquete
                            {
                                ContratoProductoPaqueteId = Int32.Parse(dr["ContratoProductoPaqueteId"].ToString()),
                                PaqueteId = Int32.Parse(dr["PaqueteId"].ToString()),
                                PaqueteDescripcion = dr["PaqueteDescripcion"].ToString(),
                                EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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
                res.TituloError = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete> ConsultarPorId(Int32 pContratoProductoPaqueteId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoProductoPaqueteId = pContratoProductoPaqueteId
                };

                AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoContratoProductoPaquete
                            {
                                ContratoProductoPaqueteId = Int32.Parse(dr["ContratoProductoPaqueteId"].ToString()),
                                //ContratoProductoPaqueteDescripcion = dr["ContratoProductoPaqueteDescripcion"].ToString(),
                                EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaqueteVentaUnitaria> ConsultarPorContratoProducto(Int32 pContratoProductoId, Int32 pPaqueteId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaqueteVentaUnitaria> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaqueteVentaUnitaria>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM
                {
                    Opcion             = (Int16)SqlOpciones.ListaContratoProductoPorProducto,
                    ContratoProductoId = pContratoProductoId,
                    PaqueteId          = pPaqueteId
                };

                AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaqueteVentaUnitaria item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaqueteVentaUnitaria>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoGridContratoProductoPaqueteVentaUnitaria
                            {
                                VentaUnitariaDetalleId     = 0,
                                VentaUnitariaId            = 0,
                                VentaUnitariaDetalleTipoId = 1,
                                itemId                     = Int32.Parse(dr["PaqueteId"].ToString()),
                                Cantidad                   = 1,
                                ArticuloDescripcion        = dr["PaqueteDescripcion"].ToString(),
                                Precio                     = Decimal.Parse(dr["PrecioVentaPublico"].ToString()),
                                Subtotal                   = Decimal.Parse(dr["PrecioVentaPublico"].ToString()),
                                Amparado                   = true
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete> ConsultarCombo(Int32 pContratoProductoId, Int32 pPersonaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoProductoPaquetePM
                {
                    Opcion             = (Int16)SqlOpciones.ListaContratoProductoPorPersona,
                    ContratoProductoId = pContratoProductoId,
                    PersonaId          = pPersonaId
                };

                AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoProductoPaquete.DtoComboContratoProductoPaquete
                            {
                                PaqueteId          = Int32.Parse(dr["PaqueteId"].ToString()),
                                PaqueteDescripcion = dr["PaqueteDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoProductoPaquete obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoProductoPaqueteId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoProductoPaqueteId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pContratoProductoPaqueteId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.ContratoProductoPaquete oE = new Entidades.NovaComercial.dbo.ContratoProductoPaquete
                {
                    ContratoProductoPaqueteId = pContratoProductoPaqueteId,
                    UsuarioBajaId             = pUsuarioId,
                    FechaModificacion         = DateTime.Now,
                    FechaBaja                 = DateTime.Now,
                    Baja                      = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoProductoPaquete();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoProductoPaqueteId"].ToString());
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




        //public static List<Entidades.NovaComercial.dbo.ContratoProductoPaquete> Consultar(SqlOpciones pOpcion, int pContratoProductoPaqueteId, int pContratoProductoId, int pPaqueteId, int pPersonaId, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.ContratoProductoPaquete oE = new Entidades.NovaComercial.dbo.ContratoProductoPaquete();

        //    oE.ContratoProductoPaqueteId = pContratoProductoPaqueteId;
        //    oE.ContratoProductoId        = pContratoProductoId;
        //    oE.PaqueteId                 = pPaqueteId;
        //    oE.Filtro_PersonaId          = pPersonaId;

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

        //    List<Entidades.NovaComercial.dbo.ContratoProductoPaquete> res = new List<Entidades.NovaComercial.dbo.ContratoProductoPaquete>();
        //    Entidades.NovaComercial.dbo.ContratoProductoPaquete item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.ContratoProductoPaquete();

        //            item.ContratoProductoPaqueteId           = int.Parse(dr["ContratoProductoPaqueteId"].ToString());
        //            item.ContratoProductoId                  = int.Parse(dr["ContratoProductoId"].ToString());
        //            item.PaqueteId                           = int.Parse(dr["PaqueteId"].ToString());

        //            if (dr.Table.Columns.Contains("PaqueteDescripcion"))
        //                item.CampoComplemento_PaqueteDescripcion = dr["PaqueteDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("PrecioVentaPublico"))
        //                item.CampoComplemento_PrecioVentaPublico = decimal.Parse(dr["PrecioVentaPublico"].ToString());

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}

        //public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoProductoPaquete obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoProductoPaquete oE = new Entidades.NovaComercial.dbo.ContratoProductoPaquete();
        //    DataSet ds = new DataSet();

        //    oE.ContratoProductoPaqueteId = obj.ContratoProductoPaqueteId;
        //    oE.ContratoProductoId        = obj.ContratoProductoId;
        //    oE.PaqueteId                 = obj.PaqueteId;
        //    oE.UsuarioCreacionId         = obj.UsuarioCreacionId;
        //    oE.UsuarioModificacionId     = obj.UsuarioModificacionId;
        //    oE.Baja                      = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

        //    if (oE.ContratoProductoPaqueteId == 0)
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

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoProductoPaqueteId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(int pContratoProductoPaqueteId, int pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoProductoPaquete oE = new Entidades.NovaComercial.dbo.ContratoProductoPaquete();
        //    DataSet ds = new DataSet();

        //    oE.ContratoProductoPaqueteId = pContratoProductoPaqueteId;
        //    oE.UsuarioBajaId             = pUsuarioId;
        //    oE.Baja                      = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoProductoPaqueteId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}