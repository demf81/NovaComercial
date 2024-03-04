using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.Nova_ServiciosMedicos.dbo
{
    public class CatAsociado : Conexion.ConexionSQL
    {
        public CatAsociado()
        {
            NombreConexion = "cxnNexus";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.CatAsociado oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.spCatAsociado_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@IdNumeroSocio",           oBE.IdNumeroSocio),
                        new SqlParameter("@NumeroAfiliado",          oBE.NumeroAfiliado),
                        new SqlParameter("@vcAfiliado",              oBE.vcAfiliado),
                        new SqlParameter("@vcTelefono",              oBE.vcTelefono),
                        new SqlParameter("@bActivo",                 oBE.bActivo),
                        new SqlParameter("@vcDomicilio",             oBE.vcDomicilio),
                        new SqlParameter("@IdColonia",               oBE.IdColonia),
                        new SqlParameter("@IdAseguradora",           oBE.IdAseguradora),
                        new SqlParameter("@vcPoliza",                oBE.vcPoliza),
                        new SqlParameter("@iNoPoliza",               oBE.iNoPoliza),
                        new SqlParameter("@dtInicio",                oBE.dtInicio),
                        new SqlParameter("@dtFinal",                 oBE.dtFinal),
                        new SqlParameter("@vcCurp",                  oBE.vcCurp),
                        new SqlParameter("@IdInstitucional",         oBE.IdInstitucional),
                        new SqlParameter("@vcApellidoPaterno",       oBE.vcApellidoPaterno),
                        new SqlParameter("@vcApellidoMaterno",       oBE.vcApellidoMaterno),
                        new SqlParameter("@vcNombre",                oBE.vcNombre),
                        new SqlParameter("@IdSexo",                  oBE.IdSexo),
                        new SqlParameter("@IdEstadoCivil",           oBE.IdEstadoCivil),
                        new SqlParameter("@dtFechaNacimiento",       oBE.dtFechaNacimiento),
                        new SqlParameter("@IdTipoSangre",            oBE.IdTipoSangre),
                        new SqlParameter("@bConfidencial",           oBE.bConfidencial),
                        new SqlParameter("@bRequiereEmpresa",        oBE.bRequiereEmpresa),
                        new SqlParameter("@bReqExpedienteFisico",    oBE.bReqExpedienteFisico),
                        new SqlParameter("@IdMedicoFamiliar",        oBE.IdMedicoFamiliar),
                        new SqlParameter("@IdClasificacionAfiliado", oBE.IdClasificacionAfiliado),
                        new SqlParameter("@vcReferencias",           oBE.vcReferencias),
                        new SqlParameter("@vcCodigoPostal",          oBE.vcCodigoPostal),
                        new SqlParameter("@vcTelefono2",             oBE.vcTelefono2),
                        new SqlParameter("@IdTipoAfiliado",          oBE.IdTipoAfiliado),
                        new SqlParameter("@dtFechaInicio",           oBE.dtFechaInicio),
                        new SqlParameter("@dtFechaTermino",          oBE.dtFechaTermino),
                        new SqlParameter("@vcContratante",           oBE.vcContratante),
                        new SqlParameter("@iNumeroCertificado",      oBE.iNumeroCertificado),
                        new SqlParameter("@IdEmpresa",               oBE.IdEmpresa),
                        new SqlParameter("@vcNumeroTernium",         oBE.vcNumeroTernium),
                        new SqlParameter("@IdReligion",              oBE.IdReligion),
                        new SqlParameter("@IdNacionalidad",          oBE.IdNacionalidad),
                        new SqlParameter("@IdTitular",               oBE.IdTitular),
                        new SqlParameter("@bTitularPersona",         oBE.bTitularPersona),
                        new SqlParameter("@vcNumeroSocio",           oBE.vcNumeroSocio),
                        new SqlParameter("@vcClaveFamiliar",         oBE.vcClaveFamiliar),
                        new SqlParameter("@IdEstadoNacimiento",      oBE.IdEstadoNacimiento),
                        new SqlParameter("@vcNombreContacto",        oBE.vcNombreContacto),
                        new SqlParameter("@vcDireccionContacto",     oBE.vcDireccionContacto),
                        new SqlParameter("@IdColoniaContacto",       oBE.IdColoniaContacto),
                        new SqlParameter("@iCodigoPostalContacto",   oBE.iCodigoPostalContacto),
                        new SqlParameter("@vcTelefonoContacto",      oBE.vcTelefonoContacto),
                        new SqlParameter("@IdEscolaridad",           oBE.IdEscolaridad),
                        new SqlParameter("@IdOcupacion",             oBE.IdOcupacion),
                        new SqlParameter("@vcPuesto",                oBE.vcPuesto),
                        new SqlParameter("@IdUnidad",                oBE.IdUnidad),
                        new SqlParameter("@bServicioSuspendido",     oBE.bServicioSuspendido),
                        new SqlParameter("@vcClavePaciente",         oBE.vcClavePaciente),
                        new SqlParameter("@vcCorreoElectronico",     oBE.vcCorreoElectronico),
                        new SqlParameter("@vcCorreoContacto",        oBE.vcCorreoContacto),
                        new SqlParameter("@vcTelefono2Contacto",     oBE.vcTelefono2Contacto),
                        new SqlParameter("@vcMovilContacto",         oBE.vcMovilContacto),
                        new SqlParameter("@vcTelefonoMovil",         oBE.vcTelefonoMovil),
                        new SqlParameter("@bCurpTemporal",           oBE.bCurpTemporal),
                        new SqlParameter("@vcIdentidad",             oBE.vcIdentidad)
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