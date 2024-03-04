using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Contrato
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoGridContrato> ConsultarGrid(String pContratoDescripcion, Int16 pContratoTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoGridContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoGridContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoPM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ContratoDescripcion = pContratoDescripcion,
                    ContratoTipoId      = pContratoTipoId,
                    ContratoEstatusId   = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Contrato oBD = new AccesoDatos.NovaComercial.dbo.Contrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Contrato.DtoGridContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Contrato.DtoGridContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Contrato.DtoGridContrato
                            {
                                ContratoId               = Int32.Parse(dr["ContratoId"].ToString()),
                                ContratoDescripcion      = dr["ContratoDescripcion"].ToString(),
                                ContratoTipoDescripcion  = dr["ContratoTipoDescripcion"].ToString(),
                                EmpresaPlantaDescripcion = dr["EmpresaPlantaDescripcion"].ToString(),
                                ContratoEstatusId        = Int16.Parse(dr["ContratoEstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoGridCtrlUserBusquedaContrato> ConsultarGridCtrlUserBusqueda(String pContratoDescripcion, Int16 pContratoTipoId, Int16 pContratoEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoGridCtrlUserBusquedaContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoGridCtrlUserBusquedaContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoPM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ContratoDescripcion = pContratoDescripcion,
                    ContratoTipoId      = pContratoTipoId,
                    ContratoEstatusId   = pContratoEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Contrato oBD = new AccesoDatos.NovaComercial.dbo.Contrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Contrato.DtoGridCtrlUserBusquedaContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Contrato.DtoGridCtrlUserBusquedaContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Contrato.DtoGridCtrlUserBusquedaContrato
                            {
                                ContratoId              = Int32.Parse(dr["ContratoId"].ToString()),
                                ContratoDescripcion     = dr["ContratoDescripcion"].ToString(),
                                ContratoTipoDescripcion = dr["ContratoTipoDescripcion"].ToString(),
                                ContratoEstatusId       = Int16.Parse(dr["ContratoEstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoContrato> ConsultarPorId(Int32 pContratoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoPM
                {
                    Opcion     = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoId = pContratoId
                };

                AccesoDatos.NovaComercial.dbo.Contrato oBD = new AccesoDatos.NovaComercial.dbo.Contrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Contrato.DtoContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Contrato.DtoContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Contrato.DtoContrato
                            {
                                ContratoId          = Int32.Parse(dr["ContratoId"].ToString()),
                                ContratoDescripcion = dr["ContratoDescripcion"].ToString(),
                                ContratoTipoId      = Int16.Parse(dr["ContratoTipoId"].ToString()),
                                ContratanteId       = Int32.Parse(dr["ContratanteId"].ToString()),
                                ContratoEstatusId   = Int16.Parse(dr["ContratoEstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoComboContrato> ConsultarCombo(String pContratoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoComboContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Contrato.DtoComboContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoPM
                {
                    Opcion              = (Int16)SqlOpciones.Lista,
                    ContratoDescripcion = pContratoDescripcion
                };

                AccesoDatos.NovaComercial.dbo.Contrato oBD = new AccesoDatos.NovaComercial.dbo.Contrato();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Contrato.DtoComboContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Contrato.DtoComboContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Contrato.DtoComboContrato
                            {
                                ContratoId          = Int32.Parse(dr["ContratoId"].ToString()),
                                ContratoDescripcion = dr["ContratoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.Contrato obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.Contrato oBD = new AccesoDatos.NovaComercial.dbo.Contrato();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pContratoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.Contrato oE = new Entidades.NovaComercial.dbo.Contrato
                {
                    ContratoId        = pContratoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.Contrato oBD = new AccesoDatos.NovaComercial.dbo.Contrato();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoId"].ToString());
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



        //public static List<Entidades.NovaComercial.dbo.Contrato> Consultar(SqlOpciones pOpcion, int pContratoId, string pContratoDescripcion, int pContratanteId, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.Contrato oE = new Entidades.NovaComercial.dbo.Contrato();

        //    oE.ContratoId    = pContratoId;
        //    oE.ContratanteId = pContratanteId;

        //    if (pContratoDescripcion != "")
        //        oE.ContratoDescripcion = pContratoDescripcion;

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

        //    List<Entidades.NovaComercial.dbo.Contrato> res = new List<Entidades.NovaComercial.dbo.Contrato>();
        //    Entidades.NovaComercial.dbo.Contrato item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.Contrato();

        //            item.ContratoId          = int.Parse(dr["ContratoId"].ToString());
        //            item.ContratoDescripcion = dr["ContratoDescripcion"].ToString();
        //            item.ContratoTipoId      = int.Parse(dr["ContratoTipoId"].ToString());

        //            if (dr.Table.Columns.Contains("ContratanteId"))
        //                item.ContratanteId = int.Parse(dr["ContratanteId"].ToString());

        //            if (dr.Table.Columns.Contains("EmpresaPlantaDescripcion"))
        //                item.CampoComplemento_EmpresaPlantaDescripcion = dr["EmpresaPlantaDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("ContratoTipoDescripcion"))
        //                item.CampoComplemento_ContratoTipoDescripcion = dr["ContratoTipoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Contrato obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.Contrato oE = new Entidades.NovaComercial.dbo.Contrato();
        //    DataSet ds = new DataSet();

        //    oE.ContratoId            = obj.ContratoId;
        //    oE.ContratoDescripcion   = obj.ContratoDescripcion;
        //    oE.ContratoTipoId        = obj.ContratoTipoId;
        //    oE.ContratanteId         = obj.ContratanteId;
        //    oE.VigenciaInicio        = obj.VigenciaInicio;
        //    oE.VigenciaTermino       = obj.VigenciaTermino;
        //    oE.UsuarioCreacionId     = obj.UsuarioCreacionId;
        //    oE.FechaCreacion         = DateTime.Now;
        //    oE.UsuarioModificacionId = obj.UsuarioModificacionId;
        //    oE.FechaModificacion     = DateTime.Now;
        //    oE.Baja                  = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

        //    if (oE.ContratoId == 0)
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

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(int pContratoId, int pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.Contrato oE = new Entidades.NovaComercial.dbo.Contrato();
        //    DataSet ds = new DataSet();

        //    oE.ContratoId    = pContratoId;
        //    oE.UsuarioBajaId = pUsuarioId;
        //    oE.Baja          = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}