using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Material
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Material.DtoGridMaterial> ConsultarGrid(String pMaterialDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Material.DtoGridMaterial> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Material.DtoGridMaterial>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.MaterialPM oParametros = new Modelo.Parametro.NovaComercial.dbo.MaterialPM
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    MaterialDescripcion = pMaterialDescripcion,
                    //Baja                = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };
                
                AccesoDatos.NovaComercial.dbo.Material oBD = new AccesoDatos.NovaComercial.dbo.Material();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                if (!response.Error)
                {
                    Modelo.NovaComercial.dbo.Material.DtoGridMaterial item = null;
                    res.Datos = new List<Modelo.NovaComercial.dbo.Material.DtoGridMaterial>();
                    
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Material.DtoGridMaterial
                            {
                                MaterialId          = int.Parse(dr["MaterialId"].ToString()),
                                MaterialDescripcion = dr["MaterialDescripcion"].ToString(),
                                Costo               = decimal.Parse(dr["Costo"].ToString()),
                                Baja                = bool.Parse(dr["Baja"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserMaterialConPrecioGrid(String pServicioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.MaterialPM oParametros = new Modelo.Parametro.NovaComercial.dbo.MaterialPM()
                {
                    Opcion              = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    MaterialDescripcion = pServicioDescripcion,
                    //Baja                = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };

                AccesoDatos.NovaComercial.dbo.Material oBD = new AccesoDatos.NovaComercial.dbo.Material();
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
                                ItemId              = Int32.Parse(dr["MaterialId"].ToString()),
                                ItemDescripcion     = dr["MaterialDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ServicioTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
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


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Material obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Material oE = new Entidades.NovaComercial.dbo.Material();
            DataSet ds = new DataSet();

            oE.MaterialId = obj.MaterialId;
            oE.MaterialDescripcion = obj.MaterialDescripcion;
            oE.UsuarioCreacionId = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.MaterialId == 0)
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

            res.Id = int.Parse(ds.Tables[0].Rows[0]["MaterialId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(Int32 pMaterialId, Int32 pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Material oE = new Entidades.NovaComercial.dbo.Material();
            DataSet ds = new DataSet();

            oE.MaterialId = pMaterialId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id = int.Parse(ds.Tables[0].Rows[0]["MaterialId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }
    }
}