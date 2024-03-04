using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class EmpresaContacto
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoCtrlUserEmpresaContactoView> ConsultarDetallePorEmpresa(Int32 pEmpresaId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoCtrlUserEmpresaContactoView> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoCtrlUserEmpresaContactoView>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaContactoPM   oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaContactoPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    EmpresaId = pEmpresaId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaContacto oBD = new AccesoDatos.NovaComercial.SACC.EmpresaContacto();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaContacto.DtoCtrlUserEmpresaContactoView item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaContacto.DtoCtrlUserEmpresaContactoView>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaContacto.DtoCtrlUserEmpresaContactoView
                            {
                                EmpresaContactoId       = Int32.Parse(dr["EmpresaContactoId"].ToString()),
                                NombreCompleto          = dr["NombreCompleto"].ToString(),
                                Telefono                = Int64.Parse(dr["Telefono"].ToString()),
                                Extension               = Int16.Parse(dr["Extension"].ToString()),
                                DepartamentoDescripcion = dr["DepartamentoDescripcion"].ToString(),
                                ContactoTipoDescripcion = dr["ContactoTipoDescripcion"].ToString(),
                                CorreoElectronico       = dr["CorreoElectronico"].ToString(),
                                EstatusId               = Int16.Parse(dr["EstatusId"].ToString())

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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto> ConsultarPorId(Int32 pEmpresaContactoId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaContactoPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaContactoPM
                {
                    Opcion            = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaContactoId = pEmpresaContactoId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaContacto oBD = new AccesoDatos.NovaComercial.SACC.EmpresaContacto();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaContacto.DtoEmpresaContacto
                            {
                                EmpresaContactoId       = Int32.Parse(dr["EmpresaContactoId"].ToString()),
                                EmpresaId               = Int32.Parse(dr["EmpresaId"].ToString()),
                                Nombre                  = dr["Nombre"].ToString(),
                                Paterno                 = dr["Paterno"].ToString(),
                                Materno                 = dr["Materno"].ToString(),
                                DepartamentoDescripcion = dr["DepartamentoDescripcion"].ToString(),
                                ContactoTipoId          = Int32.Parse(dr["ContactoTipoId"].ToString()),
                                Telefono                = Int32.Parse(dr["Telefono"].ToString()),
                                Extension               = Int16.Parse(dr["Extension"].ToString()),
                                CorreoElectronico       = dr["CorreoElectronico"].ToString(),
                                EstatusId               = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.EmpresaContacto obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.EmpresaContacto oBD = new AccesoDatos.NovaComercial.SACC.EmpresaContacto();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.EmpresaContactoId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaContactoId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pEmpresaContactoId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.EmpresaContacto oE = new Entidades.NovaComercial.SACC.EmpresaContacto
                {
                    EmpresaContactoId = pEmpresaContactoId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.EmpresaContacto oBD = new AccesoDatos.NovaComercial.SACC.EmpresaContacto();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaContactoId"].ToString());
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