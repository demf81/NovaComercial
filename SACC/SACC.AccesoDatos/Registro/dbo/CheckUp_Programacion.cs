using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.Registro.dbo
{
    public class CheckUp_Programacion : Conexion.ConexionSQL
    {
        public CheckUp_Programacion()
        {
            NombreConexion = "cxnRegistroCheckUp";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.Registro.dbo.CheckUp_Programacion oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spCheckUp_Programacion_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@ProgramacionId",        oBE.ProgramacionId),
                        new SqlParameter("@ProgramacionFecha",     oBE.ProgramacionFecha),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@EsForaneo",             oBE.EsForaneo),
                        new SqlParameter("@Factura",               oBE.Factura),
                        new SqlParameter("@Comentario",            oBE.Comentario),
                        new SqlParameter("@ProgramacionEstatusId", oBE.ProgramacionEstatusId),
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.Registro.dbo.CheckUp_Programacion oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spCheckUp_Programacion_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@ProgramacionFecha",     oBE.ProgramacionFecha),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@EsForaneo",             oBE.EsForaneo),
                        new SqlParameter("@Factura",               oBE.Factura),
                        new SqlParameter("@Comentario",            oBE.Comentario),
                        new SqlParameter("@ProgramacionEstatusId", oBE.ProgramacionEstatusId),
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
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;

        }

        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.Registro.dbo.CheckUp_Programacion oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spCheckUp_Programacion_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@ProgramacionId",        oBE.ProgramacionId),
                        new SqlParameter("@ProgramacionFecha",     oBE.ProgramacionFecha),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@EsForaneo",             oBE.EsForaneo),
                        new SqlParameter("@Factura",               oBE.Factura),
                        new SqlParameter("@Comentario",            oBE.Comentario),
                        new SqlParameter("@ProgramacionEstatusId", oBE.ProgramacionEstatusId),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
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