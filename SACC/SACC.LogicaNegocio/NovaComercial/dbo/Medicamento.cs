using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Medicamento
    {
        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento> ConsultarGrid(String pMedicamentoDescripcion, Int16 pMedicamentoCuadroTipoId, Int16 pEstatudId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento>();
            
            try
            {
                Modelo.Parametro.NovaComercial.dbo.MedicamentoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.MedicamentoPM()
                {
                    Opcion                  = (Int16)SqlOpciones.ConsultaGeneralConJoin,
                    MedicamentoDescripcion  = pMedicamentoDescripcion,
                    MedicamentoCuadroTipoId = pMedicamentoCuadroTipoId,
                    EstatusId               = pEstatudId
                };
                
                AccesoDatos.NovaComercial.dbo.Medicamento oBD = new AccesoDatos.NovaComercial.dbo.Medicamento();
                Modelo.ModeloResponse response = oBD.Consultar(oParametros);
                
                Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento item = null;
                res.Datos = new List<Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento>();
                
                if (!response.Error)
                {
                    foreach (DataTable table in response.Resultado.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            item = new Modelo.NovaComercial.dbo.Medicamento.DtoGridMedicamento
                            {
                                MedicamentoId                    = int.Parse(dr["MedicamentoId"].ToString()),
                                MedicamentoDescripcion           = dr["MedicamentoDescripcion"].ToString(),
                                MedicamentoCuadroTipoId          = int.Parse(dr["MedicamentoCuadroTipoId"].ToString()),
                                MedicamentoCuadroTipoDescripcion = dr["MedicamentoCuadroTipoDescripcion"].ToString(),
                                Costo                            = decimal.Parse(dr["Costo"].ToString()),
                                Baja                             = bool.Parse(dr["Baja"].ToString())
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


        public static Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> ConsultarCtrlUserMedicamentoConPrecioGrid(String pServicioDescripcion, Int16 pServicioTipoId, Int16 pEstatusId)
        {
            Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio> res = new Modelo.ModeloJsonResponse<Modelo.NovaComercial.SACC.Servicio.DtoCtrlUserCotizacionGridServicio>();

            try
            {
                Modelo.Parametro.NovaComercial.dbo.MedicamentoPM oParametros = new Modelo.Parametro.NovaComercial.dbo.MedicamentoPM()
                {
                    Opcion                  = (Int16)SqlOpciones.ConsultaGeneralConJoinConPrecio,
                    MedicamentoDescripcion  = pServicioDescripcion,
                    MedicamentoCuadroTipoId = pServicioTipoId,
                    //EstatusId               = pEstatusId
                };

                AccesoDatos.NovaComercial.dbo.Medicamento oBD = new AccesoDatos.NovaComercial.dbo.Medicamento();
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
                                ItemId              = Int32.Parse(dr["MedicamentoId"].ToString()),
                                ItemDescripcion     = dr["MedicamentoDescripcion"].ToString(),
                                ItemTipoId          = Int16.Parse(dr["MedicamentoCuadroTipoId"].ToString()),
                                ItemTipoDescripcion = dr["MedicamentoCuadroTipoDescripcion"].ToString(),
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


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Medicamento obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Medicamento oE = new Entidades.NovaComercial.dbo.Medicamento();
            DataSet ds = new DataSet();

            oE.MedicamentoId = obj.MedicamentoId;
            oE.MedicamentoDescripcion = obj.MedicamentoDescripcion;
            oE.UsuarioCreacionId = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.MedicamentoId == 0)
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

            res.Id = int.Parse(ds.Tables[0].Rows[0]["MedicamentoId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(Int32 pMedicamentoId, Int32 pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Medicamento oE = new Entidades.NovaComercial.dbo.Medicamento();
            DataSet ds = new DataSet();

            oE.MedicamentoId = pMedicamentoId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id = int.Parse(ds.Tables[0].Rows[0]["MedicamentoId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }
    }
}
