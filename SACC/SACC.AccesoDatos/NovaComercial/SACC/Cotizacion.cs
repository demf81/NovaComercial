using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class Cotizacion : Conexion.ConexionSQL
    {
        public Cotizacion()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.CotizacionPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacion_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                oParametro.Opcion),
                        new SqlParameter("@CotizacionId",          oParametro.CotizacionId),
                        new SqlParameter("@CotizacionDescripcion", oParametro.CotizacionDescripcion),
                        new SqlParameter("@FechaInicio",           oParametro.FechaInicio),
                        new SqlParameter("@FechaFin",              oParametro.FechaFin),
                        new SqlParameter("@CotizacionTipoId",      oParametro.CotizacionTipoId),
                        new SqlParameter("@CotizacionEstatusId",   oParametro.CotizacionEstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.Cotizacion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacion_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@CotizacionDescripcion", oBE.CotizacionDescripcion),
                        new SqlParameter("@Fecha",                 oBE.Fecha),
                        new SqlParameter("@CotizacionTipoId",      oBE.CotizacionTipoId),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@PersonaNombre",         oBE.PersonaNombre),
                        new SqlParameter("@Telefono",              oBE.Telefono),
                        new SqlParameter("@CorreoElectronico",     oBE.CorreoElectronico),
                        new SqlParameter("@EmpresaNombre",         oBE.EmpresaNombre),
                        new SqlParameter("@Contacto",              oBE.Contacto),
                        new SqlParameter("@EmpresaId",             oBE.EmpresaId),
                        new SqlParameter("@SubTotal",              oBE.SubTotal),
                        new SqlParameter("@Descuento",             oBE.Descuento),
                        new SqlParameter("@CampaniaId",            oBE.CampaniaId),
                        new SqlParameter("@Iva",                   oBE.Iva),
                        new SqlParameter("@Total",                 oBE.Total),
                        new SqlParameter("@UsuarioCreacionId",     oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.Cotizacion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spCotizacion_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@CotizacionId",          oBE.CotizacionId),
                        new SqlParameter("@CotizacionDescripcion", oBE.CotizacionDescripcion),
                        new SqlParameter("@Fecha",                 oBE.Fecha),
                        new SqlParameter("@CotizacionTipoId",      oBE.CotizacionTipoId),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@PersonaNombre",         oBE.PersonaNombre),
                        new SqlParameter("@Telefono",              oBE.Telefono),
                        new SqlParameter("@CorreoElectronico",     oBE.CorreoElectronico),
                        new SqlParameter("@EmpresaNombre",         oBE.EmpresaNombre),
                        new SqlParameter("@Contacto",              oBE.Contacto),
                        new SqlParameter("@EmpresaId",             oBE.EmpresaId),
                        new SqlParameter("@SubTotal",              oBE.SubTotal),
                        new SqlParameter("@Descuento",             oBE.Descuento),
                        new SqlParameter("@CampaniaId",            oBE.CampaniaId),
                        new SqlParameter("@Iva",                   oBE.Iva),
                        new SqlParameter("@Total",                 oBE.Total),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@CotizacionEstatusId",   oBE.CotizacionEstatusId)
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