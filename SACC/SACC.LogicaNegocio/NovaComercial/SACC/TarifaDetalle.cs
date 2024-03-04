using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class TarifaDetalle
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.TarifaDetalle.DtoGridTarifaDetalle> ConsultarGrid(Int32 pTarifaId, Int16 pAreaNegocioId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.TarifaDetalle.DtoGridTarifaDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.TarifaDetalle.DtoGridTarifaDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.TarifaDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.TarifaDetallePM
                {
                    Opcion        = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    AreaNegocioId = pAreaNegocioId,
                    EstatusId     = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.TarifaDetalle oBD = new AccesoDatos.NovaComercial.SACC.TarifaDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.TarifaDetalle.DtoGridTarifaDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.TarifaDetalle.DtoGridTarifaDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.TarifaDetalle.DtoGridTarifaDetalle
                            {
                                TarifaDetalleId        = Int32.Parse(dr["TarifaDetalleId"].ToString()),
                                TarifaId               = Int32.Parse(dr["TarifaId"].ToString()),
                                AreaNegocioDescripcion = dr["AreaNegocioDescripcion"].ToString(),
                                ServicioDescripcion    = dr["ServicioDescripcion"].ToString(),
                                Porcentaje             = Decimal.Parse(dr["Porcentaje"].ToString()),
                                Ajuste                 = Decimal.Parse(dr["Ajuste"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.TarifaDetalle.DtoTarifaDetalle> ConsultarPorId(Int32 pTarifaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.TarifaDetalle.DtoTarifaDetalle> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.TarifaDetalle.DtoTarifaDetalle>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.TarifaDetallePM oParametros = new Modelo.Parametro.NovaComercial.SACC.TarifaDetallePM
                {
                    Opcion   = (Int16)SqlOpciones.ConsultaPorId,
                    TarifaId = pTarifaId
                };

                AccesoDatos.NovaComercial.SACC.TarifaDetalle oBD = new AccesoDatos.NovaComercial.SACC.TarifaDetalle();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.TarifaDetalle.DtoTarifaDetalle item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.TarifaDetalle.DtoTarifaDetalle>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.TarifaDetalle.DtoTarifaDetalle
                            {
                                TarifaDetalleId = Int32.Parse(dr["TarifaDetalleId"].ToString()),
                                TarifaId        = Int32.Parse(dr["TarifaId"].ToString()),
                                AreaNegocioId   = Int16.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId      = Int32.Parse(dr["ServicioId"].ToString()),
                                Porcentaje      = Decimal.Parse(dr["Porcentaje"].ToString()),
                                Ajuste          = Decimal.Parse(dr["Ajuste"].ToString()),
                                EstatusId       = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.TarifaDetalle obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.TarifaDetalle oBD = new AccesoDatos.NovaComercial.SACC.TarifaDetalle();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.TarifaId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["TarifaDetalleId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pTarifaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.TarifaDetalle oE = new Entidades.NovaComercial.SACC.TarifaDetalle
                {
                    TarifaId          = pTarifaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.TarifaDetalle oBD = new AccesoDatos.NovaComercial.SACC.TarifaDetalle();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["TarifaDetalleId"].ToString());
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