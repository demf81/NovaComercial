using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class MedicamentoCuadroTipo : Conexion.ConexionSQL
    {
        public MedicamentoCuadroTipo()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.MedicamentoCuadroTipoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMedicamentoCuadroTipo_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                           oParametro.Opcion),
                        new SqlParameter("@MedicamentoCuadroTipoId",          oParametro.MedicamentoCuadroTipoId),
                        new SqlParameter("@MedicamentoCuadroTipoDescripcion", oParametro.MedicamentoCuadroTipoDescripcion),
                        //new SqlParameter("@Baja",                             oParametro.Baja),
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.MedicamentoCuadroTipo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMedicamentoCuadroTipo_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                           Opcion),
                        new SqlParameter("@MedicamentoCuadroTipoDescripcion", oBE.MedicamentoCuadroTipoDescripcion),
                        new SqlParameter("@UsuarioCreacionId",                oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.MedicamentoCuadroTipo oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMedicamentoCuadroTipo_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                           Opcion),
                        new SqlParameter("@MedicamentoCuadroTipoId",          oBE.MedicamentoCuadroTipoId),
                        new SqlParameter("@MedicamentoCuadroTipoDescripcion", oBE.MedicamentoCuadroTipoDescripcion),
                        new SqlParameter("@UsuarioModificacionId",            oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",                oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",                    oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                        oBE.FechaBaja),
                        new SqlParameter("@Baja",                             oBE.Baja)
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