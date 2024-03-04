using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class PersonaMoper : Conexion.ConexionSQL
    {
        public PersonaMoper()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.PersonaMoperPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPersonaMoper_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion", oParametro.Opcion)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.PersonaMoper oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPersonaMoper_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            Opcion),
                        new SqlParameter("@PersonaId",         oBE.PersonaId),
                        new SqlParameter("@Nombre",            oBE.Nombre),
                        //new SqlParameter("@Paterno",           oBE.Paterno),
                        //new SqlParameter("@Materno",           oBE.Materno),
                        new SqlParameter("@Genero",            oBE.Genero),
                        new SqlParameter("@FechaNacimiento",   oBE.FechaNacimiento),
                        new SqlParameter("@CURP",              oBE.CURP),
                        //new SqlParameter("@RN",                oBE.RN),
                        //new SqlParameter("@Extranjero",        oBE.Extranjero),
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
                oEntidadResponse.Error = true;
                oEntidadResponse.TituloError = "Error SQL - El registro no se pudo insertar.";
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.PersonaMoper oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPersonaMoper_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@PersonaMoperId",        oBE.PersonaMoperId),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@ProcesoId",             oBE.ProcesoId),
                        new SqlParameter("@ClaveMovimientoId",     oBE.ClaveMovimientoId),
                        new SqlParameter("@NumeroSocio",           oBE.NumeroSocio),
                        new SqlParameter("@ClaveFamiliar",         oBE.ClaveFamiliar),
                        new SqlParameter("@Nombre",                oBE.Nombre),
                        new SqlParameter("@ApellidoPaterno",       oBE.ApellidoPaterno),
                        new SqlParameter("@ApellidoMaterno",       oBE.ApellidoMaterno),
                        new SqlParameter("@FechaNacimiento",       oBE.FechaNacimiento),
                        new SqlParameter("@CURP",                  oBE.CURP),
                        new SqlParameter("@Genero",                oBE.Genero),
                        new SqlParameter("@EstadoCivilId",         oBE.EstadoCivilId),
                        new SqlParameter("@GrupoFamiliar",         oBE.GrupoFamiliar),
                        new SqlParameter("@EmpresaId",             oBE.EmpresaId),
                        new SqlParameter("@PlantaId",              oBE.PlantaId),
                        new SqlParameter("@DepartamentoId",        oBE.DepartamentoId),
                        new SqlParameter("@TipoTrabajadorId",      oBE.TipoTrabajadorId),
                        new SqlParameter("@NumeroTernium",         oBE.NumeroTernium),
                        new SqlParameter("@RI",                    oBE.RI),                        
                        new SqlParameter("@NR",                    oBE.NR),
                        new SqlParameter("@FechaIngresoEmpresa",   oBE.FechaIngresoEmpresa),
                        new SqlParameter("@FechaIngresoGrupo",     oBE.FechaIngresoGrupo),
                        new SqlParameter("@EstatusActivo",         oBE.EstatusActivo),
                        new SqlParameter("@FechaAltaMovimiento",   oBE.FechaAltaMovimiento),
                        new SqlParameter("@FechaBajaMovimiento",   oBE.FechaBajaMovimiento),
                        new SqlParameter("@EmpresaAnteriorId",     oBE.EmpresaAnteriorId),
                        new SqlParameter("@PlantaAnteriorId",      oBE.PlantaAnteriorId),
                        new SqlParameter("@UsuarioCreacionId",     oBE.UsuarioCreacionId),
                        new SqlParameter("@FechaCreacion",         oBE.FechaCreacion),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),                   
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),                        
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
                        new SqlParameter("@PersonaMoperEstatusId", oBE.PersonaMoperEstatusId)
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