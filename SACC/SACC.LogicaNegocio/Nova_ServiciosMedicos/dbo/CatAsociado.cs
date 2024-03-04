using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.Nova_ServiciosMedicos.dbo
{
    public class CatAsociado
    {
        public static List<Entidades.Nova_ServiciosMedicos.dbo.CatAsociado> Consultar(SqlOpciones pOpcion, string pVcAfiliado)
        {
            Entidades.Nova_ServiciosMedicos.dbo.CatAsociado oE = new Entidades.Nova_ServiciosMedicos.dbo.CatAsociado();
            oE.vcAfiliado = pVcAfiliado;
                
            DataSet ds = Util.Consultar(pOpcion, oE).Resultado;

            List<Entidades.Nova_ServiciosMedicos.dbo.CatAsociado> res = new List<Entidades.Nova_ServiciosMedicos.dbo.CatAsociado>();
            Entidades.Nova_ServiciosMedicos.dbo.CatAsociado item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.Nova_ServiciosMedicos.dbo.CatAsociado();

                    item.IdNumeroSocio = int.Parse(dr["IdNumeroSocio"].ToString());

                    if (dr.Table.Columns.Contains("bActivo"))
                        item.bActivo = new bool?(bool.Parse(dr["bActivo"].ToString()));

                    res.Add(item);
                }
            }

            return res;
        }
    }
}