using System;
using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class VentaUnitariaDetalle
    {
        public static List<Entidades.NovaComercial.dbo.VentaUnitariaDetalle> Consultar(SqlOpciones pOpcion, int pVentaUnitariaId, int pBaja)
        {
            Entidades.NovaComercial.dbo.VentaUnitariaDetalle oE = new Entidades.NovaComercial.dbo.VentaUnitariaDetalle();

            oE.VentaUnitariaId = pVentaUnitariaId;

            switch (pBaja)
            {
                case 0:
                    oE.Baja = false;
                    break;
                case 1:
                    oE.Baja = true;
                    break;
                default:
                    oE.Baja = null;
                    break;
            }

            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            List<Entidades.NovaComercial.dbo.VentaUnitariaDetalle> res = new List<Entidades.NovaComercial.dbo.VentaUnitariaDetalle>();
            Entidades.NovaComercial.dbo.VentaUnitariaDetalle item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.VentaUnitariaDetalle();

                    item.VentaUnitariaDetalleId         = int.Parse(dr["VentaUnitariaDetalleId"].ToString());
                    item.VentaUnitariaId = int.Parse(dr["VentaUnitariaId"].ToString());

                    if (dr.Table.Columns.Contains("ServicioDescripcion"))
                        item.CampoComplemento_ServicioDescripcion = dr["ServicioDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("ContratoId"))
                        item.ContratoId = int.Parse(dr["ContratoId"].ToString());

                    if (dr.Table.Columns.Contains("ContratoCondicionId"))
                        item.ContratoCondicionId = int.Parse(dr["ContratoCondicionId"].ToString());

                    if (dr.Table.Columns.Contains("PaqueteCoberturaId"))
                        item.PaqueteCoberturaId = int.Parse(dr["PaqueteCoberturaId"].ToString());

                    if (dr.Table.Columns.Contains("Amparado"))
                        item.Amparado = bool.Parse(dr["Amparado"].ToString());

                    if (dr.Table.Columns.Contains("EsquemaPrePago"))
                        item.EsquemaPrePago = bool.Parse(dr["EsquemaPrePago"].ToString());

                    if (dr.Table.Columns.Contains("CobroAnticipado"))
                        item.EsquemaPrePago = bool.Parse(dr["CobroAnticipado"].ToString());

                    if (dr.Table.Columns.Contains("TarifaId"))
                        item.TarifaId = int.Parse(dr["TarifaId"].ToString());

                    if (dr.Table.Columns.Contains("PorcentajeUtilidadSobreTarifa"))
                        item.PorcentajeUtilidadSobreTarifa = decimal.Parse(dr["PorcentajeUtilidadSobreTarifa"].ToString());

                    if (dr.Table.Columns.Contains("PorcentajeCopagoContratante"))
                        item.PorcentajeCopagoContratante = decimal.Parse(dr["PorcentajeCopagoContratante"].ToString());

                    if (dr.Table.Columns.Contains("PorcentajeDescuentoSobreTarifa"))
                        item.PorcentajeDescuentoSobreTarifa = decimal.Parse(dr["PorcentajeDescuentoSobreTarifa"].ToString());

                    if (dr.Table.Columns.Contains("itemId"))
                        item.itemId = int.Parse(dr["itemId"].ToString());

                    if (dr.Table.Columns.Contains("Cantidad"))
                        item.Cantidad = decimal.Parse(dr["Cantidad"].ToString());

                    if (dr.Table.Columns.Contains("Costo"))
                        item.Costo = decimal.Parse(dr["Costo"].ToString());

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.VentaUnitariaDetalle obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.VentaUnitariaDetalle oE = new Entidades.NovaComercial.dbo.VentaUnitariaDetalle();
            DataSet ds = new DataSet();

            oE.VentaUnitariaDetalleId         = obj.VentaUnitariaDetalleId;
            oE.VentaUnitariaId                = obj.VentaUnitariaId;
            oE.VentaUnitariaDetalleTipoId     = obj.VentaUnitariaDetalleTipoId;
            oE.ContratoId                     = obj.ContratoId;
            oE.ContratoCondicionId            = obj.ContratoCondicionId;
            oE.PaqueteCoberturaId             = obj.PaqueteCoberturaId;
            oE.Amparado                       = obj.Amparado;
            oE.EsquemaPrePago                 = obj.EsquemaPrePago;
            oE.CobroAnticipado                = obj.CobroAnticipado;
            oE.TarifaId                       = obj.TarifaId;
            oE.PorcentajeUtilidadSobreTarifa  = obj.PorcentajeUtilidadSobreTarifa;
            oE.PorcentajeCopagoContratante    = obj.PorcentajeCopagoContratante;
            oE.PorcentajeDescuentoSobreTarifa = obj.PorcentajeDescuentoSobreTarifa;
            oE.itemId                         = obj.itemId;
            oE.Cantidad                       = obj.Cantidad;
            oE.Costo                          = obj.Costo;
            oE.VentaTipoPrecioId              = obj.VentaTipoPrecioId;
            oE.VentaTipoPrecioModeloId        = obj.VentaTipoPrecioModeloId;
            oE.VentaTipoPrecioValor           = obj.VentaTipoPrecioValor;
            oE.Precio                         = obj.Precio;
            oE.Subtotal                       = obj.Subtotal;
            oE.UsuarioCreacionId              = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId          = obj.UsuarioModificacionId;
            oE.Baja                           = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.VentaUnitariaDetalleId == 0)
            {
                ds = Util.Insertar(SqlOpciones.Insertar, oE).Resultado;
            }
            else
            {
                if (obj.Baja == true)
                {
                    oE.UsuarioBajaId = obj.UsuarioBajaId;
                }

                ds = Util.Actualizar(SqlOpciones.Actualizar, oE).Resultado;
            }

            res.Id           = int.Parse(ds.Tables[0].Rows[0]["VentaUnitariaDetalleId"].ToString());
            res.Mensaje      = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error        = false;
            res.TipoMensaje  = "success";

            return res;
        }
    }
}