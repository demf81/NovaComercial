using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Material : Conexion.ConexionSQL
    {
        public Material()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.MaterialPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMaterial_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",              oParametro.Opcion),
                        new SqlParameter("@MaterialId",          oParametro.MaterialId),
                        new SqlParameter("@MaterialDescripcion", oParametro.MaterialDescripcion),
                        //new SqlParameter("@Baja",                oParametro.Baja)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Material oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMaterial_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                 Opcion),
                        new SqlParameter("@MaterialDescripcion",    oBE.MaterialDescripcion),
                        new SqlParameter("@Codigo",                 oBE.Codigo),
                        new SqlParameter("@CodigoAlterno",          oBE.CodigoAlterno),
                        new SqlParameter("@CodigoServiciosMedicos", oBE.CodigoServiciosMedicos),
                        new SqlParameter("@ProveedorId",            oBE.ProveedorId),
                        new SqlParameter("@CateterSonda",           oBE.CateterSonda),
                        new SqlParameter("@CateterTipoId",          oBE.CateterTipoId),
                        new SqlParameter("@Ssa",                    oBE.Ssa),
                        new SqlParameter("@Presentacion",           oBE.Presentacion),
                        new SqlParameter("@ReaprovisionMultiplos",  oBE.ReaprovisionMultiplos),
                        new SqlParameter("@PrecioLista",            oBE.PrecioLista),
                        new SqlParameter("@PrecioMaximo",           oBE.PrecioMaximo),
                        new SqlParameter("@Iva",                    oBE.Iva),
                        new SqlParameter("@Costo",                  oBE.Costo),
                        new SqlParameter("@PrecioMinimo",           oBE.PrecioMinimo),
                        new SqlParameter("@UnidadMedidaId",         oBE.UnidadMedidaId),
                        new SqlParameter("@Reorden",                oBE.Reorden),
                        new SqlParameter("@Conversion",             oBE.Conversion),
                        new SqlParameter("@PrecioVentaPublico",     oBE.PrecioVentaPublico),
                        new SqlParameter("@DescClubSalud",          oBE.DescClubSalud),
                        new SqlParameter("@ConversionCompras",      oBE.ConversionCompras),
                        new SqlParameter("@CantidadUnidades",       oBE.CantidadUnidades),
                        new SqlParameter("@ComentarioEliminar",     oBE.ComentarioEliminar),
                        new SqlParameter("@Sisoc",                  oBE.Sisoc),
                        new SqlParameter("@CodigoBarras",           oBE.CodigoBarras),
                        new SqlParameter("@MaterialManejoId",       oBE.MaterialManejoId),
                        new SqlParameter("@UsuarioCreacionId",      oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Material oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMaterial_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                 Opcion),
                        new SqlParameter("@MaterialId",             oBE.MaterialId),
                        new SqlParameter("@MaterialDescripcion",    oBE.MaterialDescripcion),
                        new SqlParameter("@Codigo",                 oBE.Codigo),
                        new SqlParameter("@CodigoAlterno",          oBE.CodigoAlterno),
                        new SqlParameter("@CodigoServiciosMedicos", oBE.CodigoServiciosMedicos),
                        new SqlParameter("@ProveedorId",            oBE.ProveedorId),
                        new SqlParameter("@CateterSonda",           oBE.CateterSonda),
                        new SqlParameter("@CateterTipoId",          oBE.CateterTipoId),
                        new SqlParameter("@Ssa",                    oBE.Ssa),
                        new SqlParameter("@Presentacion",           oBE.Presentacion),
                        new SqlParameter("@ReaprovisionMultiplos",  oBE.ReaprovisionMultiplos),
                        new SqlParameter("@PrecioLista",            oBE.PrecioLista),
                        new SqlParameter("@PrecioMaximo",           oBE.PrecioMaximo),
                        new SqlParameter("@Iva",                    oBE.Iva),
                        new SqlParameter("@Costo",                  oBE.Costo),
                        new SqlParameter("@PrecioMinimo",           oBE.PrecioMinimo),
                        new SqlParameter("@UnidadMedidaId",         oBE.UnidadMedidaId),
                        new SqlParameter("@Reorden",                oBE.Reorden),
                        new SqlParameter("@Conversion",             oBE.Conversion),
                        new SqlParameter("@PrecioVentaPublico",     oBE.PrecioVentaPublico),
                        new SqlParameter("@DescClubSalud",          oBE.DescClubSalud),
                        new SqlParameter("@ConversionCompras",      oBE.ConversionCompras),
                        new SqlParameter("@CantidadUnidades",       oBE.CantidadUnidades),
                        new SqlParameter("@ComentarioEliminar",     oBE.ComentarioEliminar),
                        new SqlParameter("@Sisoc",                  oBE.Sisoc),
                        new SqlParameter("@CodigoBarras",           oBE.CodigoBarras),
                        new SqlParameter("@MaterialManejoId",       oBE.MaterialManejoId),
                        new SqlParameter("@UsuarioModificacionId",  oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",      oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",          oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",              oBE.FechaBaja),
                        new SqlParameter("@Baja",                   oBE.Baja)
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