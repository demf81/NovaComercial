using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class Medicamento : Conexion.ConexionSQL
    {
        public Medicamento()
        {
            NombreConexion = "cxnSACC";
        }


        public Modelo.ModeloResponse Consultar(Modelo.Parametro.NovaComercial.dbo.MedicamentoPM oParametro)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMedicamento_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  oParametro.Opcion),
                        new SqlParameter("@MedicamentoId",           oParametro.MedicamentoId),
                        new SqlParameter("@MedicamentoDescripcion",  oParametro.MedicamentoDescripcion),
                        new SqlParameter("@MedicamentoCuadroTipoId", oParametro.MedicamentoCuadroTipoId),
                        new SqlParameter("@Baja",                    0)
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


        public Modelo.ModeloResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.Medicamento oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMedicamento_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@MedicamentoDescripcion",  oBE.MedicamentoDescripcion),
                        new SqlParameter("@Codigo",                  oBE.Codigo),
                        new SqlParameter("@CodigoAlterno",           oBE.CodigoAlterno),
                        new SqlParameter("@CodigoServiciosMedicos",  oBE.CodigoServiciosMedicos),
                        new SqlParameter("@ProveedorId",             oBE.ProveedorId),
                        new SqlParameter("@MedicamentoCuadroTipoId", oBE.MedicamentoCuadroTipoId),
                        new SqlParameter("@Presentacion",            oBE.Presentacion),
                        new SqlParameter("@Solucion",                oBE.Solucion),
                        new SqlParameter("@Inmunizacion",            oBE.Inmunizacion),
                        new SqlParameter("@Contrlado",               oBE.Contrlado),
                        new SqlParameter("@Oxitonito",               oBE.Oxitonito),
                        new SqlParameter("@ReaprovisionMultiplos",   oBE.ReaprovisionMultiplos),
                        new SqlParameter("@FormulaLactea",           oBE.FormulaLactea),
                        new SqlParameter("@Refrigerado",             oBE.Refrigerado),
                        new SqlParameter("@PrecioLista",             oBE.PrecioLista),
                        new SqlParameter("@PrecioMaximo",            oBE.PrecioMaximo),
                        new SqlParameter("@Iva",                     oBE.Iva),
                        new SqlParameter("@Costo",                   oBE.Costo),
                        new SqlParameter("@PrecioMinimo",            oBE.PrecioMinimo),
                        new SqlParameter("@UnidadMedidaId",          oBE.UnidadMedidaId),
                        new SqlParameter("@PrecioVentaPublico",      oBE.PrecioVentaPublico),
                        new SqlParameter("@DescClubSalud",           oBE.DescClubSalud),
                        new SqlParameter("@CantidadUnidades",        oBE.CantidadUnidades),
                        new SqlParameter("@CodigoBarras",            oBE.CodigoBarras),
                        new SqlParameter("@UsuarioCreacionId",       oBE.UsuarioCreacionId)
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


        public Modelo.ModeloResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.Medicamento oBE)
        {
            Modelo.ModeloResponse oEntidadResponse = new Modelo.ModeloResponse();

            try
            {
                oComando.CommandText = "dbo.spMedicamento_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                  Opcion),
                        new SqlParameter("@MedicamentoId",           oBE.MedicamentoId),
                        new SqlParameter("@MedicamentoDescripcion",  oBE.MedicamentoDescripcion),
                        new SqlParameter("@Codigo",                  oBE.Codigo),
                        new SqlParameter("@CodigoAlterno",           oBE.CodigoAlterno),
                        new SqlParameter("@CodigoServiciosMedicos",  oBE.CodigoServiciosMedicos),
                        new SqlParameter("@ProveedorId",             oBE.ProveedorId),
                        new SqlParameter("@MedicamentoCuadroTipoId", oBE.MedicamentoCuadroTipoId),
                        new SqlParameter("@Presentacion",            oBE.Presentacion),
                        new SqlParameter("@Solucion",                oBE.Solucion),
                        new SqlParameter("@Inmunizacion",            oBE.Inmunizacion),
                        new SqlParameter("@Contrlado",               oBE.Contrlado),
                        new SqlParameter("@Oxitonito",               oBE.Oxitonito),
                        new SqlParameter("@ReaprovisionMultiplos",   oBE.ReaprovisionMultiplos),
                        new SqlParameter("@FormulaLactea",           oBE.FormulaLactea),
                        new SqlParameter("@Refrigerado",             oBE.Refrigerado),
                        new SqlParameter("@PrecioLista",             oBE.PrecioLista),
                        new SqlParameter("@PrecioMaximo",            oBE.PrecioMaximo),
                        new SqlParameter("@Iva",                     oBE.Iva),
                        new SqlParameter("@Costo",                   oBE.Costo),
                        new SqlParameter("@PrecioMinimo",            oBE.PrecioMinimo),
                        new SqlParameter("@UnidadMedidaId",          oBE.UnidadMedidaId),
                        new SqlParameter("@PrecioVentaPublico",      oBE.PrecioVentaPublico),
                        new SqlParameter("@DescClubSalud",           oBE.DescClubSalud),
                        new SqlParameter("@CantidadUnidades",        oBE.CantidadUnidades),
                        new SqlParameter("@CodigoBarras",            oBE.CodigoBarras),
                        new SqlParameter("@UsuarioModificacionId",   oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",       oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",           oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",               oBE.FechaBaja),
                        new SqlParameter("@Baja",                    oBE.Baja)
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