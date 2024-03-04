using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public static class ContratoProducto
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoGridContratoProducto> ConsultarGrid(Int32 pContratoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoGridContratoProducto> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoGridContratoProducto>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoProductoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoProductoPM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ContratoProductoId = 0,
                    ContratoId         = pContratoId,
                    EstatusId          = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoProducto oBD = new AccesoDatos.NovaComercial.dbo.ContratoProducto();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoProducto.DtoGridContratoProducto item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoProducto.DtoGridContratoProducto>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoProducto.DtoGridContratoProducto
                            {
                                ContratoProductoId             = Int32.Parse(dr["ContratoProductoId"].ToString()),
                                ContratoProductoDescripcion    = dr["ContratoProductoDescripcion"].ToString(),
                                //PorcentajeCopagoContratante    = Decimal.Parse(dr["PorcentajeCopagoContratante"].ToString()),
                                //PorcentajeDescuentoSobreTarifa = Decimal.Parse(dr["PorcentajeDescuentoSobreTarifa"].ToString()),
                                EstatusId                      = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto> ConsultarPorId(Int32 pContratoProductoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoProductoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoProductoPM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoProductoId = pContratoProductoId
                };

                AccesoDatos.NovaComercial.dbo.ContratoProducto oBD = new AccesoDatos.NovaComercial.dbo.ContratoProducto();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoProducto.DtoContratoProducto
                            {
                                ContratoProductoId             = Int32.Parse(dr["ContratoProductoId"].ToString()),
                                ContratoProductoDescripcion    = dr["ContratoProductoDescripcion"].ToString(),
                                EsquemaPrePago                 = Boolean.Parse(dr["EsquemaPrePago"].ToString()),
                                CobroAnticipado                = Boolean.Parse(dr["CobroAnticipado"].ToString()),
                                PorcentajeUtilidadSobreTarifa  = Decimal.Parse(dr["PorcentajeUtilidadSobreTarifa"].ToString()),
                                PorcentajeCopagoContratante    = Decimal.Parse(dr["PorcentajeCopagoContratante"].ToString()),
                                PorcentajeDescuentoSobreTarifa = Decimal.Parse(dr["PorcentajeDescuentoSobreTarifa"].ToString()),
                                EstatusId                      = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto> ConsultarCombo(Int32 pContratoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoProductoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoProductoPM
                {
                    Opcion             = 4,
                    ContratoProductoId = 0,
                    ContratoId         = pContratoId
                };

                AccesoDatos.NovaComercial.dbo.ContratoProducto oBD = new AccesoDatos.NovaComercial.dbo.ContratoProducto();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoProducto.DtoComboContratoProducto
                            {
                                ContratoProductoId = Int32.Parse(dr["ContratoProductoId"].ToString()),
                                ContratoProductoDescripcion = dr["ContratoProductoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoProducto obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.ContratoProducto oBD = new AccesoDatos.NovaComercial.dbo.ContratoProducto();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoProductoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoProductoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pContratoProductoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.ContratoProducto oE = new Entidades.NovaComercial.dbo.ContratoProducto
                {
                    ContratoProductoId = pContratoProductoId,
                    UsuarioBajaId      = pUsuarioId,
                    FechaModificacion  = DateTime.Now,
                    FechaBaja          = DateTime.Now,
                    Baja               = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.ContratoProducto oBD = new AccesoDatos.NovaComercial.dbo.ContratoProducto();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoProductoId"].ToString());
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

        //public static List<Entidades.NovaComercial.dbo.ContratoProducto> Consultar(SqlOpciones pOpcion, int pContratoProductoId, int pContratoId, string pContratoProductoDescripcion, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.ContratoProducto oE = new Entidades.NovaComercial.dbo.ContratoProducto();

        //    oE.ContratoProductoId          = pContratoProductoId;
        //    oE.ContratoId                  = pContratoId;
        //    oE.ContratoProductoDescripcion = pContratoProductoDescripcion;

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

        //    List<Entidades.NovaComercial.dbo.ContratoProducto> res = new List<Entidades.NovaComercial.dbo.ContratoProducto>();
        //    Entidades.NovaComercial.dbo.ContratoProducto item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.ContratoProducto();

        //            item.ContratoProductoId             = int.Parse(dr["ContratoProductoId"].ToString());

        //            if (dr.Table.Columns.Contains("ContratoId"))
        //                item.ContratoId                     = int.Parse(dr["ContratoId"].ToString());

        //            if (dr.Table.Columns.Contains("ContratoProductoDescripcion"))
        //                item.ContratoProductoDescripcion    = dr["ContratoProductoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("EsquemaPrePago"))
        //                item.EsquemaPrePago                 = Boolean.Parse(dr["EsquemaPrePago"].ToString());

        //            if (dr.Table.Columns.Contains("CobroAnticipado"))
        //                item.CobroAnticipado                = Boolean.Parse(dr["CobroAnticipado"].ToString());

        //            if (dr.Table.Columns.Contains("PorcentajeUtilidadSobreTarifa"))
        //                item.PorcentajeUtilidadSobreTarifa  = decimal.Parse(dr["PorcentajeUtilidadSobreTarifa"].ToString());

        //            if (dr.Table.Columns.Contains("PorcentajeCopagoContratante"))
        //                item.PorcentajeCopagoContratante    = decimal.Parse(dr["PorcentajeCopagoContratante"].ToString());

        //            if (dr.Table.Columns.Contains("PorcentajeDescuentoSobreTarifa"))
        //                item.PorcentajeDescuentoSobreTarifa = decimal.Parse(dr["PorcentajeDescuentoSobreTarifa"].ToString());

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoProducto obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoProducto oE = new Entidades.NovaComercial.dbo.ContratoProducto();
        //    DataSet ds = new DataSet();

        //    oE.ContratoProductoId             = obj.ContratoProductoId;
        //    oE.ContratoId                     = obj.ContratoId;
        //    oE.ContratoProductoDescripcion    = obj.ContratoProductoDescripcion;
        //    oE.EsquemaPrePago                 = obj.EsquemaPrePago;
        //    oE.CobroAnticipado                = obj.CobroAnticipado;
        //    oE.TarifaId                       = obj.TarifaId;
        //    oE.PorcentajeUtilidadSobreTarifa  = obj.PorcentajeUtilidadSobreTarifa;
        //    oE.PorcentajeCopagoContratante    = obj.PorcentajeCopagoContratante;
        //    oE.PorcentajeDescuentoSobreTarifa = obj.PorcentajeDescuentoSobreTarifa;
        //    oE.UsuarioCreacionId              = obj.UsuarioCreacionId;
        //    oE.UsuarioModificacionId          = obj.UsuarioModificacionId;
        //    oE.Baja = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

        //    if (oE.ContratoProductoId == 0)
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

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoProductoId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(int pContratoProductoId, int pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoProducto oE = new Entidades.NovaComercial.dbo.ContratoProducto();
        //    DataSet ds = new DataSet();

        //    oE.ContratoProductoId = pContratoProductoId;
        //    oE.EsquemaPrePago     = false;
        //    oE.CobroAnticipado    = false;
        //    oE.UsuarioBajaId      = pUsuarioId;
        //    oE.Baja               = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoProductoId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}