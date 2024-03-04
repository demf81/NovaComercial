using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Parentesco
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoGridParentesco> ConsultarGrid(String pParentescoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoGridParentesco> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoGridParentesco>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ParentescoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ParentescoPM
                {
                    Opcion                = (Int16)SqlOpciones.ConsultaGeneral,
                    ParentescoDescripcion = pParentescoDescripcion,
                    EstatusId             = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Parentesco oBD = new AccesoDatos.NovaComercial.SACC.Parentesco();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Parentesco.DtoGridParentesco item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Parentesco.DtoGridParentesco>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Parentesco.DtoGridParentesco
                            {
                                ParentescoId          = short.Parse(dr["ParentescoId"].ToString()),
                                ParentescoDescripcion = dr["ParentescoDescripcion"].ToString(),
                                ClaveFamiliarInicio   = Int16.Parse(dr["ClaveFamiliarInicio"].ToString()),
                                ClaveFamiliarFin      = Int16.Parse(dr["ClaveFamiliarFin"].ToString()),
                                EstatusId             = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoParentesco> ConsultarPorId(Int32 pParentescoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoParentesco> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoParentesco>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ParentescoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ParentescoPM
                {
                    Opcion       = (Int16)SqlOpciones.ConsultaPorId,
                    ParentescoId = pParentescoId
                };

                AccesoDatos.NovaComercial.SACC.Parentesco oBD = new AccesoDatos.NovaComercial.SACC.Parentesco();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Parentesco.DtoParentesco item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Parentesco.DtoParentesco>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Parentesco.DtoParentesco
                            {
                                ParentescoId          = short.Parse(dr["ParentescoId"].ToString()),
                                ParentescoDescripcion = dr["ParentescoDescripcion"].ToString(),
                                ClaveFamiliarInicio   = Int16.Parse(dr["ClaveFamiliarInicio"].ToString()),
                                ClaveFamiliarFin      = Int16.Parse(dr["ClaveFamiliarFin"].ToString()),
                                EstatusId             = Int16.Parse(dr["EstatusId"].ToString()),
                                Baja                  = bool.Parse(dr["Baja"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoComboParentesco> ConsultarCombo(String pParentescoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoComboParentesco> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Parentesco.DtoComboParentesco>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ParentescoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.ParentescoPM
                {
                    Opcion                = (Int16)SqlOpciones.Lista,
                    ParentescoDescripcion = pParentescoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.Parentesco oBD = new AccesoDatos.NovaComercial.SACC.Parentesco();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Parentesco.DtoComboParentesco item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Parentesco.DtoComboParentesco>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Parentesco.DtoComboParentesco
                            {
                                ParentescoId          = short.Parse(dr["ParentescoId"].ToString()),
                                ParentescoDescripcion = dr["ParentescoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Parentesco obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Parentesco oBD = new AccesoDatos.NovaComercial.SACC.Parentesco();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ParentescoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ParentescoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pParentescoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.Parentesco oE = new Entidades.NovaComercial.SACC.Parentesco
                {
                    ParentescoId      = pParentescoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Parentesco oBD = new AccesoDatos.NovaComercial.SACC.Parentesco();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ParentescoId"].ToString());
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