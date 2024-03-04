using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class PersonaPaquete : Conexion.ConexionSQL
    {
        public PersonaPaquete()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.dbo.PersonaPaquete oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spPersonaPaquete_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",           Opcion),
                        new SqlParameter("@PersonaPaqueteId", oBE.PersonaPaqueteId),
                        new SqlParameter("@PersonaId",        oBE.PersonaId),
                        new SqlParameter("@PaqueteId",        oBE.PaqueteId),
                        new SqlParameter("@ContratoId",       oBE.ContratoId),
                        new SqlParameter("@Baja",             oBE.Baja)
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
                oEntidadResponse.Error       = true;
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.PersonaPaquete oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spPersonaPaquete_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             Opcion),
                        new SqlParameter("@PersonaId",          oBE.PersonaId),
                        new SqlParameter("@ContratoProductoId", oBE.ContratoProductoId),
                        new SqlParameter("@PaqueteId",          oBE.PaqueteId),
                        new SqlParameter("@ContratoId",         oBE.ContratoId),
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
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.PersonaPaquete oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spPersonaPaquete_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@PersonaPaqueteId",      oBE.PersonaPaqueteId),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@PaqueteId",             oBE.PaqueteId),
                        new SqlParameter("@ContratoId",            oBE.ContratoId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@Baja",                  oBE.Baja)
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