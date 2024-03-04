using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public static class ContratoCoberturaPaquete
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaquete> ConsultarGrid(Int32 pContratoCoberturaId, Int32 pPaqueteId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ContratoCoberturaId = pContratoCoberturaId,
                    PaqueteId           = pPaqueteId,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaquete
                            {
                                ContratoCoberturaPaqueteId = Int32.Parse(dr["ContratoCoberturaPaqueteId"].ToString()),
                                PaqueteId                  = Int32.Parse(dr["PaqueteId"].ToString()),
                                PaqueteDescripcion         = dr["PaqueteDescripcion"].ToString(),
                                TieneCondicion             = (dr["TieneCondicion"].ToString() == "1")? true : false,
                                TieneExclusion             = (dr["TieneExclusion"].ToString() == "1")? true : false,
                                EstatusId                  = Int16.Parse(dr["EstatusId"].ToString())
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

        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaqueteContrato> ConsultarGridPorContrato(Int32 pContratoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaqueteContrato> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaqueteContrato>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM
                {
                    Opcion              = 7, //(Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ContratoCoberturaId = 0,
                    ContratoId          = pContratoId,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaqueteContrato item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaqueteContrato>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoGridContratoCoberturaPaqueteContrato
                            {
                                PaqueteDescripcion = dr["PaqueteDescripcion"].ToString(),
                                CoberturaCondicion = dr["CoberturaCondicion"].ToString()
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

        

        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete> ConsultarPorId(Int32 pContratoCoberturaPaqueteId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM
                {
                    Opcion                     = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoCoberturaPaqueteId = pContratoCoberturaPaqueteId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoContratoCoberturaPaquete
                            {
                                ContratoCoberturaPaqueteId = Int32.Parse(dr["ContratoCoberturaPaqueteId"].ToString()),
                                //ContratoCoberturaPaqueteDescripcion = dr["ContratoCoberturaPaqueteDescripcion"].ToString(),
                                EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoComboContratoCoberturaPaquete> ConsultarCombo(String pContratoCoberturaPaqueteDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoComboContratoCoberturaPaquete> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoComboContratoCoberturaPaquete>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaquetePM
                {
                    Opcion = (Int16)SqlOpciones.Lista,
                    //ContratoCoberturaPaqueteDescripcion = pContratoCoberturaPaqueteDescripcion
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoComboContratoCoberturaPaquete item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoComboContratoCoberturaPaquete>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaquete.DtoComboContratoCoberturaPaquete
                            {
                                //ContratoCoberturaPaqueteId = short.Parse(dr["ContratoCoberturaPaqueteId"].ToString()),
                                //ContratoCoberturaPaqueteDescripcion = dr["ContratoCoberturaPaqueteDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoCoberturaPaquete obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoCoberturaPaqueteId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaPaqueteId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pContratoCoberturaPaqueteId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.ContratoCoberturaPaquete oE = new Entidades.NovaComercial.dbo.ContratoCoberturaPaquete
                {
                    ContratoCoberturaPaqueteId = pContratoCoberturaPaqueteId,
                    UsuarioBajaId              = pUsuarioId,
                    FechaModificacion          = DateTime.Now,
                    FechaBaja                  = DateTime.Now,
                    Baja                       = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaquete();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaPaqueteId"].ToString());
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



        //public static List<Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> Consultar(SqlOpciones pOpcion, int pContratoCoberturaPaqueteId, int pContratoCoberturaId, int pPaqueteId, int? pMedicamentoId, int? pMaterialId, int? pCirugiaId, int? pEstudioId, int? pServicioId, int pBaja)
        //{
        //    Entidades.NovaComercial.dbo.ContratoCoberturaPaquete oE = new Entidades.NovaComercial.dbo.ContratoCoberturaPaquete();

        //    oE.ContratoCoberturaPaqueteId = pContratoCoberturaPaqueteId;
        //    oE.ContratoCoberturaId        = pContratoCoberturaId;
        //    oE.PaqueteId                  = pPaqueteId;

        //    if (pMedicamentoId.HasValue)
        //        oE.Filtro_MedicamentoId = pMedicamentoId.Value;
        //    else
        //        oE.Filtro_MedicamentoId = null;

        //    if (pMaterialId.HasValue)
        //        oE.Filtro_MaterialId = pMaterialId.Value;
        //    else
        //       oE.Filtro_MaterialId = null;

        //    if (pCirugiaId.HasValue)
        //        oE.Filtro_CirugiaId = pCirugiaId.Value;
        //    else
        //        oE.Filtro_CirugiaId = null;

        //    if (pEstudioId.HasValue)
        //        oE.Filtro_EstudioId = pEstudioId.Value;
        //    else
        //        oE.Filtro_EstudioId = null;

        //    if (pServicioId.HasValue)
        //        oE.Filtro_ServicioId = pServicioId.Value;
        //    else
        //        oE.Filtro_ServicioId = null;

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

        //    List<Entidades.NovaComercial.dbo.ContratoCoberturaPaquete> res = new List<Entidades.NovaComercial.dbo.ContratoCoberturaPaquete>();
        //    Entidades.NovaComercial.dbo.ContratoCoberturaPaquete item = null;

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        foreach (DataRow dr in table.Rows)
        //        {
        //            item = new Entidades.NovaComercial.dbo.ContratoCoberturaPaquete();

        //            if (dr.Table.Columns.Contains("ContratoCoberturaPaqueteId"))
        //            item.ContratoCoberturaPaqueteId = int.Parse(dr["ContratoCoberturaPaqueteId"].ToString());

        //            if (dr.Table.Columns.Contains("ContratoCoberturaId"))
        //            item.ContratoCoberturaId        = int.Parse(dr["ContratoCoberturaId"].ToString());

        //            if (dr.Table.Columns.Contains("PaqueteId"))
        //            item.PaqueteId                  = int.Parse(dr["PaqueteId"].ToString());

        //            if (dr.Table.Columns.Contains("PaqueteDescripcion"))
        //                //item.CampoComplemento_PaqueteDescripcion = dr["PaqueteDescripcion"].ToString();

        //            if (dr.Table.Columns.Contains("Baja"))
        //                item.Baja = bool.Parse(dr["Baja"].ToString());

        //            res.Add(item);
        //        }
        //    }

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoCoberturaPaquete obj)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoCoberturaPaquete oE = new Entidades.NovaComercial.dbo.ContratoCoberturaPaquete();
        //    DataSet ds = new DataSet();

        //    oE.ContratoCoberturaPaqueteId = obj.ContratoCoberturaPaqueteId;
        //    oE.ContratoCoberturaId        = obj.ContratoCoberturaId;
        //    oE.PaqueteId                  = obj.PaqueteId;
        //    oE.UsuarioCreacionId          = obj.UsuarioCreacionId;
        //    oE.UsuarioModificacionId      = obj.UsuarioModificacionId;
        //    oE.Baja                       = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

        //    if (oE.ContratoCoberturaPaqueteId == 0)
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

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoCoberturaPaqueteId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}


        //public static Entidades.EntidadJsonResponse BajaLogica(int pContratoCoberturaPaqueteId, int pUsuarioId)
        //{
        //    Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

        //    Entidades.NovaComercial.dbo.ContratoCoberturaPaquete oE = new Entidades.NovaComercial.dbo.ContratoCoberturaPaquete();
        //    DataSet ds = new DataSet();

        //    oE.ContratoCoberturaPaqueteId = pContratoCoberturaPaqueteId;
        //    oE.UsuarioBajaId              = pUsuarioId;
        //    oE.Baja                       = Convert.ToBoolean(Convert.ToInt16("1"));

        //    ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

        //    res.Id           = int.Parse(ds.Tables[0].Rows[0]["ContratoCoberturaPaqueteId"].ToString());
        //    res.Mensaje      = "El registro se actualizo satisfactoriamente.";
        //    res.MensajeError = "";
        //    res.Error        = false;
        //    res.TipoMensaje  = "success";

        //    return res;
        //}
    }
}