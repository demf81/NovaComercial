using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class VentaDetalle : Conexion.ConexionSQL
    {
        public VentaDetalle()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.VentaDetallePM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spVentaDetalle_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",         oParametro.Opcion),
                        new SqlParameter("@VentaDetalleId", oParametro.VentaDetalleId),
                        new SqlParameter("@VentaId",        oParametro.VentaId),
                        new SqlParameter("@EstatusId",      oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.VentaDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spVentaDetalle_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              Opcion),
                        new SqlParameter("@VentaId",             oBE.VentaId),
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
                        new SqlParameter("@Referencia",          oBE.Referencia),
                        new SqlParameter("@Amparada",            oBE.Amparada),
                        new SqlParameter("@Anticipo",            oBE.Anticipo),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.VentaDetalle oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spVentaDetalle_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@VentaDetalleId",        oBE.VentaDetalleId),
                        new SqlParameter("@VentaId",               oBE.VentaId),
                        //new SqlParameter("@VentaDescripcion", oBE.VentaDescripcion),
                        //new SqlParameter("@Fecha",                 oBE.Fecha),
                        //new SqlParameter("@VentaTipoId",      oBE.VentaTipoId),
                        //new SqlParameter("@PersonaId",             oBE.PersonaId),
                        //new SqlParameter("@PersonaNombre",         oBE.PersonaNombre),
                        //new SqlParameter("@Telefono",              oBE.Telefono),
                        //new SqlParameter("@CorreoElectronico",     oBE.CorreoElectronico),
                        //new SqlParameter("@EmpresaNombre",         oBE.EmpresaNombre),
                        //new SqlParameter("@Contacto",              oBE.Contacto),
                        //new SqlParameter("@EmpresaId",             oBE.EmpresaId),
                        new SqlParameter("@SubTotal",              oBE.SubTotal),
                        new SqlParameter("@Descuento",             oBE.Descuento),
                        new SqlParameter("@CampaniaId",            oBE.CampaniaId),
                        //new SqlParameter("@Iva",                   oBE.Iva),
                        //new SqlParameter("@Total",                 oBE.Total),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
                        new SqlParameter("@EstatusId",             oBE.EstatusId)
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