using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Paquete : Conexion.ConexionSQL
    {
        public Paquete()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.PaquetePM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPaquete_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             oParametro.Opcion),
                        new SqlParameter("@PaqueteId",          oParametro.PaqueteId),
                        new SqlParameter("@Codigo",             oParametro.Codigo),
                        new SqlParameter("@PaqueteDescripcion", oParametro.PaqueteDescripcion),
                        new SqlParameter("@PaqueteTipoId",      oParametro.PaqueteTipoId),
                        new SqlParameter("@EstatusId",          oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Paquete oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPaquete_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             Opcion),
                        new SqlParameter("@PaqueteDescripcion", oBE.PaqueteDescripcion),
                        new SqlParameter("@AreaNegocioId",      oBE.AreaNegocioId),
                        new SqlParameter("@PaqueteTipoId",      oBE.PaqueteTipoId),
                        new SqlParameter("@GeneroId",           oBE.GeneroId),
                        new SqlParameter("@EdadDesde",          oBE.EdadDesde),
                        new SqlParameter("@EdadHasta",          oBE.EdadHasta),
                        new SqlParameter("@Codigo",             oBE.Codigo),
                        new SqlParameter("@PrecioLista",        oBE.PrecioLista),
                        new SqlParameter("@PrecioVenta",        oBE.PrecioVenta),
                        new SqlParameter("@UsuarioCreacionId",  oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Paquete oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPaquete_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@PaqueteId",             oBE.PaqueteId),
                        new SqlParameter("@PaqueteDescripcion",    oBE.PaqueteDescripcion),
                        new SqlParameter("@AreaNegocioId",         oBE.AreaNegocioId),
                        new SqlParameter("@PaqueteTipoId",         oBE.PaqueteTipoId),
                        new SqlParameter("@GeneroId",              oBE.GeneroId),
                        new SqlParameter("@EdadDesde",             oBE.EdadDesde),
                        new SqlParameter("@EdadHasta",             oBE.EdadHasta),
                        new SqlParameter("@Codigo",                oBE.Codigo),
                        new SqlParameter("@PrecioLista",           oBE.PrecioLista),
                        new SqlParameter("@PrecioVenta",           oBE.PrecioVenta),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
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