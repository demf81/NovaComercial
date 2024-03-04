using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.Nova_ServiciosMedicos.dbo
{
    public class TranDatosAfiliado : Conexion.ConexionSQL
    {
        public TranDatosAfiliado()
        {
            NombreConexion = "cxnNexus";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.spTranDatosAfiliado_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@vchIdAfiliado",        oBE.vchIdAfiliado),
                        new SqlParameter("@vchIdentidad",         oBE.vchIdentidad),
                        new SqlParameter("@vchNombre",            oBE.vchNombre),
                        new SqlParameter("@vchPaterno",           oBE.vchPaterno),
                        new SqlParameter("@vchMaterno",           oBE.vchMaterno),
                        new SqlParameter("@tiEstatus",            oBE.tiEstatus),
                        new SqlParameter("@vchContratante",       oBE.vchContratante),
                        new SqlParameter("@iNumPoliza",           oBE.iNumPoliza),
                        new SqlParameter("@iNumCerti",            oBE.iNumCerti),
                        new SqlParameter("@dtFecIni",             oBE.dtFecIni),
                        new SqlParameter("@dtFecFin",             oBE.dtFecFin),
                        new SqlParameter("@vchDomicilio",         oBE.vchDomicilio),
                        new SqlParameter("@vchColonia",           oBE.vchColonia),
                        new SqlParameter("@vchCiudad",            oBE.vchCiudad),
                        new SqlParameter("@vchEstado",            oBE.vchEstado),
                        new SqlParameter("@dtFecNaci",            oBE.dtFecNaci),
                        new SqlParameter("@siSexo",               oBE.siSexo),
                        new SqlParameter("@chCodContrato",        oBE.chCodContrato),
                        new SqlParameter("@chCodEmpresa",         oBE.chCodEmpresa),
                        new SqlParameter("@vchDirEmp",            oBE.vchDirEmp),
                        new SqlParameter("@vchColEmp",            oBE.vchColEmp),
                        new SqlParameter("@vchCPEmp",             oBE.vchCPEmp),
                        new SqlParameter("@vchTelfEmp",           oBE.vchTelfEmp),
                        new SqlParameter("@siTipoSangre",         oBE.siTipoSangre),
                        new SqlParameter("@siEstadoCivil",        oBE.siEstadoCivil),
                        new SqlParameter("@vchCPAfiliado",        oBE.vchCPAfiliado),
                        new SqlParameter("@vchtelfAfiliado",      oBE.vchtelfAfiliado),
                        new SqlParameter("@vchCiudadEmp",         oBE.vchCiudadEmp),
                        new SqlParameter("@vchEstadoEmp",         oBE.vchEstadoEmp),
                        new SqlParameter("@vchIdHospitaliza",     oBE.vchIdHospitaliza),
                        new SqlParameter("@vchCodMedicoFam",      oBE.vchCodMedicoFam),
                        new SqlParameter("@siTipoAfiliado",       oBE.siTipoAfiliado),
                        new SqlParameter("@siConfidencial",       oBE.siConfidencial),
                        new SqlParameter("@chrCURP",              oBE.chrCURP),
                        new SqlParameter("@vchReferencia",        oBE.vchReferencia),
                        new SqlParameter("@iMunicipio",           oBE.iMunicipio),
                        new SqlParameter("@iMedicoSecundario",    oBE.iMedicoSecundario),
                        new SqlParameter("@tiRequiereEmpresa",    oBE.tiRequiereEmpresa),
                        new SqlParameter("@tiRequiereExpediente", oBE.tiRequiereExpediente),
                        new SqlParameter("@siRelacionTitular",    oBE.siRelacionTitular),
                        new SqlParameter("@vchIdAfiliadoTitular", oBE.vchIdAfiliadoTitular),
                        new SqlParameter("@iFechaInduccion",      oBE.iFechaInduccion),
                        new SqlParameter("@dtFechaCreacion",      oBE.dtFechaCreacion),
                        new SqlParameter("@dtFechaActualizacion", oBE.dtFechaActualizacion),
                        new SqlParameter("@chrCurpp",             oBE.chrCurpp),
                        new SqlParameter("@bProceso",             oBE.bProceso),
                        new SqlParameter("@IdEstadoNacimiento",   oBE.IdEstadoNacimiento),
                        new SqlParameter("@bCurpTemporal",        oBE.bCurpTemporal),
                        new SqlParameter("@IdMovimiento",         oBE.IdMovimiento),
                        new SqlParameter("@IdColonia",            oBE.IdColonia),
                        new SqlParameter("@vcTelefono2",          oBE.vcTelefono2),
                        new SqlParameter("@vcTelefonoMovil",      oBE.vcTelefonoMovil)
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.spTranDatosAfiliado_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@vchIdAfiliado",        oBE.vchIdAfiliado),
                        new SqlParameter("@vchIdentidad",         oBE.vchIdentidad),
                        new SqlParameter("@vchNombre",            oBE.vchNombre),
                        new SqlParameter("@vchPaterno",           oBE.vchPaterno),
                        new SqlParameter("@vchMaterno",           oBE.vchMaterno),
                        new SqlParameter("@tiEstatus",            oBE.tiEstatus),
                        new SqlParameter("@vchContratante",       oBE.vchContratante),
                        new SqlParameter("@iNumPoliza",           oBE.iNumPoliza),
                        new SqlParameter("@iNumCerti",            oBE.iNumCerti),
                        new SqlParameter("@dtFecIni",             oBE.dtFecIni),
                        new SqlParameter("@dtFecFin",             oBE.dtFecFin),
                        new SqlParameter("@vchDomicilio",         oBE.vchDomicilio),
                        new SqlParameter("@vchColonia",           oBE.vchColonia),
                        new SqlParameter("@vchCiudad",            oBE.vchCiudad),
                        new SqlParameter("@vchEstado",            oBE.vchEstado),
                        new SqlParameter("@dtFecNaci",            oBE.dtFecNaci),
                        new SqlParameter("@siSexo",               oBE.siSexo),
                        new SqlParameter("@chCodContrato",        oBE.chCodContrato),
                        new SqlParameter("@chCodEmpresa",         oBE.chCodEmpresa),
                        new SqlParameter("@vchDirEmp",            oBE.vchDirEmp),
                        new SqlParameter("@vchColEmp",            oBE.vchColEmp),
                        new SqlParameter("@vchCPEmp",             oBE.vchCPEmp),
                        new SqlParameter("@vchTelfEmp",           oBE.vchTelfEmp),
                        new SqlParameter("@siTipoSangre",         oBE.siTipoSangre),
                        new SqlParameter("@siEstadoCivil",        oBE.siEstadoCivil),
                        new SqlParameter("@vchCPAfiliado",        oBE.vchCPAfiliado),
                        new SqlParameter("@vchtelfAfiliado",      oBE.vchtelfAfiliado),
                        new SqlParameter("@vchCiudadEmp",         oBE.vchCiudadEmp),
                        new SqlParameter("@vchEstadoEmp",         oBE.vchEstadoEmp),
                        new SqlParameter("@vchIdHospitaliza",     oBE.vchIdHospitaliza),
                        new SqlParameter("@vchCodMedicoFam",      oBE.vchCodMedicoFam),
                        new SqlParameter("@siTipoAfiliado",       oBE.siTipoAfiliado),
                        new SqlParameter("@siConfidencial",       oBE.siConfidencial),
                        new SqlParameter("@chrCURP",              oBE.chrCURP),
                        new SqlParameter("@vchReferencia",        oBE.vchReferencia),
                        new SqlParameter("@iMunicipio",           oBE.iMunicipio),
                        new SqlParameter("@iMedicoSecundario",    oBE.iMedicoSecundario),
                        new SqlParameter("@tiRequiereEmpresa",    oBE.tiRequiereEmpresa),
                        new SqlParameter("@tiRequiereExpediente", oBE.tiRequiereExpediente),
                        new SqlParameter("@siRelacionTitular",    oBE.siRelacionTitular),
                        new SqlParameter("@vchIdAfiliadoTitular", oBE.vchIdAfiliadoTitular),
                        new SqlParameter("@iFechaInduccion",      oBE.iFechaInduccion),
                        new SqlParameter("@dtFechaCreacion",      oBE.dtFechaCreacion),
                        new SqlParameter("@dtFechaActualizacion", oBE.dtFechaActualizacion),
                        new SqlParameter("@chrCurpp",             oBE.chrCurpp),
                        new SqlParameter("@bProceso",             oBE.bProceso),
                        new SqlParameter("@IdEstadoNacimiento",   oBE.IdEstadoNacimiento),
                        new SqlParameter("@bCurpTemporal",        oBE.bCurpTemporal),
                        new SqlParameter("@IdMovimiento",         oBE.IdMovimiento),
                        new SqlParameter("@IdColonia",            oBE.IdColonia),
                        new SqlParameter("@vcTelefono2",          oBE.vcTelefono2),
                        new SqlParameter("@vcTelefonoMovil",      oBE.vcTelefonoMovil)
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
                oEntidadResponse.Error        = true;
                oEntidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return oEntidadResponse;
        }


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.Nova_ServiciosMedicos.dbo.TranDatosAfiliado oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "SACC.spTranDatosAfiliado_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@vchIdAfiliado",        oBE.vchIdAfiliado),
                        new SqlParameter("@vchIdentidad",         oBE.vchIdentidad),
                        new SqlParameter("@vchNombre",            oBE.vchNombre),
                        new SqlParameter("@vchPaterno",           oBE.vchPaterno),
                        new SqlParameter("@vchMaterno",           oBE.vchMaterno),
                        new SqlParameter("@tiEstatus",            oBE.tiEstatus),
                        new SqlParameter("@vchContratante",       oBE.vchContratante),
                        new SqlParameter("@iNumPoliza",           oBE.iNumPoliza),
                        new SqlParameter("@iNumCerti",            oBE.iNumCerti),
                        new SqlParameter("@dtFecIni",             oBE.dtFecIni),
                        new SqlParameter("@dtFecFin",             oBE.dtFecFin),
                        new SqlParameter("@vchDomicilio",         oBE.vchDomicilio),
                        new SqlParameter("@vchColonia",           oBE.vchColonia),
                        new SqlParameter("@vchCiudad",            oBE.vchCiudad),
                        new SqlParameter("@vchEstado",            oBE.vchEstado),
                        new SqlParameter("@dtFecNaci",            oBE.dtFecNaci),
                        new SqlParameter("@siSexo",               oBE.siSexo),
                        new SqlParameter("@chCodContrato",        oBE.chCodContrato),
                        new SqlParameter("@chCodEmpresa",         oBE.chCodEmpresa),
                        new SqlParameter("@vchDirEmp",            oBE.vchDirEmp),
                        new SqlParameter("@vchColEmp",            oBE.vchColEmp),
                        new SqlParameter("@vchCPEmp",             oBE.vchCPEmp),
                        new SqlParameter("@vchTelfEmp",           oBE.vchTelfEmp),
                        new SqlParameter("@siTipoSangre",         oBE.siTipoSangre),
                        new SqlParameter("@siEstadoCivil",        oBE.siEstadoCivil),
                        new SqlParameter("@vchCPAfiliado",        oBE.vchCPAfiliado),
                        new SqlParameter("@vchtelfAfiliado",      oBE.vchtelfAfiliado),
                        new SqlParameter("@vchCiudadEmp",         oBE.vchCiudadEmp),
                        new SqlParameter("@vchEstadoEmp",         oBE.vchEstadoEmp),
                        new SqlParameter("@vchIdHospitaliza",     oBE.vchIdHospitaliza),
                        new SqlParameter("@vchCodMedicoFam",      oBE.vchCodMedicoFam),
                        new SqlParameter("@siTipoAfiliado",       oBE.siTipoAfiliado),
                        new SqlParameter("@siConfidencial",       oBE.siConfidencial),
                        new SqlParameter("@chrCURP",              oBE.chrCURP),
                        new SqlParameter("@vchReferencia",        oBE.vchReferencia),
                        new SqlParameter("@iMunicipio",           oBE.iMunicipio),
                        new SqlParameter("@iMedicoSecundario",    oBE.iMedicoSecundario),
                        new SqlParameter("@tiRequiereEmpresa",    oBE.tiRequiereEmpresa),
                        new SqlParameter("@tiRequiereExpediente", oBE.tiRequiereExpediente),
                        new SqlParameter("@siRelacionTitular",    oBE.siRelacionTitular),
                        new SqlParameter("@vchIdAfiliadoTitular", oBE.vchIdAfiliadoTitular),
                        new SqlParameter("@iFechaInduccion",      oBE.iFechaInduccion),
                        new SqlParameter("@dtFechaCreacion",      oBE.dtFechaCreacion),
                        new SqlParameter("@dtFechaActualizacion", oBE.dtFechaActualizacion),
                        new SqlParameter("@chrCurpp",             oBE.chrCurpp),
                        new SqlParameter("@bProceso",             oBE.bProceso),
                        new SqlParameter("@IdEstadoNacimiento",   oBE.IdEstadoNacimiento),
                        new SqlParameter("@bCurpTemporal",        oBE.bCurpTemporal),
                        new SqlParameter("@IdMovimiento",         oBE.IdMovimiento),
                        new SqlParameter("@IdColonia",            oBE.IdColonia),
                        new SqlParameter("@vcTelefono2",          oBE.vcTelefono2),
                        new SqlParameter("@vcTelefonoMovil",      oBE.vcTelefonoMovil)
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