using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class CotizacionDetalle : Conexion.ConexionSQL
    {
        public CotizacionDetalle()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.CotizacionDetallePM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacionDetalle_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              oParametro.Opcion),
                        new SqlParameter("@CotizacionDetalleId", oParametro.CotizacionDetalleId),
                        new SqlParameter("@CotizacionId",        oParametro.CotizacionId),
                        new SqlParameter("@EstatusId",           oParametro.EstatusId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - La consulta no se pudo ejecutar";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.CotizacionDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacionDetalle_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              Opcion),
                        new SqlParameter("@CotizacionId",        oBE.CotizacionId),
                        new SqlParameter("@AreaNegocioId",       oBE.AreaNegocioId),
                        new SqlParameter("@ServicioId",          oBE.ServicioId),
                        new SqlParameter("@ItemId",              oBE.ItemId),
                        new SqlParameter("@ItemDescripcion",     oBE.ItemDescripcion),
                        new SqlParameter("@ItemTipoId",          oBE.ItemTipoId),
                        new SqlParameter("@ItemTipoDescripcion", oBE.ItemTipoDescripcion),
                        new SqlParameter("@Cantidad",            oBE.Cantidad),
                        new SqlParameter("@Costo",               oBE.Costo),
                        new SqlParameter("@Precio",              oBE.Precio),
                        new SqlParameter("@Descuento",           oBE.Descuento),
                        new SqlParameter("@CampaniaId",          oBE.CampaniaId),
                        new SqlParameter("@TarifaId",            oBE.TarifaId),
                        new SqlParameter("@Iva",                 oBE.Iva),
                        new SqlParameter("@SubTotal",            oBE.SubTotal),
                        new SqlParameter("@Amparada",            oBE.Amparada),
                        new SqlParameter("@UsuarioCreacionId",   oBE.UsuarioCreacionId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - El registro no se pudo insertar.";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.CotizacionDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacionDetalle_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@CotizacionDetalleId",   oBE.CotizacionDetalleId),
                        new SqlParameter("@CotizacionId",          oBE.CotizacionId),
                        new SqlParameter("@AreaNegocioId",         oBE.AreaNegocioId),
                        new SqlParameter("@ServicioId",            oBE.ServicioId),
                        new SqlParameter("@ItemId",                oBE.ItemId),
                        new SqlParameter("@ItemDescripcion",       oBE.ItemDescripcion),
                        new SqlParameter("@ItemTipoId",            oBE.ItemTipoId),
                        new SqlParameter("@ItemTipoDescripcion",   oBE.ItemTipoDescripcion),
                        new SqlParameter("@Cantidad",              oBE.Cantidad),
                        new SqlParameter("@Costo",                 oBE.Costo),
                        new SqlParameter("@Precio",                oBE.Precio),
                        new SqlParameter("@Descuento",             oBE.Descuento),
                        new SqlParameter("@CampaniaId",            oBE.CampaniaId),
                        new SqlParameter("@TarifaId",              oBE.TarifaId),
                        new SqlParameter("@SubTotal",              oBE.SubTotal),
                        new SqlParameter("@Amparada",              oBE.Amparada),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.TituloError  = "Error SQL - El registro no se pudo actualizar.";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }
    }
}