using System;
using System.Collections.Generic;
using System.Data;



namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public static class ContratoCoberturaPaqueteCondicion
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion> ConsultarPorId(Int32 pContratoCoberturaPaqueteCondicionId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteCondicionPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteCondicionPM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaPorId,
                    ContratoCoberturaPaqueteCondicionId = pContratoCoberturaPaqueteCondicionId
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion
                            {
                                ContratoCoberturaPaqueteCondicionId = Int32.Parse(dr["ContratoCoberturaPaqueteCondicionId"].ToString()),
                                ContratoCoberturaPaqueteId          = Int32.Parse(dr["ContratoCoberturaPaqueteId"].ToString()),
                                CoberturaCondicionTipoId            = Int16.Parse(dr["CoberturaCondicionTipoId"].ToString()),
                                CoberturaPeriodoTipoId              = Int16.Parse(dr["CoberturaPeriodoTipoId"].ToString()),
                                CoberturaCantidadTipoId             = Int16.Parse(dr["CoberturaCantidadTipoId"].ToString()),
                                Cantidad                            = Decimal.Parse(dr["Cantidad"].ToString()),
                                CoberturaCopagoTipoId               = Int16.Parse(dr["CoberturaCopagoTipoId"].ToString()),
                                Copago                              = Decimal.Parse(dr["Copago"].ToString())
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




        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion> ConsultarPorIdConJoin(Int32 pContratoCoberturaPaqueteId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteCondicionPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ContratoCoberturaPaqueteCondicionPM
                {
                    Opcion                     = (Int16)SqlOpciones.ConsultaPorIdConJoin,
                    ContratoCoberturaPaqueteId = pContratoCoberturaPaqueteId,
                    EstatusId                  = 1
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion.DtoContratoCoberturaPaqueteCondicion
                            {
                                ContratoCoberturaPaqueteCondicionId = Int32.Parse(dr["ContratoCoberturaPaqueteCondicionId"].ToString()),
                                ContratoCoberturaPaqueteId          = Int32.Parse(dr["ContratoCoberturaPaqueteId"].ToString()),
                                CoberturaCondicionTipoId            = Int16.Parse(dr["CoberturaCondicionTipoId"].ToString()),
                                CoberturaPeriodoTipoId              = Int16.Parse(dr["CoberturaPeriodoTipoId"].ToString()),
                                CoberturaCantidadTipoId             = Int16.Parse(dr["CoberturaCantidadTipoId"].ToString()),
                                Cantidad                            = Decimal.Parse(dr["Cantidad"].ToString()),
                                CoberturaCopagoTipoId               = Int16.Parse(dr["CoberturaCopagoTipoId"].ToString()),
                                Copago                              = Decimal.Parse(dr["Copago"].ToString())
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





        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ContratoCoberturaPaqueteCondicionId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaPaqueteCondicionId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pContratoCoberturaPaqueteCondicionId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion oE = new Entidades.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion
                {
                    ContratoCoberturaPaqueteCondicionId = pContratoCoberturaPaqueteCondicionId,
                    UsuarioBajaId                       = pUsuarioId,
                    FechaModificacion                   = DateTime.Now,
                    FechaBaja                           = DateTime.Now,
                    Baja                                = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion oBD = new AccesoDatos.NovaComercial.dbo.ContratoCoberturaPaqueteCondicion();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ContratoCoberturaPaqueteCondicionId"].ToString());
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