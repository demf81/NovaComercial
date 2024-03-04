using System;
using System.Data;
using System.Data.SqlClient;


namespace SACC.AccesoDatos.NovaComercial.dbo
{
    public class VentaUnitariaDetalle : Conexion.ConexionSQL
    {
        public VentaUnitariaDetalle()
        {
            NombreConexion = "cxnSACC";
        }


        public Entidades.EntidadResponse Consultar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitariaDetalle oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitariaDetalle_Consultar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@VentaUnitariaDetalleId",         oBE.VentaUnitariaDetalleId),
                        new SqlParameter("@VentaUnitariaId",                oBE.VentaUnitariaId),
                        new SqlParameter("@VentaUnitariaDetalleTipoId",     oBE.VentaUnitariaDetalleTipoId),
                        new SqlParameter("@ContratoCondicionId",            oBE.ContratoCondicionId),
                        new SqlParameter("@EsquemaPrePago",                 oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",                oBE.CobroAnticipado),
                        new SqlParameter("@TarifaId",                       oBE.TarifaId),
                        new SqlParameter("@PorcentajeUtilidadSobreTarifa",  oBE.PorcentajeUtilidadSobreTarifa),
                        new SqlParameter("@PorcentajeCopagoContratante",    oBE.PorcentajeCopagoContratante),
                        new SqlParameter("@PorcentajeDescuentoSobreTarifa", oBE.PorcentajeDescuentoSobreTarifa),
                        new SqlParameter("@itemId",                         oBE.itemId),
                        new SqlParameter("@Cantidad",                       oBE.Cantidad),
                        new SqlParameter("@Costo",                          oBE.Costo),
                        new SqlParameter("@Precio",                         oBE.Precio),
                        new SqlParameter("@Subtotal",                       oBE.Subtotal),
                        new SqlParameter("@Baja",                           oBE.Baja)
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


        public Entidades.EntidadResponse Insertar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitariaDetalle oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitariaDetalle_Insertar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@VentaUnitariaId",                oBE.VentaUnitariaId),
                        new SqlParameter("@VentaUnitariaDetalleTipoId",     oBE.VentaUnitariaDetalleTipoId),
                        new SqlParameter("@ContratoId",                     oBE.ContratoId),
                        new SqlParameter("@ContratoCondicionId",            oBE.ContratoCondicionId),
                        new SqlParameter("@PaqueteCoberturaId",             oBE.PaqueteCoberturaId),
                        new SqlParameter("@Amparado",                       oBE.Amparado),
                        new SqlParameter("@EsquemaPrePago",                 oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",                oBE.CobroAnticipado),
                        new SqlParameter("@TarifaId",                       oBE.TarifaId),
                        new SqlParameter("@PorcentajeUtilidadSobreTarifa",  oBE.PorcentajeUtilidadSobreTarifa),
                        new SqlParameter("@PorcentajeCopagoContratante",    oBE.PorcentajeCopagoContratante),
                        new SqlParameter("@PorcentajeDescuentoSobreTarifa", oBE.PorcentajeDescuentoSobreTarifa),
                        new SqlParameter("@Costo",                          oBE.Costo),
                        new SqlParameter("@VentaTipoPrecioId",              oBE.VentaTipoPrecioId),
                        new SqlParameter("@VentaTipoPrecioModeloId",        oBE.VentaTipoPrecioModeloId),
                        new SqlParameter("@VentaTipoPrecioValor",           oBE.VentaTipoPrecioValor),
                        new SqlParameter("@itemId",                         oBE.itemId),
                        new SqlParameter("@Cantidad",                       oBE.Cantidad),
                        new SqlParameter("@Precio",                         oBE.Precio),
                        new SqlParameter("@Subtotal",                       oBE.Subtotal),
                        new SqlParameter("@UsuarioCreacionId",              oBE.UsuarioCreacionId),
                        new SqlParameter("@UsuarioModificacionId",          oBE.UsuarioModificacionId),
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


        public Entidades.EntidadResponse Actualizar(short Opcion, Entidades.NovaComercial.dbo.VentaUnitariaDetalle oBE)
        {
            Entidades.EntidadResponse oEntidadResponse = new Entidades.EntidadResponse();

            try
            {
                oComando.CommandText = "dbo.spVentaUnitariaDetalle_Actualizar";
                oComando.CommandType = CommandType.StoredProcedure;
                oComando.Parameters.Clear();

                oComando.Parameters.AddRange(
                    new SqlParameter[] {
                        new SqlParameter("@Opcion",                         Opcion),
                        new SqlParameter("@VentaUnitariaDetalleId",         oBE.VentaUnitariaDetalleId),
                        new SqlParameter("@VentaUnitariaId",                oBE.VentaUnitariaId),
                        new SqlParameter("@VentaUnitariaDetalleTipoId",     oBE.VentaUnitariaDetalleTipoId),
                        new SqlParameter("@ContratoCondicionId",            oBE.ContratoCondicionId),
                        new SqlParameter("@EsquemaPrePago",                 oBE.EsquemaPrePago),
                        new SqlParameter("@CobroAnticipado",                oBE.CobroAnticipado),
                        new SqlParameter("@TarifaId",                       oBE.TarifaId),
                        new SqlParameter("@PorcentajeUtilidadSobreTarifa",  oBE.PorcentajeUtilidadSobreTarifa),
                        new SqlParameter("@PorcentajeCopagoContratante",    oBE.PorcentajeCopagoContratante),
                        new SqlParameter("@PorcentajeDescuentoSobreTarifa", oBE.PorcentajeDescuentoSobreTarifa),
                        new SqlParameter("@itemId",                         oBE.itemId),
                        new SqlParameter("@Cantidad",                       oBE.Cantidad),
                        new SqlParameter("@Costo",                          oBE.Costo),
                        new SqlParameter("@VentaTipoPrecioId",              oBE.VentaTipoPrecioId),
                        new SqlParameter("@VentaTipoPrecioModeloId",        oBE.VentaTipoPrecioModeloId),
                        new SqlParameter("@VentaTipoPrecioValor",           oBE.VentaTipoPrecioValor),
                        new SqlParameter("@Precio",                         oBE.Precio),
                        new SqlParameter("@Subtotal",                       oBE.Subtotal),
                        new SqlParameter("@UsuarioModificacionId",          oBE.UsuarioModificacionId),
                        new SqlParameter("@FechaModificacion",              oBE.FechaModificacion),
                        new SqlParameter("@UsuarioBajaId",                  oBE.UsuarioBajaId),
                        new SqlParameter("@FechaBaja",                      oBE.FechaBaja),
                        new SqlParameter("@Baja",                           oBE.Baja)
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