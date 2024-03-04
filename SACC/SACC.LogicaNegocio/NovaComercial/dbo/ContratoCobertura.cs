using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public static class ContratoCobertura
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoGridContratoCobertura> ConsultarGrid(Int32 pContratoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoGridContratoCobertura> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoGridContratoCobertura>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ContratoCoberturaId = 0,
                    ContratoId          = pContratoId,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCobertura oBD = new AccesoDatos.NovaComercial.dbo.ContratoCobertura();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCobertura.DtoGridContratoCobertura item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCobertura.DtoGridContratoCobertura>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCobertura.DtoGridContratoCobertura
                            {
                                ContratoCoberturaId            = Int32.Parse(dr["ContratoCoberturaId"].ToString()),
                                ContratoCoberturaDescripcion   = dr["ContratoCoberturaDescripcion"].ToString(),
                                TodoMedicamento                = Boolean.Parse(dr["TodoMedicamento"].ToString()),
                                TodoMaterial                   = Boolean.Parse(dr["TodoMaterial"].ToString()),
                                TodoCirugia                    = Boolean.Parse(dr["TodoCirugia"].ToString()),
                                TodoEstudio                    = Boolean.Parse(dr["TodoEstudio"].ToString()),
                                TodoServicio                   = Boolean.Parse(dr["TodoServicio"].ToString()),
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
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura> ConsultarPorId(Int32 pContratoCoberturaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoCoberturaId = pContratoCoberturaId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCobertura oBD = new AccesoDatos.NovaComercial.dbo.ContratoCobertura();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCobertura.DtoContratoCobertura
                            {
                                ContratoCoberturaId            = Int32.Parse(dr["ContratoCoberturaId"].ToString()),
                                ContratoCoberturaDescripcion   = dr["ContratoCoberturaDescripcion"].ToString(),
                                TodoMedicamento                = Boolean.Parse(dr["TodoMedicamento"].ToString()),
                                TodoMaterial                   = Boolean.Parse(dr["TodoMaterial"].ToString()),
                                TodoCirugia                    = Boolean.Parse(dr["TodoCirugia"].ToString()),
                                TodoEstudio                    = Boolean.Parse(dr["TodoEstudio"].ToString()),
                                TodoServicio                   = Boolean.Parse(dr["TodoServicio"].ToString()),
                                VigenciaDesde                  = DateTime.Parse(dr["VigenciaDesde"].ToString()),
                                VigenciaHasta                  = DateTime.Parse(dr["VigenciaHasta"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura> ConsultarCombo(Int32 pContratoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPM
                {
                    Opcion              = 4,
                    ContratoCoberturaId = 0,
                    ContratoId          = pContratoId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCobertura oBD = new AccesoDatos.NovaComercial.dbo.ContratoCobertura();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCobertura.DtoComboContratoCobertura
                            {
                                ContratoCoberturaId          = Int32.Parse(dr["ContratoCoberturaId"].ToString()),
                                ContratoCoberturaDescripcion = dr["ContratoCoberturaDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoCobertura obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.ContratoCobertura oBD = new AccesoDatos.NovaComercial.dbo.ContratoCobertura();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoCoberturaId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pContratoCoberturaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.ContratoCobertura oE = new Entidades.NovaComercial.dbo.ContratoCobertura
                {
                    ContratoCoberturaId = pContratoCoberturaId,
                    UsuarioBajaId       = pUsuarioId,
                    FechaModificacion   = DateTime.Now,
                    FechaBaja           = DateTime.Now,
                    Baja                = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.ContratoCobertura oBD = new AccesoDatos.NovaComercial.dbo.ContratoCobertura();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaId"].ToString());
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


        //public static List<Entidades.NovaComercial.dbo.ContratoCobertura> Consultar(SqlOpciones pOpcion, int pContratoCoberturaId, int pContratoId, string pContratoCoberturaDescripcion, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.ContratoCobertura oE = new Entidades.NovaComercial.dbo.ContratoCobertura();

        //    oE.ContratoCoberturaId          = pContratoCoberturaId;
        //    oE.ContratoId                   = pContratoId;
        //    oE.ContratoCoberturaDescripcion = pContratoCoberturaDescripcion;

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

        //    List<Entidades.NovaComercial.dbo.ContratoCobertura> res = new List<Entidades.NovaComercial.dbo.ContratoCobertura>();
        //    Entidades.NovaComercial.dbo.ContratoCobertura item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.ContratoCobertura();

        //            item.ContratoCoberturaId            = int.Parse(dr["ContratoCoberturaId"].ToString());
        //            item.ContratoId                     = int.Parse(dr["ContratoId"].ToString());
        //            item.ContratoCoberturaDescripcion   = dr["ContratoCoberturaDescripcion"].ToString();
        //            item.TodoMedicamento                = Boolean.Parse(dr["TodoMedicamento"].ToString());
        //            item.TodoMaterial                   = Boolean.Parse(dr["TodoMaterial"].ToString());
        //            item.TodoCirugia                    = Boolean.Parse(dr["TodoCirugia"].ToString());
        //            item.TodoEstudio                    = Boolean.Parse(dr["TodoEstudio"].ToString());
        //            item.TodoServicio                   = Boolean.Parse(dr["TodoServicio"].ToString());
        //            item.VigenciaDesde                  = DateTime.Parse(dr["VigenciaDesde"].ToString());
        //            item.VigenciaHasta                  = DateTime.Parse(dr["VigenciaHasta"].ToString());
        //            item.EsquemaPrePago                 = Boolean.Parse(dr["CobroAnticipado"].ToString());
        //            item.CobroAnticipado                = Boolean.Parse(dr["CobroAnticipado"].ToString());
        //            item.PorcentajeUtilidadSobreTarifa  = decimal.Parse(dr["PorcentajeUtilidadSobreTarifa"].ToString());
        //            item.PorcentajeCopagoContratante    = decimal.Parse(dr["PorcentajeCopagoContratante"].ToString());
        //            item.PorcentajeDescuentoSobreTarifa = decimal.Parse(dr["PorcentajeDescuentoSobreTarifa"].ToString());

        //            if (dr.Table.Columns.Contains("ContratoDescripcion"))
        //                item.CampoComplemento_ContratoDescripcion = dr["ContratoDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoCobertura obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoCobertura oE = new Entidades.NovaComercial.dbo.ContratoCobertura();
        //    DataSet ds = new DataSet();

        //    oE.ContratoCoberturaId            = obj.ContratoCoberturaId;
        //    oE.ContratoId                     = obj.ContratoId;
        //    oE.ContratoCoberturaDescripcion   = obj.ContratoCoberturaDescripcion;
        //    oE.TodoMedicamento                = obj.TodoMedicamento;
        //    oE.TodoMaterial                   = obj.TodoMaterial;
        //    oE.TodoCirugia                    = obj.TodoCirugia;
        //    oE.TodoEstudio                    = obj.TodoEstudio;
        //    oE.TodoServicio                   = obj.TodoServicio;
        //    oE.ContratoCoberturaTipoId        = obj.ContratoCoberturaTipoId;
        //    oE.VigenciaDesde                  = obj.VigenciaDesde;
        //    oE.VigenciaHasta                  = obj.VigenciaHasta;
        //    oE.EsquemaPrePago                 = obj.EsquemaPrePago;
        //    oE.CobroAnticipado                = obj.CobroAnticipado;
        //    oE.TarifaId                       = obj.TarifaId;
        //    oE.PorcentajeUtilidadSobreTarifa  = decimal.Parse(obj.PorcentajeUtilidadSobreTarifa.ToString());
        //    oE.PorcentajeCopagoContratante    = decimal.Parse(obj.PorcentajeCopagoContratante.ToString());
        //    oE.PorcentajeDescuentoSobreTarifa = decimal.Parse(obj.PorcentajeDescuentoSobreTarifa.ToString());
        //    oE.UsuarioCreacionId              = obj.UsuarioCreacionId;
        //    oE.UsuarioModificacionId          = obj.UsuarioModificacionId;
        //    oE.Baja                           = obj.Baja;

        //    if (oE.ContratoCoberturaId == 0)
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

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoCoberturaId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(int pContratoCoberturaId, int pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoCobertura oE = new Entidades.NovaComercial.dbo.ContratoCobertura();
        //    DataSet ds = new DataSet();

        //    oE.ContratoCoberturaId = pContratoCoberturaId;
        //    oE.TodoMedicamento     = false;
        //    oE.TodoMaterial        = false;
        //    oE.TodoCirugia         = false;
        //    oE.TodoEstudio         = false;
        //    oE.TodoServicio        = false;
        //    oE.EsquemaPrePago      = false;
        //    oE.CobroAnticipado     = false;
        //    oE.UsuarioBajaId       = pUsuarioId;
        //    oE.Baja                = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoCoberturaId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}