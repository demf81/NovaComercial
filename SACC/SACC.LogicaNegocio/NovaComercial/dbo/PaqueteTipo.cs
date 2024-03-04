using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class PaqueteTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoGridPaqueteTipo> ConsultarGrid(String pPaqueteTipoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoGridPaqueteTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoGridPaqueteTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaqueteTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaqueteTipoPM
                {
                    Opcion                 = (Int16)SqlOpciones.ConsultaGeneral,
                    PaqueteTipoDescripcion = pPaqueteTipoDescripcion,
                    EstatusId              = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.PaqueteTipo oBD = new AccesoDatos.NovaComercial.dbo.PaqueteTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PaqueteTipo.DtoGridPaqueteTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PaqueteTipo.DtoGridPaqueteTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PaqueteTipo.DtoGridPaqueteTipo
                            {
                                PaqueteTipoId          = short.Parse(dr["PaqueteTipoId"].ToString()),
                                PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoPaqueteTipo> ConsultarPorId(Int32 pPaqueteTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoPaqueteTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoPaqueteTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaqueteTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaqueteTipoPM
                {
                    Opcion        = (Int16)SqlOpciones.ConsultaPorId,
                    PaqueteTipoId = pPaqueteTipoId
                };

                AccesoDatos.NovaComercial.dbo.PaqueteTipo oBD = new AccesoDatos.NovaComercial.dbo.PaqueteTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PaqueteTipo.DtoPaqueteTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PaqueteTipo.DtoPaqueteTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PaqueteTipo.DtoPaqueteTipo
                            {
                                PaqueteTipoId          = short.Parse(dr["PaqueteTipoId"].ToString()),
                                PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoComboPaqueteTipo> ConsultarCombo(String pPaqueteTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoComboPaqueteTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.PaqueteTipo.DtoComboPaqueteTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.PaqueteTipoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.PaqueteTipoPM
                {
                    Opcion                 = (Int16)SqlOpciones.Lista,
                    PaqueteTipoDescripcion = pPaqueteTipoDescripcion
                };

                AccesoDatos.NovaComercial.dbo.PaqueteTipo oBD = new AccesoDatos.NovaComercial.dbo.PaqueteTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.PaqueteTipo.DtoComboPaqueteTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.PaqueteTipo.DtoComboPaqueteTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.PaqueteTipo.DtoComboPaqueteTipo
                            {
                                PaqueteTipoId          = short.Parse(dr["PaqueteTipoId"].ToString()),
                                PaqueteTipoDescripcion = dr["PaqueteTipoDescripcion"].ToString(),
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.dbo.PaqueteTipo obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.dbo.PaqueteTipo oBD = new AccesoDatos.NovaComercial.dbo.PaqueteTipo();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.PaqueteTipoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PaqueteTipoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pPaqueteTipoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.dbo.PaqueteTipo oE = new Entidades.NovaComercial.dbo.PaqueteTipo
                {
                    PaqueteTipoId     = pPaqueteTipoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.dbo.PaqueteTipo oBD = new AccesoDatos.NovaComercial.dbo.PaqueteTipo();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["PaqueteTipoId"].ToString());
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