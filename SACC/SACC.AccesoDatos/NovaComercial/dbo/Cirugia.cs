using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Cirugia : Conexion.ConexionSQL
    {
        public Cirugia()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.CirugiaPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spCirugia_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",             oParametro.Opcion),
                        new SqlParameter("@CirugiaId",          oParametro.CirugiaId),
                        new SqlParameter("@CirugiaDescripcion", oParametro.CirugiaDescripcion),
                        //new SqlParameter("@Baja",               oParametro.Baja)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Cirugia oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spCirugia_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",               Opcion),
                        new SqlParameter("@CirugiaDescripcion",   oBE.CirugiaDescripcion),
                        new SqlParameter("@Codigo",               oBE.Codigo),
                        new SqlParameter("@Precio",               oBE.Precio),
                        new SqlParameter("@Iva",                  oBE.Iva),
                        new SqlParameter("@TipoHonorario",        oBE.TipoHonorario),
                        new SqlParameter("@GeneraCargo",          oBE.GeneraCargo),
                        new SqlParameter("@RequiereAutorizacion", oBE.RequiereAutorizacion),
                        new SqlParameter("@IndicacionesPaciente", oBE.IndicacionesPaciente),
                        new SqlParameter("@IndicacionesPersonal", oBE.IndicacionesPersonal),
                        new SqlParameter("@DuracionMin",          oBE.DuracionMin),
                        new SqlParameter("@UsuarioCreacionId",    oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Cirugia oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spCirugia_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                Opcion),
                        new SqlParameter("@CirugiaId",             oBE.CirugiaId),
                        new SqlParameter("@CirugiaDescripcion",    oBE.CirugiaDescripcion),
                        new SqlParameter("@Codigo",                oBE.Codigo),
                        new SqlParameter("@Precio",                oBE.Precio),
                        new SqlParameter("@Iva",                   oBE.Iva),
                        new SqlParameter("@TipoHonorario",         oBE.TipoHonorario),
                        new SqlParameter("@GeneraCargo",           oBE.GeneraCargo),
                        new SqlParameter("@RequiereAutorizacion",  oBE.RequiereAutorizacion),
                        new SqlParameter("@IndicacionesPaciente",  oBE.IndicacionesPaciente),
                        new SqlParameter("@IndicacionesPersonal",  oBE.IndicacionesPersonal),
                        new SqlParameter("@DuracionMin",           oBE.DuracionMin),
                        new SqlParameter("@UsuarioModificacionId", oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",     oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",         oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",             oBE.FechaBaja),
                        new SqlParameter("@Baja",                  oBE.Baja),
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