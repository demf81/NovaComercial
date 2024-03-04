using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.SACC
{
    public class EmpresaDatosFiscales : Conexion.ConexionSQL
    {
        public EmpresaDatosFiscales()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.SACC.EmpresaDatosFiscalesPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaDatosFiscales_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                 oParametro.Opcion),
                        new SqlParameter("@EmpresaDatosFiscalesId", oParametro.EmpresaDatosFiscalesId),
                        new SqlParameter("@EmpresaId",              oParametro.EmpresaId),
                        new SqlParameter("@EstatusId",              oParametro.EstatusId)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.SACC.EmpresaDatosFiscales oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaDatosFiscales_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",            Opcion),
                        new SqlParameter("@EmpresaId",         oBE.EmpresaId),
                        new SqlParameter("@RazonSocial",       oBE.RazonSocial),
                        new SqlParameter("@RFC",               oBE.RFC),
                        new SqlParameter("@PaisId",            oBE.PaisId),
                        new SqlParameter("@EstadoId",          oBE.EstadoId),
                        new SqlParameter("@MunicipioId",       oBE.MunicipioId),
                        new SqlParameter("@Colonia",           oBE.Colonia),
                        new SqlParameter("@Calle",             oBE.Calle),
                        new SqlParameter("@NumeroExterior",    oBE.NumeroExterior),
                        new SqlParameter("@NumeroInterior",    oBE.NumeroInterior),
                        new SqlParameter("@CodigoPostal",      oBE.CodigoPostal),
                        new SqlParameter("@CorreoElectronico", oBE.CorreoElectronico),
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.SACC.EmpresaDatosFiscales oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "SACC.spEmpresaDatosFiscales_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                 Opcion),
                        new SqlParameter("@EmpresaDatosFiscalesId", oBE.EmpresaDatosFiscalesId),
                        new SqlParameter("@EmpresaId",              oBE.EmpresaId),
                        new SqlParameter("@RazonSocial",            oBE.RazonSocial),
                        new SqlParameter("@RFC",                    oBE.RFC),
                        new SqlParameter("@PaisId",                 oBE.PaisId),
                        new SqlParameter("@EstadoId",               oBE.EstadoId),
                        new SqlParameter("@MunicipioId",            oBE.MunicipioId),
                        new SqlParameter("@Colonia",                oBE.Colonia),
                        new SqlParameter("@Calle",                  oBE.Calle),
                        new SqlParameter("@NumeroExterior",         oBE.NumeroExterior),
                        new SqlParameter("@NumeroInterior",         oBE.NumeroInterior),
                        new SqlParameter("@CodigoPostal",           oBE.CodigoPostal),
                        new SqlParameter("@CorreoElectronico",      oBE.CorreoElectronico),
                        new SqlParameter("@UsuarioModificacionId",  oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",      oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",          oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",              oBE.FechaBaja),
                        new SqlParameter("@EstatusId",              oBE.EstatusId)
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