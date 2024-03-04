using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public static class ContratoCoberturaPaqueteExclusion
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion> ConsultarGrid(Int32 pPaqueteId, Int32 pContratoCoberturaPaqueteId, String pItemDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM
                {
                    Opcion                     = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    PaqueteId                  = pPaqueteId,
                    ContratoCoberturaPaqueteId = pContratoCoberturaPaqueteId,
                    ItemDescripcion            = pItemDescripcion,
                    EstatusId                  = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion
                            {
                                ContratoCoberturaPaqueteExclusionId = Int32.Parse(dr["ContratoCoberturaPaqueteExclusionId"].ToString()),
                                PaqueteDetalleId                    = Int32.Parse(dr["PaqueteDetalleId"].ToString()),
                                PaqueteId                           = Int32.Parse(dr["PaqueteId"].ToString()),
                                ItemTipoId                          = Int32.Parse(dr["ItemTipoId"].ToString()),
                                ItemTipoDescripcion                 = dr["ItemTipoDescripcion"].ToString(),
                                ItemId                              = Int32.Parse(dr["ItemId"].ToString()),
                                ServicioDescripcion                 = dr["ServicioDescripcion"].ToString(),
                                ServicioTipoDescripcion             = dr["ServicioTipoDescripcion"].ToString(),
                                EstatusExcluido                     = (dr["EstatusExcluido"].ToString() == "0") ? false : true,
                                Excluido                            = (dr["Excluido"].ToString() == "0") ? false : true
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion> ConsultarGrid(String pContratoCoberturaPaqueteExclusionDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaGeneral,
                    //ContratoCoberturaPaqueteExclusionDescripcion = pContratoCoberturaPaqueteExclusionDescripcion,
                    EstatusId = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoGridContratoCoberturaPaqueteExclusion
                            {
                                //ContratoCoberturaPaqueteExclusionId = short.Parse(dr["ContratoCoberturaPaqueteExclusionId"].ToString()),
                                //ContratoCoberturaPaqueteExclusionDescripcion = dr["ContratoCoberturaPaqueteExclusionDescripcion"].ToString(),
                                //EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion> ConsultarPorId(Int32 pContratoCoberturaPaqueteExclusionId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM
                {
                    Opcion                              = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoCoberturaPaqueteExclusionId = pContratoCoberturaPaqueteExclusionId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoContratoCoberturaPaqueteExclusion
                            {
                                ContratoCoberturaPaqueteExclusionId = short.Parse(dr["ContratoCoberturaPaqueteExclusionId"].ToString()),
                                //ContratoCoberturaPaqueteExclusionDescripcion = dr["ContratoCoberturaPaqueteExclusionDescripcion"].ToString(),
                                //EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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
                res.Error = true;
                res.TituloError = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje = "error";
            }

            return res;
        }


        //public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoComboContratoCoberturaPaqueteExclusion> ConsultarCombo(String pContratoCoberturaPaqueteExclusionDescripcion)
        //{
        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoComboContratoCoberturaPaqueteExclusion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoComboContratoCoberturaPaqueteExclusion>();

        //    try
        //    {
        //        Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteExclusionPM
        //        {
        //            Opcion = (Int16)SqlOpciones.Lista,
        //            //ContratoCoberturaPaqueteExclusionDescripcion = pContratoCoberturaPaqueteExclusionDescripcion
        //        };

        //        AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion();
        //        Modelo.ModeloResponse response = oBD.Consultar(oParametros);

        //        if (!response.Error)
        //        {
        //            Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoComboContratoCoberturaPaqueteExclusion item = null;
        //            res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion.DtoComboContratoCoberturaPaqueteExclusion>();

        //            foreach (DataTable table in response.Resultado.Tables)
        //            {
        //                foreach (DataRow dr in table.Rows)
        //                {
        //                    item = new Modelo.NovaComercial.SACC.ContratoCoberturaPaqueteExclusion.DtoComboContratoCoberturaPaqueteExclusion
        //                    {
        //                        ContratoCoberturaPaqueteExclusionId = short.Parse(dr["ContratoCoberturaPaqueteExclusionId"].ToString()),
        //                        ContratoCoberturaPaqueteExclusionDescripcion = dr["ContratoCoberturaPaqueteExclusionDescripcion"].ToString(),
        //                    };

        //                    res.Datos.Add(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            res.Error = true;
        //            res.TituloError = response.TituloError;
        //            res.MensajeError = response.MensajeError;
        //            res.TipoMensaje = "error";
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        res.Error = true;
        //        res.TituloError = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
        //        res.MensajeError = exc.Message.ToString();
        //        res.TipoMensaje = "error";
        //    }

        //    return res;
        //}


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoCoberturaPaqueteExclusionId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaPaqueteExclusionId"].ToString());
                        res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                    }
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = response.TituloError;
                    res.MensajeError = response.MensajeError.ToString();
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pContratoCoberturaPaqueteExclusionId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oE = new Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion
                {
                    ContratoCoberturaPaqueteExclusionId = pContratoCoberturaPaqueteExclusionId,
                    UsuarioBajaId                       = pUsuarioId,
                    FechaModificacion                   = DateTime.Now,
                    FechaBaja                           = DateTime.Now,
                    Baja                                = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteExclusion();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaPaqueteExclusionId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
                }
                else
                {
                    res.Error        = true;
                    res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                    res.MensajeError = response.MensajeError.ToString();
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