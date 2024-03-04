using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Servicio
    {
        

        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio> ConsultarGrid(String pServicioDescripcion, Int16 pServicioTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.ServicioPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ServicioPM()
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    ServicioDescripcion = pServicioDescripcion,
                    ServicioTipoId      = pServicioTipoId,
                    //Baja                = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };
                
                AccesoDatos.NovaComercial.dbo.Servicio oBD = new AccesoDatos.NovaComercial.dbo.Servicio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Servicio.DtoGridServicio item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Servicio.DtoGridServicio>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Servicio.DtoGridServicio
                            {
                                ServicioId              = int.Parse(dr["ServicioId"].ToString()),
                                ServicioDescripcion     = dr["ServicioDescripcion"].ToString(),
                                ServicioTipoId          = int.Parse(dr["ServicioTipoId"].ToString()),
                                ServicioTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
                                Costo                   = decimal.Parse(dr["Adquisicion"].ToString()),
                                EstatusId = Int16.Parse(dr["EstatusId"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserServicioMedicoConPrecioGrid(String pServicioDescripcion, Int16 pServicioTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.ServicioPM oParametros = new Modelo.Parametro.NovaComercial.dbo.ServicioPM()
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    ServicioDescripcion = pServicioDescripcion,
                    ServicioTipoId      = pServicioTipoId,
                    //Baja                = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };

                AccesoDatos.NovaComercial.dbo.Servicio oBD = new AccesoDatos.NovaComercial.dbo.Servicio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);

                if (!response.Error)
                {
                    Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio item = null;
                    res.Datos = new List<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio
                            {
                                AreaNegocioId       = Int32.Parse(dr["AreaNegocioId"].ToString()),
                                ServicioId          = Int32.Parse(dr["ServicioId"].ToString()),
                                ItemId              = Int32.Parse(dr["ItemId"].ToString()),
                                ItemDescripcion     = dr["ItemDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ItemTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ItemTipoDescripcion"].ToString(),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = Decimal.Parse(dr["Precio"].ToString()),
                                PrecioConIva        = Decimal.Parse(dr["PrecioConIva"].ToString()),
                                Anticipo            = Decimal.Parse(dr["Anticipo"].ToString()),
                                Iva                 = Decimal.Parse(dr["Iva"].ToString()),
                                TarifaId            = Int32.Parse(dr["TarifaId"].ToString()),
                                CampaniaId          = Int32.Parse(dr["CampaniaId"].ToString())
                            };

                            res.Datos.Add(item);
                        }
                    }
                }
                else
                {
                    res.Error        = true;
                    res.MensajeError = response.MensajeError;
                    res.TipoMensaje  = "error";
                }
            }
            catch (Exception exc)
            {
                res.Error        = true;
                res.MensajeError = exc.Message.ToString();
                res.TipoMensaje  = "error";
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Servicio obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Servicio oE = new Entidades.NovaComercial.dbo.Servicio();
            DataSet ds = new DataSet();

            oE.ServicioId = obj.ServicioId;
            oE.ServicioDescripcion = obj.ServicioDescripcion;
            oE.UsuarioCreacionId = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.ServicioId == 0)
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
            }
            else
            {
                if (obj.Baja == true)
                {
                    oE.UsuarioBajaId = obj.UsuarioBajaId;
                }

                ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;
            }

            res.Id = int.Parse(ds.Tables[0].Rows[0]["ServicioId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(Int32 pServicioId, Int32 pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Servicio oE = new Entidades.NovaComercial.dbo.Servicio();
            DataSet ds = new DataSet();

            oE.ServicioId = pServicioId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id = int.Parse(ds.Tables[0].Rows[0]["ServicioId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }
    }
}