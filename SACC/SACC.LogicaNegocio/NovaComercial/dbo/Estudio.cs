using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Estudio
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Estudio.DtoGridEstudio> ConsultarGrid(String pEstudioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Estudio.DtoGridEstudio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Estudio.DtoGridEstudio>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.EstudioPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EstudioPM
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneral,
                    EstudioDescripcion = pEstudioDescripcion,
                    //Baja               = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };
                
                AccesoDatos.NovaComercial.dbo.Estudio oBD = new AccesoDatos.NovaComercial.dbo.Estudio();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                Modelo.NovaComercial.dbo.Estudio.DtoGridEstudio item = null;
                res.Datos = new List<Modelo.NovaComercial.dbo.Estudio.DtoGridEstudio>();

                if (!response.Error)
                {
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Estudio.DtoGridEstudio
                            {
                                EstudioId          = int.Parse(dr["EstudioId"].ToString()),
                                EstudioDescripcion = dr["EstudioDescripcion"].ToString(),
                                Costo              = decimal.Parse(dr["Costo"].ToString()),
                                Baja               = bool.Parse(dr["Baja"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserEstudioConPrecioGrid(String pServicioDescripcion, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.EstudioPM oParametros = new Modelo.Parametro.NovaComercial.dbo.EstudioPM()
                {
                    Opcion             = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    EstudioDescripcion = pServicioDescripcion,
                    //Baja               = Common.ConvertEstatusIdToBoolean(pEstatusId)
                };

                AccesoDatos.NovaComercial.dbo.Estudio oBD = new AccesoDatos.NovaComercial.dbo.Estudio();
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
                                ItemId              = Int32.Parse(dr["EstudioId"].ToString()),
                                ItemDescripcion     = dr["EstudioDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["ServicioTipoId"].ToString()),
                                ItemTipoDescripcion = dr["ServicioTipoDescripcion"].ToString(),
                                Costo               = Decimal.Parse(dr["Costo"].ToString()),
                                Precio              = decimal.Parse(dr["Precio"].ToString()),
                                Anticipo            = Decimal.Parse(dr["Anticipo"].ToString()),
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


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Estudio obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Estudio oE = new Entidades.NovaComercial.dbo.Estudio();
            DataSet ds = new DataSet();

            oE.EstudioId = obj.EstudioId;
            oE.EstudioDescripcion = obj.EstudioDescripcion;
            oE.UsuarioCreacionId = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.EstudioId == 0)
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

            res.Id = int.Parse(ds.Tables[0].Rows[0]["EstudioId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(Int32 pEstudioId, Int32 pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Estudio oE = new Entidades.NovaComercial.dbo.Estudio();
            DataSet ds = new DataSet();

            oE.EstudioId = pEstudioId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id = int.Parse(ds.Tables[0].Rows[0]["EstudioId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }
    }
}