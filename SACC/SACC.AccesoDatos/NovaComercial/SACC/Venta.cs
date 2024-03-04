using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class Venta : Conexion.ConexionSQL
    {
        public Venta()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.VentaPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spVenta_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",           oParametro.Opcion),
                        new SqlParameter("@VentaId",          oParametro.VentaId),
                        new SqlParameter("@VentaDescripcion", oParametro.VentaDescripcion),
                        new SqlParameter("@FechaInicio",      oParametro.FechaInicio),
                        new SqlParameter("@FechaFin",         oParametro.FechaFin),
                        new SqlParameter("@VentaTipoId",      oParametro.VentaTipoId),
                        new SqlParameter("@EstatusId",        oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.Venta oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spVenta_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            Opcion),
                        new SqlParameter("@CotizacionId",      oBE.CotizacionId),
                        new SqlParameter("@VentaDescripcion",  oBE.VentaDescripcion),
                        new SqlParameter("@Fecha",             oBE.Fecha),
                        new SqlParameter("@VentaTipoId",       oBE.VentaTipoId),
                        new SqlParameter("@PersonaId",         oBE.PersonaId),
                        new SqlParameter("@EmpresaId",         oBE.EmpresaId),
                        new SqlParameter("@SubTotal",          oBE.SubTotal),
                        new SqlParameter("@Descuento",         oBE.Descuento),
                        new SqlParameter("@CampaniaId",        oBE.CampaniaId),
                        new SqlParameter("@Iva",               oBE.Iva),
                        new SqlParameter("@Total",             oBE.Total),
                        new SqlParameter("@Referencia",        oBE.Referencia),
                        new SqlParameter("@Anticipo",          oBE.Anticipo),
                        new SqlParameter("@UsuarioCreacionId", oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.Venta oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spVenta_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@VentaId",               oBE.VentaId),
                        new SqlParameter("@CotizacionId",          oBE.CotizacionId),
                        new SqlParameter("@VentaDescripcion",      oBE.VentaDescripcion),
                        new SqlParameter("@Fecha",                 oBE.Fecha),
                        new SqlParameter("@VentaTipoId",           oBE.VentaTipoId),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@EmpresaId",             oBE.EmpresaId),
                        new SqlParameter("@SubTotal",              oBE.SubTotal),
                        new SqlParameter("@Descuento",             oBE.Descuento),
                        new SqlParameter("@CampaniaId",            oBE.CampaniaId),
                        new SqlParameter("@Iva",                   oBE.Iva),
                        new SqlParameter("@Total",                 oBE.Total),
                        new SqlParameter("@Referencia",            oBE.Referencia),
                        new SqlParameter("@Anticipo",              oBE.Anticipo),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
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