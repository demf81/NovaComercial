using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public static class Cliente
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoGridCliente> ConsultarGrid(String pClienteDescripcion, Int16 pClienteTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoGridCliente> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoGridCliente>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ClientePM oParametros = new Modelo.Parametro.NovaComercial.SACC.ClientePM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ClienteDescripcion = pClienteDescripcion,
                    ClienteTipoId      = pClienteTipoId,
                    EstatusId          = pEstatusId
                };

                AccesoDatos.NovaComercial.SACC.Cliente oBD = new AccesoDatos.NovaComercial.SACC.Cliente();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Cliente.DtoGridCliente item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Cliente.DtoGridCliente>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Cliente.DtoGridCliente
                            {
                                ClienteId               = Int32.Parse(dr["ClienteId"].ToString()),
                                ClienteDescripcion      = dr["ClienteDescripcion"].ToString(),
                                Codigo                  = dr["Codigo"].ToString(),
                                ClienteTipoDescripcion  = dr["ClienteTipoDescripcion"].ToString(),
                                //InicioOperaciones       = dr["InicioOperaciones"].ToString(),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoCliente> ConsultarPorId(Int32 pClienteId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoCliente> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoCliente>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ClientePM oParametros = new Modelo.Parametro.NovaComercial.SACC.ClientePM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaPorId,
                    ClienteId = pClienteId
                };

                AccesoDatos.NovaComercial.SACC.Cliente oBD = new AccesoDatos.NovaComercial.SACC.Cliente();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Cliente.DtoCliente item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Cliente.DtoCliente>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Cliente.DtoCliente
                            {
                                ClienteId          = Int32.Parse(dr["ClienteId"].ToString()),
                                ClienteDescripcion = dr["ClienteDescripcion"].ToString(),
                                Codigo             = dr["Codigo"].ToString(),
                                ClienteTipoId      = Int16.Parse(dr["ClienteTipoId"].ToString()),
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoComboCliente> ConsultarCombo(String pClienteDescripcion)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoComboCliente> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Cliente.DtoComboCliente>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.ClientePM oParametros = new Modelo.Parametro.NovaComercial.SACC.ClientePM
                {
                    Opcion             = (Int16)SqlOpciones.Lista,
                    ClienteDescripcion = pClienteDescripcion
                };

                AccesoDatos.NovaComercial.SACC.Cliente oBD = new AccesoDatos.NovaComercial.SACC.Cliente();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Cliente.DtoComboCliente item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Cliente.DtoComboCliente>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Cliente.DtoComboCliente
                            {
                                ClienteId          = Int32.Parse(dr["ClienteId"].ToString()),
                                ClienteDescripcion = dr["ClienteDescripcion"].ToString()
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


        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.Cliente obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.Cliente oBD = new AccesoDatos.NovaComercial.SACC.Cliente();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.ClienteId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ClienteId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pClienteId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.Cliente oE = new Entidades.NovaComercial.SACC.Cliente
                {
                    ClienteId         = pClienteId,
                    UsuarioBajaId     = pUsuarioId,
                    FechaModificacion = DateTime.Now,
                    FechaBaja         = DateTime.Now,
                    Baja              = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.Cliente oBD = new AccesoDatos.NovaComercial.SACC.Cliente();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["ClienteId"].ToString());
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