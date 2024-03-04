using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Persona : Conexion.ConexionSQL
    {
        public Persona()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.PersonaPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPersona_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.CommandTimeout = 3600;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",          oParametro.Opcion),
                        new SqlParameter("@PersonaId",       oParametro.PersonaId),
                        new SqlParameter("@Nombre",          oParametro.Nombre),
                        new SqlParameter("@Genero",          oParametro.Genero),
                        new SqlParameter("@CURP",            oParametro.CURP),
                        new SqlParameter("@FechaNacimiento", oParametro.FechaNacimiento),
                        new SqlParameter("@NumSocio",        oParametro.NumSocio),
                        new SqlParameter("@ClaveFamiliar",   oParametro.ClaveFamiliar),
                        new SqlParameter("@EstatusId",       oParametro.EstatusId),
                        new SqlParameter("@Baja",            oParametro.Baja),
                        new SqlParameter("@BajaAsociado",    oParametro.BajaAsociado)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Persona oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPersona_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            Opcion),
                        new SqlParameter("@PersonaId",         oBE.PersonaId),
                        new SqlParameter("@Nombre",            oBE.Nombre),
                        new SqlParameter("@Paterno",           oBE.Paterno),
                        new SqlParameter("@Materno",           oBE.Materno),
                        new SqlParameter("@Genero",            oBE.Genero),
                        new SqlParameter("@FechaNacimiento",   oBE.FechaNacimiento),
                        new SqlParameter("@CURP",              oBE.CURP),
                        new SqlParameter("@RN",                oBE.RN),
                        new SqlParameter("@Extranjero",        oBE.Extranjero),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Persona oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spPersona_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@PersonaId",             oBE.PersonaId),
                        new SqlParameter("@Nombre",                oBE.Nombre),
                        new SqlParameter("@Paterno",               oBE.Paterno),
                        new SqlParameter("@Materno",               oBE.Materno),
                        new SqlParameter("@Genero",                oBE.Genero),
                        new SqlParameter("@FechaNacimiento",       oBE.FechaNacimiento),
                        new SqlParameter("@CURP",                  oBE.CURP),
                        new SqlParameter("@RN",                    oBE.RN),
                        new SqlParameter("@Extranjero",            oBE.Extranjero),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
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




        //public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.dbo.Persona oBE)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

        //    try
        //    {
        //        oComando.CommandText = "dbo.spPersona_Consultar";
        //        oComando.CommandType = CommandType.StoredProcedure;
        //        oComando.Parameters.Clear();

        //        oComando.Parameters.AddRange(
        //            new SqlParameter[] {
        //                new SqlParameter("@Opcion",             Opcion),
        //                new SqlParameter("@PersonaId",          oBE.PersonaId),
        //                new SqlParameter("@Nombre",             oBE.Nombre),
        //                new SqlParameter("@Paterno",            oBE.Paterno),
        //                new SqlParameter("@Materno",            oBE.Materno),
        //                new SqlParameter("@Genero",             oBE.Genero),
        //                new SqlParameter("@FechaNacimiento",    oBE.FechaNacimiento),
        //                new SqlParameter("@RN",                 oBE.RN),
        //                new SqlParameter("@Extranjero",         oBE.Extranjero),
        //                new SqlParameter("@CURP",               oBE.CURP),
        //                new SqlParameter("@Baja",               oBE.Baja),
        //                new SqlParameter("@Filtro_ContratoId",  oBE.Filtro_ContratoId),
        //                new SqlParameter("@Filtro_ServicioId",  oBE.Filtro_ServicioId),
        //                //new SqlParameter("@Filtro_CveFamiliar", oBE.Filtro_CveFamiliar)
        //            }
        //        );

        //        if (Conectar())
        //        {
        //            SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
        //            daResultado.Fill(oEntidadResponse.Resultado);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error        = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }

        //    return oEntidadResponse;
        //}


        //public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Persona oBE)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

        //    try
        //    {
        //        oComando.CommandText = "dbo.spPersona_Insertar";
        //        oComando.CommandType = CommandType.StoredProcedure;
        //        oComando.Parameters.Clear();

        //        oComando.Parameters.AddRange(
        //            new SqlParameter[] {
        //                new SqlParameter("@Opcion",            Opcion),
        //                new SqlParameter("@PersonaId",         oBE.PersonaId),
        //                new SqlParameter("@Nombre",            oBE.Nombre),
        //                new SqlParameter("@Paterno",           oBE.Paterno),
        //                new SqlParameter("@Materno",           oBE.Materno),
        //                new SqlParameter("@Genero",            oBE.Genero),
        //                new SqlParameter("@FechaNacimiento",   oBE.FechaNacimiento),
        //                new SqlParameter("@CURP",              oBE.CURP),
        //                new SqlParameter("@UsuarioCreacionId", oBE.UsuarioCreacionId)
        //            }
        //        );

        //        if (Conectar())
        //        {
        //            SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
        //            daResultado.Fill(oEntidadResponse.Resultado);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error        = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }

        //    return oEntidadResponse;
        //}


        //public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Persona oBE)
        //{
        //    Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

        //    try
        //    {
        //        oComando.CommandText = "dbo.spPersona_Actualizar";
        //        oComando.CommandType = CommandType.StoredProcedure;
        //        oComando.Parameters.Clear();

        //        oComando.Parameters.AddRange(
        //            new SqlParameter[] {
        //                new SqlParameter("@Opcion",                Opcion),
        //                new SqlParameter("@PersonaId",             oBE.PersonaId),
        //                new SqlParameter("@Nombre",                oBE.Nombre),
        //                new SqlParameter("@Paterno",               oBE.Paterno),
        //                new SqlParameter("@Materno",               oBE.Materno),
        //                new SqlParameter("@Genero",                oBE.Genero),
        //                new SqlParameter("@FechaNacimiento",       oBE.FechaNacimiento),
        //                new SqlParameter("@RN",                    oBE.RN),
        //                new SqlParameter("@Extranjero",            oBE.Extranjero),
        //                new SqlParameter("@CURP",                  oBE.CURP),
        //                new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
        //                new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
        //                new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
        //                new SqlParameter("@FechaBaja",             oBE.FechaBaja),
        //                new SqlParameter("@Baja",                  oBE.Baja)
        //            }
        //        );

        //        if (Conectar())
        //        {
        //            SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
        //            daResultado.Fill(oEntidadResponse.Resultado);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oEntidadResponse.Error        = true;
        //        oEntidadResponse.MensajeError = ex.Message;
        //    }
        //    finally
        //    {
        //        Desconectar();
        //    }

        //    return oEntidadResponse;
        //}
    }
}