using System;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.WebService
{
    public class AsociadoPaso : Conexion.ConexionSQL
    {
        public AsociadoPaso()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.WebService.AsociadoPaso oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "WebService.spAsociadoPaso_Consultar";
                oComando.CommandType = System.Data.CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                    Opcion),
                        new SqlParameter("@AsociadoPasoId",            oBE.AsociadoId),
                        new SqlParameter("@NumeroSocio",               oBE.NumeroSocio),
                        new SqlParameter("@ClaveFamiliar",             oBE.ClaveFamiliar),
                        new SqlParameter("@Nombre",                    oBE.Nombre),
                        new SqlParameter("@Paterno",                   oBE.Paterno),
                        new SqlParameter("@Materno",                   oBE.Materno),
                        new SqlParameter("@Curp",                      oBE.Curp),
                        new SqlParameter("@TipoUsuario",               oBE.TipoUsuario),
                        new SqlParameter("@ClaveTipoSanguineo",        oBE.ClaveTipoSanguineo),
                        new SqlParameter("@ClaveEstadoCivil",          oBE.ClaveEstadoCivil),
                        new SqlParameter("@Sexo",                      oBE.Sexo),
                        new SqlParameter("@FechaNacimiento",           oBE.FechaNacimiento),
                        new SqlParameter("@FechaFallecimiento",        oBE.FechaFallecimiento),
                        new SqlParameter("@FechaAltaContrato",         oBE.FechaAltaContrato),
                        new SqlParameter("@FechaBajaContrato",         oBE.FechaBajaContrato),
                        new SqlParameter("@FechaReactivacionContrato", oBE.FechaReactivacionContrato),
                        new SqlParameter("@FechaMovimiento",           oBE.FechaMovimiento),
                        new SqlParameter("@ClaveMovimiento",           oBE.ClaveMovimiento),
                        new SqlParameter("@ClaveEmpresaContrato",      oBE.ClaveEmpresaContrato),
                        new SqlParameter("@ClavePlantaContrato",       oBE.ClavePlantaContrato),
                        new SqlParameter("@RFCSocio",                  oBE.RFCSocio),
                        new SqlParameter("@Calle",                     oBE.Calle),
                        new SqlParameter("@NumeroExterior",            oBE.NumeroExterior),
                        new SqlParameter("@CodigoPostal",              oBE.CodigoPostal),
                        new SqlParameter("@ClaveColonia",              oBE.ClaveColonia),
                        new SqlParameter("@Colonia",                   oBE.Colonia),
                        new SqlParameter("@ClavePais",                 oBE.ClavePais),
                        new SqlParameter("@Pais",                      oBE.Pais),
                        new SqlParameter("@ClaveEstado",               oBE.ClaveEstado),
                        new SqlParameter("@Estado",                    oBE.Estado),
                        new SqlParameter("@ClaveCiudad",               oBE.ClaveCiudad),
                        new SqlParameter("@Ciudad",                    oBE.Ciudad),
                        new SqlParameter("@TelefonoCasa",              oBE.TelefonoCasa),
                        new SqlParameter("@TelefonoOficina",           oBE.TelefonoOficina),
                        new SqlParameter("@Extension",                 oBE.Extension),
                        new SqlParameter("@Fax",                       oBE.Fax),
                        new SqlParameter("@CorreoElectronico",         oBE.CorreoElectronico),
                        new SqlParameter("@NumeroAfiliacionIMSS",      oBE.NumeroAfiliacionIMSS),
                        new SqlParameter("@ApellidoCasadaEsposa",      oBE.ApellidoCasadaEsposa),
                        new SqlParameter("@AseguradoraSocioId",        oBE.AseguradoraSocioId),
                        new SqlParameter("@NumeroSocioAnterior",       oBE.NumeroSocioAnterior),
                        new SqlParameter("@ClaveFamiliarAnterior",     oBE.ClaveFamiliarAnterior),
                        new SqlParameter("@NumeroPoliza",              oBE.NumeroPoliza),
                        new SqlParameter("@NumeroEndoso",              oBE.NumeroEndoso),
                        new SqlParameter("@ActualizarDatosPersonales", oBE.ActualizarDatosPersonales),
                        new SqlParameter("@NominaTerniumId",           0),
                        new SqlParameter("@TipoTrabajador",            oBE.TipoTrabajador),
                        new SqlParameter("@FechaIngresoPlanta",        oBE.FechaIngresoPlanta),
                        new SqlParameter("@FechaIngresoGrupo",         oBE.FechaIngresoGrupo),
                        new SqlParameter("@EstatusId",                 oBE.EstatusId),
                        new SqlParameter("@Token",                     oBE.Token),
                        new SqlParameter("@Baja",                      oBE.Baja)
                    }
                );

                if (this.Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                    Desconectar();
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error = true;
                oEntidadResponse.MensajeError = ex.Message;
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.WebService.AsociadoPaso oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "NovaComercial.WebService.spAsociadoPaso_Insertar";
                oComando.CommandType = System.Data.CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                    Opcion),
                        new SqlParameter("@AsociadoId",                oBE.AsociadoId),
                        new SqlParameter("@NumeroSocio",               oBE.NumeroSocio),
                        new SqlParameter("@ClaveFamiliar",             oBE.ClaveFamiliar),
                        new SqlParameter("@Nombre",                    oBE.Nombre),
                        new SqlParameter("@Paterno",                   oBE.Paterno),
                        new SqlParameter("@Materno",                   oBE.Materno),
                        new SqlParameter("@Curp",                      oBE.Curp),
                        new SqlParameter("@TipoUsuario",               oBE.TipoUsuario),
                        new SqlParameter("@ClaveTipoSanguineo",        oBE.ClaveTipoSanguineo),
                        new SqlParameter("@ClaveEstadoCivil",          oBE.ClaveEstadoCivil),
                        new SqlParameter("@Sexo",                      oBE.Sexo),
                        new SqlParameter("@FechaNacimiento",           oBE.FechaNacimiento),
                        new SqlParameter("@FechaFallecimiento",        oBE.FechaFallecimiento),
                        new SqlParameter("@FechaAltaContrato",         oBE.FechaAltaContrato),
                        new SqlParameter("@FechaBajaContrato",         oBE.FechaBajaContrato),
                        new SqlParameter("@FechaReactivacionContrato", oBE.FechaReactivacionContrato),
                        new SqlParameter("@FechaMovimiento",           oBE.FechaMovimiento),
                        new SqlParameter("@ClaveMovimiento",           oBE.ClaveMovimiento),
                        new SqlParameter("@ClaveEmpresaContrato",      oBE.ClaveEmpresaContrato),
                        new SqlParameter("@ClavePlantaContrato",       oBE.ClavePlantaContrato),
                        new SqlParameter("@RFCSocio",                  oBE.RFCSocio),
                        new SqlParameter("@Calle",                     oBE.Calle),
                        new SqlParameter("@NumeroExterior",            oBE.NumeroExterior),
                        new SqlParameter("@CodigoPostal",              oBE.CodigoPostal),
                        new SqlParameter("@Colonia",                   oBE.Colonia),
                        new SqlParameter("@Pais",                      oBE.Pais),
                        new SqlParameter("@Estado",                    oBE.Estado),
                        new SqlParameter("@Ciudad",                    oBE.Ciudad),
                        new SqlParameter("@TelefonoCasa",              oBE.TelefonoCasa),
                        new SqlParameter("@TelefonoOficina",           oBE.TelefonoOficina),
                        new SqlParameter("@Extension",                 oBE.Extension),
                        new SqlParameter("@Fax",                       oBE.Fax),
                        new SqlParameter("@CorreoElectronico",         oBE.CorreoElectronico),
                        new SqlParameter("@NumeroAfiliacionIMSS",      oBE.NumeroAfiliacionIMSS),
                        new SqlParameter("@ApellidoCasadaEsposa",      oBE.ApellidoCasadaEsposa),
                        new SqlParameter("@AseguradoraSocioId",        oBE.AseguradoraSocioId),
                        new SqlParameter("@NumeroSocioAnterior",       oBE.NumeroSocioAnterior),
                        new SqlParameter("@ClaveFamiliarAnterior",     oBE.ClaveFamiliarAnterior),
                        new SqlParameter("@NumeroPoliza",              oBE.NumeroPoliza),
                        new SqlParameter("@NumeroEndoso",              oBE.NumeroEndoso),
                        new SqlParameter("@ActualizarDatosPersonales", oBE.ActualizarDatosPersonales),
                        new SqlParameter("@NominaTerniumId",           0),
                        new SqlParameter("@TipoTrabajador",            oBE.TipoTrabajador),
                        new SqlParameter("@FechaIngresoPlanta",        oBE.FechaIngresoPlanta),
                        new SqlParameter("@FechaIngresoGrupo",         oBE.FechaIngresoGrupo),
                        new SqlParameter("@EstatusId",                 oBE.EstatusId),
                        new SqlParameter("@Token",                     oBE.Token),
                        new SqlParameter("@UsuarioCreacionId",         oBE.UsuarioCreacionId),
                        new SqlParameter("@UsuarioModificacionId",     oBE.UsuarioModificacionId)
                    }
                );

                if (this.Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (SqlException ex)
            {
                oEntidadResponse.Error = true;
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.WebService.AsociadoPaso oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "WebService.spAsociadoPaso_Actualizar";
                oComando.CommandType = System.Data.CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                    Opcion),
                        new SqlParameter("@AsociadoId",                oBE.AsociadoId),
                        new SqlParameter("@NumeroSocio",               oBE.NumeroSocio),
                        new SqlParameter("@ClaveFamiliar",             oBE.ClaveFamiliar),
                        new SqlParameter("@Nombre",                    oBE.Nombre),
                        new SqlParameter("@Paterno",                   oBE.Paterno),
                        new SqlParameter("@Materno",                   oBE.Materno),
                        new SqlParameter("@Curp",                      oBE.Curp),
                        new SqlParameter("@TipoUsuario",               oBE.TipoUsuario),
                        new SqlParameter("@ClaveTipoSanguineo",        oBE.ClaveTipoSanguineo),
                        new SqlParameter("@ClaveEstadoCivil",          oBE.ClaveEstadoCivil),
                        new SqlParameter("@Sexo",                      oBE.Sexo),
                        new SqlParameter("@FechaNacimiento",           oBE.FechaNacimiento),
                        new SqlParameter("@FechaFallecimiento",        oBE.FechaFallecimiento),
                        new SqlParameter("@FechaAltaContrato",         oBE.FechaAltaContrato),
                        new SqlParameter("@FechaBajaContrato",         oBE.FechaBajaContrato),
                        new SqlParameter("@FechaReactivacionContrato", oBE.FechaReactivacionContrato),
                        new SqlParameter("@FechaMovimiento",           oBE.FechaMovimiento),
                        new SqlParameter("@ClaveMovimiento",           oBE.ClaveMovimiento),
                        new SqlParameter("@ClaveEmpresaContrato",      oBE.ClaveEmpresaContrato),
                        new SqlParameter("@ClavePlantaContrato",       oBE.ClavePlantaContrato),
                        new SqlParameter("@RFCSocio",                  oBE.RFCSocio),
                        new SqlParameter("@Calle",                     oBE.Calle),
                        new SqlParameter("@NumeroExterior",            oBE.NumeroExterior),
                        new SqlParameter("@CodigoPostal",              oBE.CodigoPostal),
                        new SqlParameter("@Colonia",                   oBE.Colonia),
                        new SqlParameter("@Pais",                      oBE.Pais),
                        new SqlParameter("@Estado",                    oBE.Estado),
                        new SqlParameter("@Ciudad",                    oBE.Ciudad),
                        new SqlParameter("@TelefonoCasa",              oBE.TelefonoCasa),
                        new SqlParameter("@TelefonoOficina",           oBE.TelefonoOficina),
                        new SqlParameter("@Extension",                 oBE.Extension),
                        new SqlParameter("@Fax",                       oBE.Fax),
                        new SqlParameter("@CorreoElectronico",         oBE.CorreoElectronico),
                        new SqlParameter("@NumeroAfiliacionIMSS",      oBE.NumeroAfiliacionIMSS),
                        new SqlParameter("@ApellidoCasadaEsposa",      oBE.ApellidoCasadaEsposa),
                        new SqlParameter("@AseguradoraSocioId",        oBE.AseguradoraSocioId),
                        new SqlParameter("@NumeroSocioAnterior",       oBE.NumeroSocioAnterior),
                        new SqlParameter("@ClaveFamiliarAnterior",     oBE.ClaveFamiliarAnterior),
                        new SqlParameter("@NumeroPoliza",              oBE.NumeroPoliza),
                        new SqlParameter("@NumeroEndoso",              oBE.NumeroEndoso),
                        new SqlParameter("@ActualizarDatosPersonales", oBE.ActualizarDatosPersonales),
                        new SqlParameter("@NominaTerniumId",           0),
                        new SqlParameter("@TipoTrabajador",            oBE.TipoTrabajador),
                        new SqlParameter("@FechaIngresoPlanta",        oBE.FechaIngresoPlanta),
                        new SqlParameter("@FechaIngresoGrupo",         oBE.FechaIngresoGrupo),
                        new SqlParameter("@EstatusId",                 oBE.EstatusId),
                        new SqlParameter("@Token",                     oBE.Token),
                        new SqlParameter("@UsuarioModificacionId",     oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",         oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",             oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                 oBE.FechaBaja),
                        new SqlParameter("@Baja",                      oBE.Baja)
                    }
                );

                if (this.Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(oEntidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                oEntidadResponse.Error = true;
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