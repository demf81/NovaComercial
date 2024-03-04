using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class AreaNegocio
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoGridAreaNegocio> ConsultarGrid(String pAreaNegocioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoGridAreaNegocio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoGridAreaNegocio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.AreaNegocioPM oParametros = new Modelo.Parametro.NovaComercial.SACC.AreaNegocioPM
                {
                    Opcion                 = (Int16)SqlOpciones.ConsultaGeneral,
                    AreaNegocioDescripcion = pAreaNegocioDescripcion,
                    EstatusId              = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.AreaNegocio oBD = new AccesoDatos.NovaComercial.SACC.AreaNegocio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.AreaNegocio.DtoGridAreaNegocio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.AreaNegocio.DtoGridAreaNegocio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.AreaNegocio.DtoGridAreaNegocio
                            {
                                AreaNegocioId          = Int16.Parse(dr["AreaNegocioId"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoAreaNegocio> ConsultarPorId(Int32 pAreaNegocioId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoAreaNegocio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoAreaNegocio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.AreaNegocioPM oParametros = new Modelo.Parametro.NovaComercial.SACC.AreaNegocioPM
                {
                    Opcion        = (Int16)SqlOpciones.ConsultaPorId,
                    AreaNegocioId = pAreaNegocioId
                };

                AccesoDatos.NovaComercial.SACC.AreaNegocio oBD = new AccesoDatos.NovaComercial.SACC.AreaNegocio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.AreaNegocio.DtoAreaNegocio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.AreaNegocio.DtoAreaNegocio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.AreaNegocio.DtoAreaNegocio
                            {
                                AreaNegocioId          = Int16.Parse(dr["AreaNegocioId"].ToString()),
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoComboAreaNegocio> ConsultarCombo(String pAreaNegocioDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoComboAreaNegocio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.AreaNegocio.DtoComboAreaNegocio>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.AreaNegocioPM oParametros = new Modelo.Parametro.NovaComercial.SACC.AreaNegocioPM
                {
                    Opcion                 = (Int16)SqlOpciones.Lista,
                    AreaNegocioDescripcion = pAreaNegocioDescripcion
                };

                AccesoDatos.NovaComercial.SACC.AreaNegocio oBD = new AccesoDatos.NovaComercial.SACC.AreaNegocio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.AreaNegocio.DtoComboAreaNegocio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.AreaNegocio.DtoComboAreaNegocio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.AreaNegocio.DtoComboAreaNegocio
                            {
                                AreaNegocioId          = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                AreaNegocioDescripcion = dr["AreaNegocioDescripcion"].ToString()
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.AreaNegocio obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                AccesoDatos.NovaComercial.SACC.AreaNegocio oBD = new AccesoDatos.NovaComercial.SACC.AreaNegocio();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();
                
                if (obj.AreaNegocioId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["AreaNegocioId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pAreaNegocioId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.AreaNegocio oE = new Entidades.NovaComercial.SACC.AreaNegocio
                {
                    AreaNegocioId     = pAreaNegocioId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.AreaNegocio oBD = new AccesoDatos.NovaComercial.SACC.AreaNegocio();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["AreaNegocioId"].ToString());
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
