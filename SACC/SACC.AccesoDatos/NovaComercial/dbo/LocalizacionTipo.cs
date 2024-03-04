using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class LocalizacionTipo : Conexion.ConexionSQL
    {
        public LocalizacionTipo()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.dbo.LocalizacionTipo oBE)
        {
            Entidades.EntidadResponse entidadResponse = new Entidades.EntidadResponse();

            try
            {
                DataSet dataSet = new DataSet();
                oComando.CommandText = "SACC.spLocalizacionTipo_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oParametro = new SqlParameter("@Opcion", SqlDbType.SmallInt);
                oParametro.Value = Opcion;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@LocalizacionTipoId", SqlDbType.Int);
                oParametro.Value = oBE.LocalizacionTipoId;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@LocalizacionTipoDescripcion", SqlDbType.VarChar);
                oParametro.Value = oBE.LocalizacionTipoDescripcion;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@Baja", SqlDbType.Bit);
                oParametro.Value = oBE.Baja;
                oComando.Parameters.Add(oParametro);

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(entidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                entidadResponse.Error = true;
                entidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return entidadResponse;
        }

        public Entidades.EntidadResponse Insertar(short Option, Entidades.NovaComercial.dbo.LocalizacionTipo oBE)
        {
            Entidades.EntidadResponse entidadResponse = new Entidades.EntidadResponse();

            try
            {
                DataSet dataSet = new DataSet();
                oComando.CommandText = "SACC.spLocalizacionTipo_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oParametro = new SqlParameter("@Opcion", SqlDbType.SmallInt);
                oParametro.Value = Option;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@LocalizacionTipoDescripcion", SqlDbType.VarChar);
                oParametro.Value = oBE.LocalizacionTipoDescripcion;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@UsuarioCreacionId", SqlDbType.Int);
                oParametro.Value = oBE.UsuarioCreacionId;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@UsuarioModificacionId", SqlDbType.Int);
                oParametro.Value = oBE.UsuarioModificacionId;
                oComando.Parameters.Add(oParametro);

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(entidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                entidadResponse.Error = true;
                entidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return entidadResponse;
        }

        public Entidades.EntidadResponse Actualizar(short Option, SACC.Entidades.NovaComercial.dbo.LocalizacionTipo oBE)
        {
            Entidades.EntidadResponse entidadResponse = new Entidades.EntidadResponse();

            try
            {
                DataSet dataSet = new DataSet();
                oComando.CommandText = "SACC.spLocalizacionTipo_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oParametro = new SqlParameter("@Opcion", SqlDbType.SmallInt);
                oParametro.Value = Option;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@LocalizacionTipoId", SqlDbType.Int);
                oParametro.Value = oBE.LocalizacionTipoId;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@LocalizacionTipoDescripcion", SqlDbType.VarChar);
                oParametro.Value = oBE.LocalizacionTipoDescripcion;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@UsuarioModificacionId", SqlDbType.Int);
                oParametro.Value = oBE.UsuarioModificacionId;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@FechaModificacion", SqlDbType.DateTime);
                oParametro.Value = oBE.FechaModificacion;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@UsuarioBajaId", SqlDbType.Int);
                oParametro.Value = oBE.UsuarioBajaId;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@FechaBaja", SqlDbType.DateTime);
                oParametro.Value = oBE.FechaBaja;
                oComando.Parameters.Add(oParametro);

                oParametro = new SqlParameter("@Baja", SqlDbType.Bit);
                oParametro.Value = oBE.Baja;
                oComando.Parameters.Add(oParametro);

                if (Conectar())
                {
                    SqlDataAdapter daResultado = new SqlDataAdapter(oComando);
                    daResultado.Fill(entidadResponse.Resultado);
                }
            }
            catch (Exception ex)
            {
                entidadResponse.Error = true;
                entidadResponse.MensajeError = ex.Message;
            }
            finally
            {
                Desconectar();
            }

            return entidadResponse;
        }
    }
}
