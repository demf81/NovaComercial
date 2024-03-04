using System.Collections.Generic;
using System.Data;


namespace SACC.LogicaNegocio.NovaComercial.PortalEmpresa
{
    public static class Perfil
    {
        public static List<Entidades.NovaComercial.PortalEmpresa.Perfil> Consultar(SqlOpciones pOpcion, int pPerfilId, string pPerfilDescripcion, int pBaja)
        {
            Entidades.NovaComercial.PortalEmpresa.Perfil oE = new Entidades.NovaComercial.PortalEmpresa.Perfil();

            oE.PerfilId = pPerfilId;

            if (pPerfilDescripcion != "")
                oE.PerfilDescripcion = pPerfilDescripcion;

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

            List<Entidades.NovaComercial.PortalEmpresa.Perfil> res = new List<Entidades.NovaComercial.PortalEmpresa.Perfil>();
            Entidades.NovaComercial.PortalEmpresa.Perfil item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.PortalEmpresa.Perfil();

                    item.PerfilId = int.Parse(dr["PerfilId"].ToString());

                    item.PerfilDescripcion = dr["PerfilDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }
    }
}