using System;
using System.Collections.Generic;
using System.Data;

namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class EmpresaArchivoTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoGridEmpresaArchivoTipo> ConsultarGrid(String pEmpresaArchivoTipoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoGridEmpresaArchivoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoGridEmpresaArchivoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaArchivoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaArchivoTipoPM
                {
                    Opcion                        = (Int16)SqlOpciones.ConsultaGeneral,
                    EmpresaArchivoTipoDescripcion = pEmpresaArchivoTipoDescripcion,
                    EstatusId                     = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoGridEmpresaArchivoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoGridEmpresaArchivoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoGridEmpresaArchivoTipo
                            {
                                EmpresaArchivoTipoId          = short.Parse(dr["EmpresaArchivoTipoId"].ToString()),
                                EmpresaArchivoTipoDescripcion = dr["EmpresaArchivoTipoDescripcion"].ToString(),
                                EstatusId                     = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoEmpresaArchivoTipo> ConsultarPorId(Int32 pEmpresaArchivoTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoEmpresaArchivoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoEmpresaArchivoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaArchivoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaArchivoTipoPM
                {
                    Opcion               = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaArchivoTipoId = pEmpresaArchivoTipoId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoEmpresaArchivoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoEmpresaArchivoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoEmpresaArchivoTipo
                            {
                                EmpresaArchivoTipoId          = short.Parse(dr["EmpresaArchivoTipoId"].ToString()),
                                EmpresaArchivoTipoDescripcion = dr["EmpresaArchivoTipoDescripcion"].ToString(),
                                EstatusId                     = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoComboEmpresaArchivoTipo> ConsultarCombo(String pEmpresaArchivoTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoComboEmpresaArchivoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoComboEmpresaArchivoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaArchivoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaArchivoTipoPM
                {
                    Opcion                        = (Int16)SqlOpciones.Lista,
                    EmpresaArchivoTipoDescripcion = pEmpresaArchivoTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoComboEmpresaArchivoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoComboEmpresaArchivoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaArchivoTipo.DtoComboEmpresaArchivoTipo
                            {
                                EmpresaArchivoTipoId          = short.Parse(dr["EmpresaArchivoTipoId"].ToString()),
                                EmpresaArchivoTipoDescripcion = dr["EmpresaArchivoTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.EmpresaArchivoTipo obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.EmpresaArchivoTipoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaArchivoTipoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pEmpresaArchivoTipoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.EmpresaArchivoTipo oE = new Entidades.NovaComercial.SACC.EmpresaArchivoTipo
                {
                    EmpresaArchivoTipoId = pEmpresaArchivoTipoId,
                    UsuarioBajaId        = pUsuarioId,
                    FechaModificacion    = DateTime.Now,
                    FechaBaja            = DateTime.Now,
                    Baja                 = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaArchivoTipo();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaArchivoTipoId"].ToString());
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