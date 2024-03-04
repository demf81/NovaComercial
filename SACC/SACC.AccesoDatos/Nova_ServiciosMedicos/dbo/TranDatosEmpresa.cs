using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.Nova_ServiciosMedicos.dbo
{
    public class TranDatosEmpresa : Conexion.ConexionSQL
    {
        public TranDatosEmpresa()
        {
            NombreConexion = "cxnNexus";
        }


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.spTranDatosEmpresa_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@iCodigo",              oBE.iCodigo),
                        new SqlParameter("@vcCodigoAlterno",      oBE.vcCodigoAlterno),
                        new SqlParameter("@vcNombreComercial",    oBE.vcNombreComercial),
                        new SqlParameter("@vcDireccion",          oBE.vcDireccion),
                        new SqlParameter("@IdColonia",            oBE.IdColonia),
                        new SqlParameter("@vcCodigoPostal",       oBE.vcCodigoPostal),
                        new SqlParameter("@vcZona",               oBE.vcZona),
                        new SqlParameter("@vcTelefono1",          oBE.vcTelefono1),
                        new SqlParameter("@vcTelefono2",          oBE.vcTelefono2),
                        new SqlParameter("@vcFax",                oBE.vcFax),
                        new SqlParameter("@IdTipoEmpresa",        oBE.IdTipoEmpresa),
                        new SqlParameter("@bFideicomitente",      oBE.bFideicomitente),
                        new SqlParameter("@bEnLinea",             oBE.bEnLinea),
                        new SqlParameter("@bActivo",              oBE.bActivo),
                        new SqlParameter("@vcCorreoElectronico",  oBE.vcCorreoElectronico),
                        new SqlParameter("@iEnLineaSiass",        oBE.iEnLineaSiass),
                        new SqlParameter("@vcGrupoSAP",           oBE.vcGrupoSAP),
                        new SqlParameter("@vcSectorSAP",          oBE.vcSectorSAP),
                        new SqlParameter("@vcZonaSAP",            oBE.vcZonaSAP),
                        new SqlParameter("@vcRamoIndustrialSAP",  oBE.vcRamoIndustrialSAP),
                        new SqlParameter("@vcOficinaVentaSAP",    oBE.vcOficinaVentaSAP),
                        new SqlParameter("@IdMovimiento",         oBE.IdMovimiento),
                        new SqlParameter("@dtFechaCreacion",      oBE.dtFechaCreacion),
                        new SqlParameter("@dtFechaActualizacion", oBE.dtFechaActualizacion),
                        new SqlParameter("@bProceso",             oBE.bProceso)
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.TranDatosEmpresa oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.spTranDatosEmpresa_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@iCodigo",              oBE.iCodigo),
                        new SqlParameter("@vcCodigoAlterno",      oBE.vcCodigoAlterno),
                        new SqlParameter("@vcNombreComercial",    oBE.vcNombreComercial),
                        new SqlParameter("@vcDireccion",          oBE.vcDireccion),
                        new SqlParameter("@IdColonia",            oBE.IdColonia),
                        new SqlParameter("@vcCodigoPostal",       oBE.vcCodigoPostal),
                        new SqlParameter("@vcZona",               oBE.vcZona),
                        new SqlParameter("@vcTelefono1",          oBE.vcTelefono1),
                        new SqlParameter("@vcTelefono2",          oBE.vcTelefono2),
                        new SqlParameter("@vcFax",                oBE.vcFax),
                        new SqlParameter("@IdTipoEmpresa",        oBE.IdTipoEmpresa),
                        new SqlParameter("@bFideicomitente",      oBE.bFideicomitente),
                        new SqlParameter("@bEnLinea",             oBE.bEnLinea),
                        new SqlParameter("@bActivo",              oBE.bActivo),
                        new SqlParameter("@vcCorreoElectronico",  oBE.vcCorreoElectronico),
                        new SqlParameter("@vcGrupoSAP",           oBE.vcGrupoSAP),
                        new SqlParameter("@vcSectorSAP",          oBE.vcSectorSAP),
                        new SqlParameter("@vcZonaSAP",            oBE.vcZonaSAP),
                        new SqlParameter("@vcRamoIndustrialSAP",  oBE.vcRamoIndustrialSAP),
                        new SqlParameter("@vcOficinaVentaSAP",    oBE.vcOficinaVentaSAP),
                        new SqlParameter("@IdMovimiento",         oBE.IdMovimiento),
                        new SqlParameter("@dtFechaCreacion",      oBE.dtFechaCreacion),
                        new SqlParameter("@dtFechaActualizacion", oBE.dtFechaActualizacion),
                        new SqlParameter("@bProceso",             oBE.bProceso)
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