using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class VentaUnitariaDetalleTipo : Conexion.ConexionSQL
    {
        public VentaUnitariaDetalleTipo()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitariaDetalleTipo_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                              Opcion),
                        new SqlParameter("@VentaUnitariaDetalleTipoId",          oBE.VentaUnitariaDetalleTipoId),
                        new SqlParameter("@VentaUnitariaDetalleTipoDescripcion", oBE.VentaUnitariaDetalleTipoDescripcion),
                        new SqlParameter("@Baja",                                oBE.Baja)
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitariaDetalleTipo_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                              Opcion),
                        new SqlParameter("@VentaUnitariaDetalleTipoDescripcion", oBE.VentaUnitariaDetalleTipoDescripcion),
                        new SqlParameter("@UsuarioCreacionId",                   oBE.UsuarioCreacionId)
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitariaDetalleTipo_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                              Opcion),
                        new SqlParameter("@VentaUnitariaDetalleTipoId",          oBE.VentaUnitariaDetalleTipoId),
                        new SqlParameter("@VentaUnitariaDetalleTipoDescripcion", oBE.VentaUnitariaDetalleTipoDescripcion),
                        new SqlParameter("@UsuarioModificacionId",               oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",                   oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",                       oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                           oBE.FechaBaja),
                        new SqlParameter("@Baja",                                oBE.Baja)
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