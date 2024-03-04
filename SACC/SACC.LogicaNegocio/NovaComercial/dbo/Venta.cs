using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace SACC.LogicaNegocio.NovaComercial.dbo
{
    public class Venta
    {
        public static List<Entidades.NovaComercial.dbo.Venta> Consultar(SqlOpciones pOpcion, short pVentaId, string pVentaDescripcion, int pBaja)
        {
            Entidades.NovaComercial.dbo.Venta oE = new Entidades.NovaComercial.dbo.Venta();

            oE.VentaId = pVentaId;

            if (pVentaDescripcion != "")
                oE.VentaDescripcion = pVentaDescripcion;

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

            List<Entidades.NovaComercial.dbo.Venta> res = new List<Entidades.NovaComercial.dbo.Venta>();
            Entidades.NovaComercial.dbo.Venta item = null;

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    item = new Entidades.NovaComercial.dbo.Venta();

                    item.VentaId = short.Parse(dr["VentaId"].ToString());
                    item.VentaDescripcion = dr["VentaDescripcion"].ToString();

                    if (dr.Table.Columns.Contains("Baja"))
                        item.Baja = bool.Parse(dr["Baja"].ToString());

                    res.Add(item);
                }
            }

            return res;
        }


        public static Entidades.EntidadJsonResponse Guardar(Entidades.NovaComercial.dbo.Venta obj)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Venta oE = new Entidades.NovaComercial.dbo.Venta();
            DataSet ds = new DataSet();

            oE.VentaId = obj.VentaId;
            oE.VentaDescripcion = obj.VentaDescripcion;
            oE.UsuarioCreacionId = obj.UsuarioCreacionId;
            oE.UsuarioModificacionId = obj.UsuarioModificacionId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16(obj.Baja));

            if (oE.VentaId == 0)
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

            res.Id = int.Parse(ds.Tables[0].Rows[0]["VentaId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }


        public static Entidades.EntidadJsonResponse BajaLogica(Int32 pVentaId, Int32 pUsuarioId)
        {
            Entidades.EntidadJsonResponse res = new Entidades.EntidadJsonResponse();

            Entidades.NovaComercial.dbo.Venta oE = new Entidades.NovaComercial.dbo.Venta();
            DataSet ds = new DataSet();

            oE.VentaId = pVentaId;
            oE.UsuarioBajaId = pUsuarioId;
            oE.Baja = Convert.ToBoolean(Convert.ToInt16("1"));

            ds = Util.Actualizar(SqlOpciones.BajaLogica, oE).Resultado;

            res.Id = int.Parse(ds.Tables[0].Rows[0]["VentaId"].ToString());
            res.Mensaje = "El registro se actualizo satisfactoriamente.";
            res.MensajeError = "";
            res.Error = false;
            res.TipoMensaje = "success";

            return res;
        }
    }
}