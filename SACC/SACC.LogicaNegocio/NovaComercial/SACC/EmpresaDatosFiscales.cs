using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.SACC
{
    public class EmpresaDatosFiscales
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales> ConsultarPorId(Int32 pEmpresaId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales>();

            try
            {
                Modelo.Parametro.NovaComercial.SACC.EmpresaDatosFiscalesPM oParametros = new Modelo.Parametro.NovaComercial.SACC.EmpresaDatosFiscalesPM
                {
                    Opcion    = (Int16)SqlOpciones.ConsultaPorId,
                    EmpresaId = pEmpresaId
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.EmpresaDatosFiscales.DtoEmpresaDatosFiscales
                            {
                                EmpresaDatosFiscalesId = Int32.Parse(dr["EmpresaDatosFiscalesId"].ToString()),
                                EmpresaId              = Int32.Parse(dr["EmpresaId"].ToString()),
                                RazonSocial            = dr["RazonSocial"].ToString(),
                                RFC                    = dr["RFC"].ToString(),
                                PaisId                 = Int32.Parse(dr["PaisId"].ToString()),
                                EstadoId               = Int32.Parse(dr["EstadoId"].ToString()),
                                MunicipioId            = Int32.Parse(dr["MunicipioId"].ToString()),
                                Colonia                = dr["Colonia"].ToString(),
                                Calle                  = dr["Calle"].ToString(),
                                NumeroExterior         = dr["NumeroExterior"].ToString(),
                                NumeroInterior         = dr["NumeroInterior"].ToString(),
                                CodigoPostal           = Int32.Parse(dr["CodigoPostal"].ToString()),
                                CorreoElectronico      = dr["CorreoElectronico"].ToString(),
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

        public static Modelo.ModeloJsonResponse Guardar(Entidades.NovaComercial.SACC.EmpresaDatosFiscales obj)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales();
                Modelo.ModeloResponse response = new Modelo.ModeloResponse();

                if (obj.EmpresaDatosFiscalesId == 0)
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
                        res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaDatosFiscalesId"].ToString());
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


        public static Modelo.ModeloJsonResponse BajaLogica(Int32 pEmpresaDatosFiscalesId, Int32 pUsuarioId)
        {
            Modelo.ModeloJsonResponse res = new Modelo.ModeloJsonResponse();

            try
            {
                Entidades.NovaComercial.SACC.EmpresaDatosFiscales oE = new Entidades.NovaComercial.SACC.EmpresaDatosFiscales
                {
                    EmpresaDatosFiscalesId = pEmpresaDatosFiscalesId,
                    UsuarioBajaId          = pUsuarioId,
                    FechaModificacion      = DateTime.Now,
                    FechaBaja              = DateTime.Now,
                    Baja                   = Convert.ToBoolean(Convert.ToInt16("1"))
                };

                AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales oBD = new AccesoDatos.NovaComercial.SACC.EmpresaDatosFiscales();
                Modelo.ModeloResponse response = oBD.Actualizar((short)SqlOpciones.BajaLogica, oE);

                if (!response.Error)
                {
                    res.Id      = Int32.Parse(response.Resultado.Tables[0].Rows[0]["EmpresaDatosFiscalesId"].ToString());
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