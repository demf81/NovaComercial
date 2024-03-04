using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.Registro.dbo
{
    public class CheckUp_Persona : Conexion.ConexionSQL
    {
        public CheckUp_Persona()
        {
            NombreConexion = "cxnRegistroCheckUp";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.Registro.dbo.CheckUp_Persona oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spCheckUp_Persona_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@PersonaId",            oBE.PersonaId),
                        new SqlParameter("@TerniumId",            oBE.TerniumId),
                        new SqlParameter("@NovaId",               oBE.NovaId),
                        new SqlParameter("@FamiliarId",           oBE.FamiliarId),
                        new SqlParameter("@Nombre",               oBE.Nombre),
                        new SqlParameter("@Estatus",              oBE.Estatus),
                        new SqlParameter("@Correo",               oBE.Correo),
                        new SqlParameter("@TelefonoOficina",      oBE.TelefonoOficina),
                        new SqlParameter("@TelefonoOtro",         oBE.TelefonoOtro),
                        new SqlParameter("@Genero",               oBE.Genero),
                        new SqlParameter("@PlantaId",             oBE.PlantaId),
                        new SqlParameter("@NombreSupervisor",     oBE.NombreSupervisor),
                        new SqlParameter("@FechaNacimiento",      oBE.FechaNacimiento),
                        new SqlParameter("@FechaCheckUpAnterior", oBE.FechaCheckUpAnterior),
                        new SqlParameter("@SACC_PersonaId",       oBE.SACC_PersonaId),
                        new SqlParameter("@Baja",                 oBE.Baja)
                    }
                );

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                    Desconectar();
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error        = true;
                oEntidadResponse.MensajeError = ex.Message;
            }

            return oEntidadResponse;

        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.Registro.dbo.CheckUp_Persona oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spCheckUp_Persona_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@TerniumId",            oBE.TerniumId),
                        new SqlParameter("@NovaId",               oBE.NovaId),
                        new SqlParameter("@FamiliarId",           oBE.FamiliarId),
                        new SqlParameter("@Nombre",               oBE.Nombre),
                        new SqlParameter("@Estatus",              oBE.Estatus),
                        new SqlParameter("@Correo",               oBE.Correo),
                        new SqlParameter("@TelefonoOficina",      oBE.TelefonoOficina),
                        new SqlParameter("@TelefonoOtro",         oBE.TelefonoOtro),
                        new SqlParameter("@Genero",               oBE.Genero),
                        new SqlParameter("@PlantaId",             oBE.PlantaId),
                        new SqlParameter("@NombreSupervisor",     oBE.NombreSupervisor),
                        new SqlParameter("@FechaNacimiento",      oBE.FechaNacimiento),
                        new SqlParameter("@FechaCheckUpAnterior", oBE.FechaCheckUpAnterior),
                        new SqlParameter("@SACC_PersonaId",       oBE.SACC_PersonaId),
                        new SqlParameter("@UsuarioCreacionId",    oBE.UsuarioCreacionId)
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.Registro.dbo.CheckUp_Persona oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spCheckUp_Persona_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@TerniumId",             oBE.TerniumId),
                        new SqlParameter("@NovaId",                oBE.NovaId),
                        new SqlParameter("@FamiliarId",            oBE.FamiliarId),
                        new SqlParameter("@Nombre",                oBE.Nombre),
                        new SqlParameter("@Estatus",               oBE.Estatus),
                        new SqlParameter("@Correo",                oBE.Correo),
                        new SqlParameter("@TelefonoOficina",       oBE.TelefonoOficina),
                        new SqlParameter("@TelefonoOtro",          oBE.TelefonoOtro),
                        new SqlParameter("@Genero",                oBE.Genero),
                        new SqlParameter("@PlantaId",              oBE.PlantaId),
                        new SqlParameter("@NombreSupervisor",      oBE.NombreSupervisor),
                        new SqlParameter("@FechaNacimiento",       oBE.FechaNacimiento),
                        new SqlParameter("@FechaCheckUpAnterior",  oBE.FechaCheckUpAnterior),
                        new SqlParameter("@SACC_PersonaId",        oBE.SACC_PersonaId),
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