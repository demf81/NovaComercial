using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class EmpresaDocumentoTipo
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoGridEmpresaDocumentoTipo> ConsultarGrid(String pEmpresaDocumentoTipoDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoGridEmpresaDocumentoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoGridEmpresaDocumentoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoTipoPM
                {
                    Opcion                          = (Int16)SqlOpciones.ConsultaGeneral,
                    EmpresaDocumentoTipoDescripcion = pEmpresaDocumentoTipoDescripcion,
                    EstatusId                       = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoGridEmpresaDocumentoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoGridEmpresaDocumentoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoGridEmpresaDocumentoTipo
                            {
                                EmpresaDocumentoTipoId          = short.Parse(dr["EmpresaDocumentoTipoId"].ToString()),
                                EmpresaDocumentoTipoDescripcion = dr["EmpresaDocumentoTipoDescripcion"].ToString(),
                                EstatusId                       = Int16.Parse(dr["EstatusId"].ToString())
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
                res.TituloError  = "(LogicaNegocio) - Error Inesperado - La consulta no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoEmpresaDocumentoTipo> ConsultarPorId(Int32 pEmpresaDocumentoTipoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoEmpresaDocumentoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoEmpresaDocumentoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoTipoPM
                {
                    Opcion = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaDocumentoTipoId = pEmpresaDocumentoTipoId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoEmpresaDocumentoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoEmpresaDocumentoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoEmpresaDocumentoTipo
                            {
                                EmpresaDocumentoTipoId          = short.Parse(dr["EmpresaDocumentoTipoId"].ToString()),
                                EmpresaDocumentoTipoDescripcion = dr["EmpresaDocumentoTipoDescripcion"].ToString(),
                                EstatusId                       = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo> ConsultarCombo(String pEmpresaDocumentoTipoDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoTipoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDocumentoTipoPM
                {
                    Opcion                          = (Int16)SqlOpciones.Lista,
                    EmpresaDocumentoTipoDescripcion = pEmpresaDocumentoTipoDescripcion
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaDocumentoTipo.DtoComboEmpresaDocumentoTipo
                            {
                                EmpresaDocumentoTipoId = short.Parse(dr["EmpresaDocumentoTipoId"].ToString()),
                                EmpresaDocumentoTipoDescripcion = dr["EmpresaDocumentoTipoDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.EmpresaDocumentoTipo obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.EmpresaDocumentoTipoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaDocumentoTipoId"].ToString());
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
                res.Error = true;
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - El registro no se pudo guardar/actualizar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Modelo.ModeloJsonResponse BajaLogica(Int16 pEmpresaDocumentoTipoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.EmpresaDocumentoTipo oE = new Entidades.NovaComercial.SACC.EmpresaDocumentoTipo
                {
                    EmpresaDocumentoTipoId = pEmpresaDocumentoTipoId,
                    UsuarioBajaId          = pUsuarioId,
                    FechaModificacion      = DateTime.Now,
                    FechaBaja              = DateTime.Now,
                    Baja                   = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDocumentoTipo();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaDocumentoTipoId"].ToString());
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