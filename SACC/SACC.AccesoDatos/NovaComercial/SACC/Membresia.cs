using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class Membresia : Conexion.ConexionSQL
    {
        public Membresia()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.MembresiaPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spMembresia_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",          oParametro.Opcion),
                        new SqlParameter("@MembresiaId",     oParametro.MembresiaId),
                        new SqlParameter("@FechaInicio",     oParametro.FechaInicio),
                        new SqlParameter("@FechaFin",        oParametro.FechaFin),
                        new SqlParameter("@VigenciaInicio",  oParametro.VigenciaInicio),
                        new SqlParameter("@VigenciaFin",     oParametro.VigenciaFin),
                        new SqlParameter("@MembresiaTipoId", oParametro.MembresiaTipoId),
                        new SqlParameter("@Nombre",          oParametro.Nombre),
                        new SqlParameter("@NumSocio",        oParametro.NumSocio),
                        new SqlParameter("@ClaveFamiliar",   oParametro.ClaveFamiliar),
                        new SqlParameter("@NumRecibo",       oParametro.NumRecibo),
                        new SqlParameter("@EstatusId",       oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.Membresia oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spMembresia_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              Opcion),
                        new SqlParameter("@Fecha",               oBE.Fecha),
                        new SqlParameter("@Vigencia",            oBE.Vigencia),
                        new SqlParameter("@MembresiaTipoId",     oBE.MembresiaTipoId),
                        new SqlParameter("@ContratanteId",       oBE.ContratanteId),
                        new SqlParameter("@CantidadAfiliados",   oBE.CantidadAfiliados),
                        new SqlParameter("@CantidadAdicionales", oBE.CantidadAdicionales),
                        new SqlParameter("@NumPedido",           oBE.NumPedido),
                        new SqlParameter("@NumRecibo",           oBE.NumRecibo),
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



        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.Membresia oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spMembresia_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@MembresiaId",           oBE.MembresiaId),
                        new SqlParameter("@Fecha",                 oBE.Fecha),
                        new SqlParameter("@Vigencia",              oBE.Vigencia),
                        new SqlParameter("@MembresiaTipoId",       oBE.MembresiaTipoId),
                        new SqlParameter("@ContratanteId",         oBE.ContratanteId),
                        new SqlParameter("@CantidadAfiliados",     oBE.CantidadAfiliados),
                        new SqlParameter("@CantidadAdicionales",   oBE.CantidadAdicionales),
                        new SqlParameter("@NumPedido",             oBE.NumPedido),
                        new SqlParameter("@NumRecibo",             oBE.NumRecibo),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@MembresiaEstatusId",    oBE.EstatusId)
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