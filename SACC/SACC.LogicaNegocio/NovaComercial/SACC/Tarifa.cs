using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Tarifa
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoGridTarifa> ConsultarGrid(String pTarifaDescripcion, Int16 pAreaNegocioId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoGridTarifa> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoGridTarifa>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.TarifaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.TarifaPM
                {
                    Opcion            = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    TarifaDescripcion = pTarifaDescripcion,
                    AreaNegocioId     = pAreaNegocioId,
                    EstatusId         = pEstatusId
                };
                
                AccesoDatos.NovaComercial.SACC.Tarifa oBD = new AccesoDatos.NovaComercial.SACC.Tarifa();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Tarifa.DtoGridTarifa item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Tarifa.DtoGridTarifa>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Tarifa.DtoGridTarifa
                            {
                                TarifaId               = Int32.Parse(dr["TarifaId"].ToString()),
                                TarifaDescripcion      = dr["TarifaDescripcion"].ToString(),
                                AreaNegocioDescripcion = dr["AreaNegocioDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoTarifa> ConsultarPorId(Int32 pTarifaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoTarifa> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoTarifa>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.TarifaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.TarifaPM
                {
                    Opcion   = (Int16)SqlOpciones.ConsultaPorId,
                    TarifaId = pTarifaId
                };
                
                AccesoDatos.NovaComercial.SACC.Tarifa oBD = new AccesoDatos.NovaComercial.SACC.Tarifa();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Tarifa.DtoTarifa item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Tarifa.DtoTarifa>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Tarifa.DtoTarifa
                            {
                                TarifaId          = short.Parse(dr["TarifaId"].ToString()),
                                TarifaDescripcion = dr["TarifaDescripcion"].ToString(),
                                AreaNegocioId     = Int16.Parse(dr["AreaNegocioId"].ToString()),
                                EstatusId         = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoComboTarifa> ConsultarCombo(String pTarifaDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoComboTarifa> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Tarifa.DtoComboTarifa>();
            
            try
            {
                Modelo.Parametro.NovaComercial.SACC.TarifaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.TarifaPM
                {
                    Opcion            = (Int16)SqlOpciones.Lista,
                    TarifaDescripcion = pTarifaDescripcion
                };
                
                AccesoDatos.NovaComercial.SACC.Tarifa oBD = new AccesoDatos.NovaComercial.SACC.Tarifa();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Tarifa.DtoComboTarifa item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Tarifa.DtoComboTarifa>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Tarifa.DtoComboTarifa
                            {
                                TarifaId          = short.Parse(dr["TarifaId"].ToString()),
                                TarifaDescripcion = dr["TarifaDescripcion"].ToString()
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Tarifa obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Tarifa oBD = new AccesoDatos.NovaComercial.SACC.Tarifa();
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
                        res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                        res.MensajeError = response.Resultado.Tables[0].Rows[0]["MensajeError"].ToString();
                        res.TipoMensaje  = "warning";
                    }
                    else
                    {
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["TarifaId"].ToString());
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
                Entidades.NovaComercial.SACC.Tarifa oE = new Entidades.NovaComercial.SACC.Tarifa
                {
                    TarifaId          = pTarifaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Tarifa oBD = new AccesoDatos.NovaComercial.SACC.Tarifa();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["TarifaId"].ToString());
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