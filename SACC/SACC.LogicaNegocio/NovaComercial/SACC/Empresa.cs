using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class Empresa
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoGridEmpresa> ConsultarGrid(String pEmpresaDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoGridEmpresa> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoGridEmpresa>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaPM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneral,
                    EmpresaDescripcion = pEmpresaDescripcion,
                    EstatusId          = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Empresa oBD = new AccesoDatos.NovaComercial.SACC.Empresa();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Empresa.DtoGridEmpresa item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Empresa.DtoGridEmpresa>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Empresa.DtoGridEmpresa
                            {
                                EmpresaId          = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaDescripcion = dr["EmpresaDescripcion"].ToString(),
                                EstatusId          = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoEmpresa> ConsultarPorId(Int32 pEmpresaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoEmpresa> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoEmpresa>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaId = pEmpresaId
                };

                AccesoDatos.NovaComercial.SACC.Empresa oBD = new AccesoDatos.NovaComercial.SACC.Empresa();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Empresa.DtoEmpresa item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Empresa.DtoEmpresa>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Empresa.DtoEmpresa
                            {
                                EmpresaId          = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaDescripcion = dr["EmpresaDescripcion"].ToString(),
                                Codigo             = dr["Codigo"].ToString(),
                                EmpresaTipoId      = Int32.Parse(dr["EmpresaTipoId"].ToString()),
                                MetodoPagoId       = Int32.Parse(dr["MetodoPagoId"].ToString()),
                                FormaPagoId        = Int32.Parse(dr["FormaPagoId"].ToString()),
                                FrecuenciaPagoId   = Int32.Parse(dr["FrecuenciaPagoId"].ToString()),
                                DiaPago            = Int32.Parse(dr["DiaPago"].ToString()),
                                InicioOperaciones  =  DateTime.Parse(dr["InicioOperaciones"].ToString()),
                                EmpresaVigenciaId  = Int32.Parse(dr["EmpresaVigenciaId"].ToString()),
                                EstatusId          = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoComboEmpresa> ConsultarCombo(String pEmpresaDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoComboEmpresa> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoComboEmpresa>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaPM
                {
                    Opcion             = (Int16)SqlOpciones.Lista,
                    EmpresaDescripcion = pEmpresaDescripcion
                };

                AccesoDatos.NovaComercial.SACC.Empresa oBD = new AccesoDatos.NovaComercial.SACC.Empresa();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Empresa.DtoComboEmpresa item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Empresa.DtoComboEmpresa>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Empresa.DtoComboEmpresa
                            {
                                EmpresaId          = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaDescripcion = dr["EmpresaDescripcion"].ToString()
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoCtrlUserBusquedaEmpresaGrid> CtrlUserBuscarEmpresaJson(String pEmpresaDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoCtrlUserBusquedaEmpresaGrid> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Empresa.DtoCtrlUserBusquedaEmpresaGrid>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaPM()
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneral,
                    EmpresaDescripcion = pEmpresaDescripcion
                };

                AccesoDatos.NovaComercial.SACC.Empresa oBD = new AccesoDatos.NovaComercial.SACC.Empresa();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Empresa.DtoCtrlUserBusquedaEmpresaGrid item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Empresa.DtoCtrlUserBusquedaEmpresaGrid>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Empresa.DtoCtrlUserBusquedaEmpresaGrid
                            {
                                EmpresaId          = Int32.Parse(dr["EmpresaId"].ToString()),
                                EmpresaDescripcion = dr["EmpresaDescripcion"].ToString(),
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Empresa obj, Entidades.NovaComercial.SACC.EmpresaDatosFiscales objDF)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Empresa oBD = new AccesoDatos.NovaComercial.SACC.Empresa();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales oBD_DF = new AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales();
                Modelo.ModeloResponse responseDatosFiscales = new Modelo.ModeloResponse();

                if (obj.EmpresaId == 0)
                {
                    response = oBD.Insertar((short)SqlOpciones.Insertar, obj);

                    if (!response.Error)
                    {
                        var _EmpresaId = int.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaId"].ToString());

                        if (_EmpresaId > 0)
                        {
                            objDF.EmpresaId       = _EmpresaId;
                            responseDatosFiscales = oBD_DF.Insertar((short)SqlOpciones.Insertar, objDF);
                        }
                    }
                }
                else
                {
                    if (obj.Baja == true)
                    {
                        obj.UsuarioBajaId = obj.UsuarioBajaId;
                    }

                    response = oBD.Actualizar((short)SqlOpciones.Actualizar, obj);

                    if (!response.Error)
                    {
                        var _EmpresaId = int.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaId"].ToString());

                        if (_EmpresaId > 0)
                        {
                            if (objDF.EmpresaDatosFiscalesId == 0)
                            {
                                responseDatosFiscales = oBD_DF.Insertar((short)SqlOpciones.Insertar, objDF);
                            }
                            else
                            {
                                responseDatosFiscales = oBD_DF.Actualizar((short)SqlOpciones.Actualizar, objDF);
                            }
                        }
                    }
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pEmpresaId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();
            
            try
            {
                Entidades.NovaComercial.SACC.Empresa oE = new Entidades.NovaComercial.SACC.Empresa
                {
                    EmpresaId         = pEmpresaId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Empresa oBD = new AccesoDatos.NovaComercial.SACC.Empresa();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaId"].ToString());
                    res.Mensaje = response.Resultado.Tables[0].Rows[0]["Mensaje"].ToString();
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
                res.TituloError  = "(LogicaLegocio) - Error Inesperado - La baja logica no se pudo ejecutar.";
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }
    }
}