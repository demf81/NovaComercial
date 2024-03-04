using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class PaqueteDetalle
    {
        //public static List<Entidades.NovaComercial.dbo.PaqueteDetalle> Consultar(SqlOpciones pOpcion, Int32 pPaqueteId, String pServicioDescripcion, Int16 ServicioTipoId, Int16 pBaja)
        //{
        //    Entidades.NovaComercial.dbo.PaqueteDetalle oE = new Entidades.NovaComercial.dbo.PaqueteDetalle();

        //    oE.PaqueteId                  = pPaqueteId;
        //    oE.Filtro_ServicioDescripcion = pServicioDescripcion;
        //    oE.Filtro_ServicioTipoId      = ServicioTipoId;

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

        //    List<Entidades.NovaComercial.dbo.PaqueteDetalle> res = new List<Entidades.NovaComercial.dbo.PaqueteDetalle>();
        //    Entidades.NovaComercial.dbo.PaqueteDetalle item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.PaqueteDetalle();

        //            item.PaqueteDetalleId = int.Parse(dr["PaqueteDetalleId"].ToString());
        //            item.PaqueteId        = int.Parse(dr["PaqueteId"].ToString());
        //            item.ItemTipoId       = int.Parse(dr["ItemTipoId"].ToString());

        //            if (dr.Table.Columns.Contains("PaqueteTipoDescripcion"))
        //                item.CampoComplemento_PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("ServicioDescripcion"))
        //                item.CampoComplemento_ServicioDescripcion = dr["ServicioDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("ServicioTipoDescripcion"))
        //                item.CampoComplemento_ServicioTipoDescripcion = dr["ServicioTipoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("ItemTipoDescripcion"))
        //                item.CampoComplemento_ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("CantidadItem"))
        //                item.CampoComplemento_CantidadItem = dr["CantidadItem"].ToString();

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static List<Entidades.NovaComercial.dbo.PaqueteDetalle> ConsultarDetalleAll(Int32 pPaqueteId)
        //{
        //    List<Entidades.NovaComercial.dbo.PaqueteDetalle> res = new List<Entidades.NovaComercial.dbo.PaqueteDetalle>();

        //    try
        //    {
        //        Modelo.Parametro.NovaComercial.dbo.PaqueteDetallePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaqueteDetallePM
        //        {
        //            Opcion           = 4, //(Int16)SqlOpciones.ConsultaGeneralConJoinTodo,
        //            PaqueteDetalleId = 0,
        //            PaqueteId        = pPaqueteId
        //        };

        //        AccesoDatos.NovaComercial.dbo.PaqueteDetalle oBD = new AccesoDatos.NovaComercial.dbo.PaqueteDetalle();
        //        Modelo.ModeloResponse response = oBD.Consultar(oParametros);

        //        if (!response.Error)
        //        {
        //            Entidades.NovaComercial.dbo.PaqueteDetalle item = null;
        //            res = new List<Entidades.NovaComercial.dbo.PaqueteDetalle>();

        //            foreach (DataTable table in response.Resultado.Tables)
        //            {
        //                foreach (DataRow dr in table.Rows)
        //                {
        //                    item = new Entidades.NovaComercial.dbo.PaqueteDetalle
        //                    {
        //                        PaqueteId = short.Parse(dr["PaqueteTipoId"].ToString()),
        //                        //PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString(),
        //                        //EstatusId = Int16.Parse(dr["EstatusId"].ToString())
        //                    };

        //                    if (dr.Table.Columns.Contains("PaqueteTipoDescripcion"))
        //                        item.CampoComplemento_PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString();

        //                    if (dr.Table.Columns.Contains("ServicioDescripcion"))
        //                        item.CampoComplemento_ServicioDescripcion = dr["ServicioDescripcion"].ToString();

        //                    if (dr.Table.Columns.Contains("ServicioTipoDescripcion"))
        //                        item.CampoComplemento_ServicioTipoDescripcion = dr["ServicioTipoDescripcion"].ToString();

        //                    if (dr.Table.Columns.Contains("ItemTipoDescripcion"))
        //                        item.CampoComplemento_ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString();

        //                    if (dr.Table.Columns.Contains("CantidadItem"))
        //                        item.CampoComplemento_CantidadItem = dr["CantidadItem"].ToString();

        //                    res.Add(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //res.Error        = true;
        //            //res.TituloError  = response.TituloError;
        //            //res.MensajeError = response.MensajeError;
        //            //res.TipoMensaje  = "error";
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        //res.Error        = true;
        //        //res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
        //        //res.MensajeError = exc.Message.ToString();
        //        //res.TipoMensaje  = "error";
        //    }

        //    return res;
        //}


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView> ConsultarDetallePorServicio(SqlOpciones pOpcion, Int32 pPaqueteId, Int32 pItemId, String pItemDescripcion, Int16 pItemTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaqueteDetallePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaqueteDetallePM
                {
                    Opcion           = (Int16)pOpcion,
                    PaqueteDetalleId = 0,
                    PaqueteId        = pPaqueteId,
                    ItemId           = pItemId,
                    ItemDescripcion  = pItemDescripcion,
                    ItemTipoId       = pItemTipoId
                };

                AccesoDatos.NovaComercial.dbo.PaqueteDetalle oBD = new AccesoDatos.NovaComercial.dbo.PaqueteDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleView
                            {
                                PaqueteDetalleId       = Int32.Parse(dr["PaqueteDetalleId"].ToString()),
                                CodigoServiciosMedicos = Int32.Parse(dr["CodigoServiciosMedicos"].ToString()),
                                ItemTipoDescripcion    = dr["ItemTipoDescripcion"].ToString(),
                                ItemDescripcion        = dr["ItemDescripcion"].ToString(),
                                EstudioRelacionado     = dr["EstudioRelacionado"].ToString()

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


            //Entidades.NovaComercial.dbo.PaqueteDetalle oE = new Entidades.NovaComercial.dbo.PaqueteDetalle();

            //oE.PaqueteId = pPaqueteId;
            //oE.Filtro_ServicioDescripcion = pServicioDescripcion;
            //oE.Filtro_ServicioTipoId = ServicioTipoId;

            //switch (pBaja)
            //{
            //    case 0:
            //        oE.Baja = false;
            //        break;
            //    case 1:
            //        oE.Baja = true;
            //        break;
            //    default:
            //        oE.Baja = null;
            //        break;
            //}

            //DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            //List<Entidades.NovaComercial.dbo.PaqueteDetalle> res = new List<Entidades.NovaComercial.dbo.PaqueteDetalle>();
            //Entidades.NovaComercial.dbo.PaqueteDetalle item = null;

            //foreach (DataTable table in ds.Tables)
            //{
            //    foreach (DataRow dr in table.Rows)
            //    {
            //        item = new Entidades.NovaComercial.dbo.PaqueteDetalle();

            //        item.PaqueteDetalleId = int.Parse(dr["PaqueteDetalleId"].ToString());
            //        item.PaqueteId = int.Parse(dr["PaqueteId"].ToString());
            //        item.ItemTipoId = int.Parse(dr["ItemTipoId"].ToString());

            //        if (dr.Table.Columns.Contains("PaqueteTipoDescripcion"))
            //            item.CampoComplemento_PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString();

            //        if (dr.Table.Columns.Contains("ServicioDescripcion"))
            //            item.CampoComplemento_ServicioDescripcion = dr["ServicioDescripcion"].ToString();

            //        if (dr.Table.Columns.Contains("ServicioTipoDescripcion"))
            //            item.CampoComplemento_ServicioTipoDescripcion = dr["ServicioTipoDescripcion"].ToString();

            //        if (dr.Table.Columns.Contains("ItemTipoDescripcion"))
            //            item.CampoComplemento_ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString();

            //        if (dr.Table.Columns.Contains("CantidadItem"))
            //            item.CampoComplemento_CantidadItem = dr["CantidadItem"].ToString();

            //        if (dr.Table.Columns.Contains("Baja"))
            //            item.Baja = bool.Parse(dr["Baja"].ToString());

            //        res.Add(item);
            //    }
            //}

            //return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleAllServicioView> ConsultarDetalleTodosServicio(Int32 pPaqueteId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleAllServicioView> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleAllServicioView>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaqueteDetallePM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaqueteDetallePM
                {
                    Opcion           = (Int16)SqlOpciones.ConsultaTodosItemsPaqueteDetalle,
                    PaqueteDetalleId = 0,
                    PaqueteId        = pPaqueteId,
                    ItemId           = -1,
                    ItemDescripcion  = String.Empty,
                    ItemTipoId       = -1,
                    EstatusId        = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.PaqueteDetalle oBD = new AccesoDatos.NovaComercial.dbo.PaqueteDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleAllServicioView item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleAllServicioView>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PaqueteDetalle.DtoCtrlUserPaqueteDetalleAllServicioView
                            {
                                PaqueteDetalleId    = Int32.Parse(dr["PaqueteDetalleId"].ToString()),
                                Amparado            = true,
                                PaqueteCoberturaId  = 0,
                                ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                ItemDescripcion     = dr["ServicioDescripcion"].ToString(),
                                ItemTipoId          = Int32.Parse(dr["ItemTipoId"].ToString()),

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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.PaqueteDetalle obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.PaqueteDetalle oBD = new AccesoDatos.NovaComercial.dbo.PaqueteDetalle();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PaqueteDetalleId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PaqueteDetalleId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pPaqueteDetalleId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.PaqueteDetalle oE = new Entidades.NovaComercial.dbo.PaqueteDetalle
                {
                    PaqueteDetalleId  = pPaqueteDetalleId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.PaqueteDetalle oBD = new AccesoDatos.NovaComercial.dbo.PaqueteDetalle();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PaqueteDetalleId"].ToString());
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


            

            //Entidades.NovaComercial.dbo.PaqueteDetalle oE = new Entidades.NovaComercial.dbo.PaqueteDetalle();
            //DataSet ds = new DataSet();

            //oE.PaqueteDetalleId = pPaqueteDetalleId;
            //oE.UsuarioBajaId    = pUsuarioId;
            //oE.Baja             = Convert.ToBoolean(Convert.ToInt16("1"));

            //ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            //res.Id           = int.Parse(ds.Tables[0].Rows[0]["PaqueteDetalleId"].ToString());
            //res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            //res.MensajeError = "";
            //res.Error        = false;
            //res.TipoMensaje  = "success";

            //return res;
        }
    }
}