using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Servicio
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio> ConsultarGrid(String pServicioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ServicioPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ServicioPM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneral,
                    ServicioDescripcion = pServicioDescripcion,
                    EstatusId           = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Servicio oBD = new AccesoDatos.NovaComercial.dbo.Servicio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Servicio.DtoGridServicio item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Servicio.DtoGridServicio
                            {
                                ServicioId          = short.Parse(dr["ServicioId"].ToString()),
                                ServicioDescripcion = dr["ServicioDescripcion"].ToString(),
                                EstatusId           = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoServicio> ConsultarPorId(Int32 pServicioId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ServicioPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ServicioPM
                {
                    Opcion         = (Int16)SqlOpciones.ConsultaPorId,
                    ServicioId = pServicioId
                };

                AccesoDatos.NovaComercial.dbo.Servicio oBD = new AccesoDatos.NovaComercial.dbo.Servicio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Servicio.DtoServicio item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Servicio.DtoServicio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Servicio.DtoServicio
                            {
                                ServicioId          = short.Parse(dr["ServicioId"].ToString()),
                                ServicioDescripcion = dr["ServicioDescripcion"].ToString(),
                                EstatusId           = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoComboServicio> ConsultarCombo(String pServicioDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoComboServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoComboServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ServicioPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioPM
                {
                    Opcion              = (Int16)SqlOpciones.Lista,
                    ServicioDescripcion = pServicioDescripcion,
                    AreaNegocioId       = 1
                };

                AccesoDatos.NovaComercial.SACC.Servicio oBD = new AccesoDatos.NovaComercial.SACC.Servicio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Servicio.DtoComboServicio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Servicio.DtoComboServicio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Servicio.DtoComboServicio
                            {
                                ServicioId          = short.Parse(dr["ServicioId"].ToString()),
                                ServicioDescripcion = dr["ServicioDescripcion"].ToString()
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


        //public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserServicioTarifa> ConsultarCtrlUserServicioTarifa(Int16 pAreaNegocioId)
        //{
        //    Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserServicioTarifa> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserServicioTarifa>();

        //    try
        //    {
        //        Modelo.Parametro.NovaComercial.SACC.ServicioPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ServicioPM()
        //        {
        //            Opcion        = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
        //            AreaNegocioId = pAreaNegocioId,
        //            EstatusId     = 1
        //        };

        //        AccesoDatos.NovaComercial.SACC.Servicio oBD = new AccesoDatos.NovaComercial.SACC.Servicio();
        //        Modelo.ModeloResponse response = oBD.Consultar(oParametros);

        //        if (!response.Error)
        //        {
        //            Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserServicioTarifa item = null;
        //            res.Datos = new List<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserServicioTarifa>();

        //            foreach (DataTable table in response.Resultado.Tables)
        //            {
        //                foreach (DataRow dr in table.Rows)
        //                {
        //                    item = new Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserServicioTarifa
        //                    {
        //                        ServicioId          = int.Parse(dr["ServicioId"].ToString()),
        //                        ServicioDescripcion = dr["ServicioDescripcion"].ToString(),
        //                        Porcentaje          = Decimal.Parse(dr["Porcentaje"].ToString()),
        //                        AplicaAjuste        = Boolean.Parse(dr["AplicaAjuste"].ToString()),
        //                        Ajuste              = Decimal.Parse(dr["Ajuste"].ToString())
        //                    };

        //                    res.Datos.Add(item);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            res.Error        = true;
        //            res.TituloError  = response.TituloError;
        //            res.MensajeError = response.MensajeError;
        //            res.TipoMensaje  = "error";
        //        }
        //    }
        //    catch (Exception exc)
        //    {
        //        res.Error        = true;
        //        res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
        //        res.MensajeError = exc.Message.ToString();
        //        res.TipoMensaje  = "error";
        //    }

        //    return res;
        //}


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Servicio obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Servicio oBD = new AccesoDatos.NovaComercial.SACC.Servicio();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ServicioId == 0)
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
                        res.TituloError  = response.TituloError;
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pServicioId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.Servicio oE = new Entidades.NovaComercial.SACC.Servicio
                {
                    ServicioId        = pServicioId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Servicio oBD = new AccesoDatos.NovaComercial.SACC.Servicio();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ServicioId"].ToString());
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