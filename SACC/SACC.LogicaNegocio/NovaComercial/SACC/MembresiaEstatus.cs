using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class MembresiaEstatus
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoGridMembresiaEstatus> ConsultarGrid(String pMembresiaEstatusDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoGridMembresiaEstatus> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoGridMembresiaEstatus>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaEstatusPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaEstatusPM
                {
                    Opcion                      = (Int16)SqlOpciones.ConsultaGeneral,
                    MembresiaEstatusDescripcion = pMembresiaEstatusDescripcion,
                    EstatusId                   = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaEstatus oBD = new AccesoDatos.NovaComercial.SACC.MembresiaEstatus();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaEstatus.DtoGridMembresiaEstatus item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoGridMembresiaEstatus>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaEstatus.DtoGridMembresiaEstatus
                            {
                                MembresiaEstatusId          = Int16.Parse(dr["MembresiaEstatusId"].ToString()),
                                MembresiaEstatusDescripcion = dr["MembresiaEstatusDescripcion"].ToString(),
                                EstatusId                   = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoMembresiaEstatus> ConsultarPorId(Int32 pMembresiaEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoMembresiaEstatus> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoMembresiaEstatus>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaEstatusPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaEstatusPM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaPorId,
                    MembresiaEstatusId = pMembresiaEstatusId
                };

                AccesoDatos.NovaComercial.SACC.MembresiaEstatus oBD = new AccesoDatos.NovaComercial.SACC.MembresiaEstatus();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaEstatus.DtoMembresiaEstatus item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoMembresiaEstatus>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaEstatus.DtoMembresiaEstatus
                            {
                                MembresiaEstatusId          = short.Parse(dr["MembresiaEstatusId"].ToString()),
                                MembresiaEstatusDescripcion = dr["MembresiaEstatusDescripcion"].ToString(),
                                EstatusId                   = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoComboMembresiaEstatus> ConsultarCombo(String pMembresiaEstatusDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoComboMembresiaEstatus> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoComboMembresiaEstatus>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.MembresiaEstatusPM oParametros = new Modelo.Parametro.NovaComercial.SACC.MembresiaEstatusPM
                {
                    Opcion                      = (Int16)SqlOpciones.Lista,
                    MembresiaEstatusDescripcion = pMembresiaEstatusDescripcion
                };

                AccesoDatos.NovaComercial.SACC.MembresiaEstatus oBD = new AccesoDatos.NovaComercial.SACC.MembresiaEstatus();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.MembresiaEstatus.DtoComboMembresiaEstatus item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.MembresiaEstatus.DtoComboMembresiaEstatus>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.MembresiaEstatus.DtoComboMembresiaEstatus
                            {
                                MembresiaEstatusId          = short.Parse(dr["MembresiaEstatusId"].ToString()),
                                MembresiaEstatusDescripcion = dr["MembresiaEstatusDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.MembresiaEstatus obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                AccesoDatos.NovaComercial.SACC.MembresiaEstatus oBD = new AccesoDatos.NovaComercial.SACC.MembresiaEstatus();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();
                
                if (obj.MembresiaEstatusId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaEstatusId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pMembresiaEstatusId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.MembresiaEstatus oE = new Entidades.NovaComercial.SACC.MembresiaEstatus
                {
                    MembresiaEstatusId = pMembresiaEstatusId,
                    UsuarioBajaId      = pUsuarioId,
                    FechaModificacion  = DateTime.Now,
                    FechaBaja          = DateTime.Now,
                    Baja               = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.MembresiaEstatus oBD = new AccesoDatos.NovaComercial.SACC.MembresiaEstatus();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["MembresiaEstatusId"].ToString());
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