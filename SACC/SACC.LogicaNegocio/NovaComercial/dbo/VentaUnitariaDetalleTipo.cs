using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class VentaUnitariaDetalleTipo
    {
        public static List<Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo> Consultar(SqlOpciones pOpcion, int pVentaUnitariaDetalleTipoId, string pVentaUnitariaDetalleTipoDescripcion, int pBaja)
        {
            Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo oE = new Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo();

            oE.VentaUnitariaDetalleTipoId = pVentaUnitariaDetalleTipoId;

            if (pVentaUnitariaDetalleTipoDescripcion != "")
                oE.VentaUnitariaDetalleTipoDescripcion = pVentaUnitariaDetalleTipoDescripcion;

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

            List<Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo> res = new List<Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo>();
            Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.VentaUnitariaDetalleTipo();

                    item.VentaUnitariaDetalleTipoId          = int.Parse(dr["VentaUnitariaDetalleTipoId"].ToString());
                    item.VentaUnitariaDetalleTipoDescripcion = dr["VentaUnitariaDetalleTipoDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }
    }
}