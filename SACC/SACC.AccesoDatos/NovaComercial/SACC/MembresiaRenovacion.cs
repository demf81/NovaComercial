using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class MembresiaRenovacion : Conexion.ConexionSQL
    {
        public MembresiaRenovacion()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.MembresiaRenovacionPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spMembresiaRenovacion_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                oParametro.Opcion),
                        new SqlParameter("@MembresiaRenovacionId", oParametro.MembresiaRenovacionId),
                        new SqlParameter("@MembresiaId",           oParametro.MembresiaId),
                        new SqlParameter("@FechaInicio",           oParametro.FechaInicio),
                        new SqlParameter("@FechaFin",              oParametro.FechaFin),
                        new SqlParameter("@VigenciaInicio",        oParametro.VigenciaInicio),
                        new SqlParameter("@VigenciaFin",           oParametro.VigenciaFin),
                        new SqlParameter("@NumSocio",              oParametro.NumSocio),
                        new SqlParameter("@NumPedido",             oParametro.NumPedido),
                        new SqlParameter("@NumRecibo",             oParametro.NumRecibo),
                        new SqlParameter("@MembresiaTipoId",       oParametro.MembresiaTipoId),
                        new SqlParameter("@EstatusId",             oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.MembresiaRenovacion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spMembresiaRenovacion_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            Opcion),
                        new SqlParameter("@MembresiaId",       oBE.MembresiaId),
                        new SqlParameter("@FechaPago",         oBE.Fecha),
                        new SqlParameter("@NumPedido",         oBE.NumPedido),
                        new SqlParameter("@NumRecibo",         oBE.NumRecibo),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.MembresiaRenovacion oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spMembresiaRenovacion_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@MembresiaRenovacionId", oBE.MembresiaRenovacionId),
                        new SqlParameter("@MembresiaId",           oBE.MembresiaId),
                        new SqlParameter("@Fecha",                 oBE.Fecha),
                        new SqlParameter("@NumPedido",             oBE.NumPedido),
                        new SqlParameter("@NumRecibo",             oBE.NumRecibo),
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